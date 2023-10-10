using ray_tracer.common;
using ray_tracer.scene;

using System;
using System.Drawing;

namespace ray_tracer
{
    public class RayTracer
    {
        private readonly RColor background = RColor.black;
        private readonly RColor defaultColor = RColor.black;

        private readonly Scene scene;
        private readonly int maxDepth;
        private readonly int screenWidth;
        private readonly int screenHeight;

        public RayTracer(Scene scene, int screenWidth, int screenHeight, int maxDepth = 5)
        {
            this.scene = scene;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.maxDepth = maxDepth;
        }

        private Intersection closestIntersection(Ray ray, Scene scene)
        {
            var closest = double.PositiveInfinity;
            Intersection closestInter = null;

            foreach (var thing in scene.things)
            {
                var inter = thing.intersect(ray);

                if (inter != null && inter.dist < closest)
                {
                    closestInter = inter;
                    closest = inter.dist;
                }
            }

            return closestInter;
        }

        private double testRay(Ray ray, Scene scene)
        {
            var closest = closestIntersection(ray, scene);

            return closest == null ? double.NaN : closest.dist;
        }

        private RColor traceRay(Ray ray, Scene scene, int depth)
        {
            var closest = closestIntersection(ray, scene);

            if (closest == null)
            {
                return background;
            }

            return shade(closest, scene, depth);
        }

        private RColor shade(Intersection isect, Scene scene, int depth)
        {
            var d = isect.ray.dir;
            var pos = d.times(isect.dist).plus(isect.ray.start);
            var normal = isect.thing.normal(pos);
            var reflectDir = d.minus(normal.times(normal.dot(d) * 2));
            var naturalColor = background.plus(getNaturalColor(isect.thing, pos, normal, reflectDir, scene));
            var reflectedColor = (depth >= maxDepth) ? RColor.grey : getReflectionColor(isect.thing, pos, normal, reflectDir, scene, depth);

            return naturalColor.plus(reflectedColor);
        }

        private RColor getReflectionColor(Thing thing, Vector pos, Vector normal, Vector rd, Scene scene, int depth)
        {
            return traceRay(new Ray(pos, rd), scene, depth + 1).scale(thing.surface.reflect(pos));
        }

        private RColor getNaturalColor(Thing thing, Vector pos, Vector norm, Vector rd, Scene scene)
        {
            var color = defaultColor;
            var thingDiffuse = thing.surface.diffuse(pos);
            var thingSpecular = thing.surface.specular(pos);

            foreach (var light in scene.lights)
            {
                var ldis = pos.minus(light.pos);
                var livec = ldis.norm();
                var neatIsect = testRay(new Ray(pos, livec), scene);
                var isInShadow = double.IsNaN(neatIsect) ? false : (neatIsect <= ldis.mag());

                if (!isInShadow)
                {
                    var illum = livec.dot(norm);
                    var lcolor = illum > 0 ? light.color.scale(illum) : defaultColor;

                    var specular = livec.dot(rd.norm());
                    var scolor = specular > 0 ? light.color.scale(Math.Pow(specular, thing.surface.roughness)) : defaultColor;

                    color = color.plus(lcolor.times(thingDiffuse).plus(thingSpecular.times(scolor)));
                }
            }

            return color;
        }

        public void render()
        {
            for (var y = 0; y < screenHeight; y++)
            {
                for (var x = 0; x < screenWidth; x++)
                {
                    var recenterX = (x - (screenWidth / 2.0)) / 2.0 / screenWidth;
                    var recenterY = -(y - (screenHeight / 2.0)) / 2.0 / screenHeight;

                    var point = scene.camera.forward.plus(
                        scene.camera.right
                            .times(recenterX)
                            .plus(scene.camera.up.times(recenterY))
                        ).norm();

                    var color = traceRay(new Ray(scene.camera.position, point), scene, 0);
                    //var c = color.toDrawingColor();
                    //ctx.fillStyle = "rgb(" + String(c.r) + ", " + String(c.g) + ", " + String(c.b) + ")";
                    //ctx.fillRect(x, y, x + 1, y + 1);
                }
            }
        }
    }
}

