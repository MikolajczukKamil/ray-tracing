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

        public RayTracer(Scene scene, int maxDepth = 10)
        {
            this.scene = scene;
            this.maxDepth = maxDepth;
        }
   
        public Bitmap fragmentRender(int screenWidth, int screenHeight, int fragmentIndex, int fragments)
        {
            var image = new Bitmap(screenWidth, fragmentIndex == fragments - 1 ? screenHeight - fragmentIndex * (screenHeight / fragments) : screenHeight / fragments);

            var camera = scene.camera;

            var up = camera.up.times(camera.zoom);
            var right = camera.right.times(camera.zoom);

            var minAxis = Math.Min(screenWidth, screenHeight);

            var start = fragmentIndex * (screenHeight / fragments);

            for (var y = 0; y < image.Height; y++)
            {
                double recenterY = ((start + y) - (minAxis / 2.0)) / 2.0 / minAxis;
                var pointY = camera.forward.plus(up.times(-recenterY));

                for (var x = 0; x < screenWidth; x++)
                {
                    double recenterX = (x - (minAxis / 2.0)) / 2.0 / minAxis;

                    var point = pointY.plus(right.times(recenterX)).norm();
                    var ray = new Ray(camera.position, point);
                    var color = traceRay(ray, scene, 0);

                    image.SetPixel(x, y, color.toDrawingColor());
                }
            }

            return image;
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

        private RColor traceRay(Ray ray, Scene scene, int depth)
        {
            var isect = closestIntersection(ray, scene);

            if (isect == null) return background;

            var direction = isect.ray.direction;
            var position = direction.times(isect.dist).plus(isect.ray.origin);
            var reflectDir = direction.minus(
                isect.norm.times(2 * isect.norm.dot(direction))
             );

            var naturalColor = background.plus(
                getNaturalColor(isect.thing, position, isect.norm, reflectDir, scene)
             );

            var reflectedColor = (depth >= maxDepth) ?
                RColor.grey : 
                getReflectionColor(isect.thing, position, reflectDir, scene, depth);

            return naturalColor.plus(reflectedColor);
        }

        private RColor getReflectionColor(Thing thing, Vector position, Vector reflectDir, Scene scene, int depth)
        {
            return traceRay(new Ray(position, reflectDir), scene, depth + 1).scale(thing.surface.reflect(position));
        }

        private RColor getNaturalColor(Thing thing, Vector position, Vector norm, Vector reflectDir, Scene scene)
        {
            var color = defaultColor;
            var thingDiffuse = thing.surface.diffuse(position);
            var thingSpecular = thing.surface.specular(position);

            foreach (var light in scene.lights)
            {
                var toLightDirection = light.position.minus(position);
                var toLightDirectionNorm = toLightDirection.norm();
                var closest = closestIntersection(new Ray(position, toLightDirectionNorm), scene);

                var isInShadow = closest == null ? false : (closest.dist <= toLightDirection.mag());

                if (!isInShadow)
                {
                    var illum = toLightDirectionNorm.dot(norm);
                    var lColor = illum > 0 ? light.color.scale(illum) : defaultColor;

                    var specular = toLightDirectionNorm.dot(reflectDir.norm());
                    var sColor = specular > 0 ? light.color.scale(Math.Pow(specular, thing.surface.roughness)) : defaultColor;

                    color = color.plus(lColor.times(thingDiffuse).plus(sColor.times(thingSpecular)));
                }
            }

            return color;
        }
    }
}

