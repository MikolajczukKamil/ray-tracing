﻿using ray_tracer.common;
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

        public Bitmap fragmentRender(int screenWidth, int screenHeight, int fragmentIndex, int threads)
        {
            var image = new Bitmap(screenWidth, fragmentIndex == threads - 1 ? screenHeight - fragmentIndex * (screenHeight / threads) : screenHeight / threads);

            var camera = scene.camera;

            var up = camera.up.times(camera.zoom);
            var right = camera.right.times(camera.zoom);

            var minAxis = Math.Min(screenWidth, screenHeight);

            var start = fragmentIndex * (screenHeight / threads);

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

        private RColor shade(Intersection isect, Scene scene, int depth)
        {
            var d = isect.ray.dir;
            var pos = d.times(isect.dist).plus(isect.ray.start);
            var normal = isect.thing.normal(pos);
            var reflectDir = d.minus(
                normal
                .times(normal.dot(d))
                .times(2)
             );
            var naturalColor = background.plus(
                getNaturalColor(isect.thing, pos, normal, reflectDir, scene)
             );
            var reflectedColor = (depth >= maxDepth) ?
                RColor.grey : 
                getReflectionColor(isect.thing, pos, normal, reflectDir, scene, depth);

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
                var ldis = light.pos.minus(pos);
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

        public void fullRender(Bitmap image, int screenWidth, int screenHeight)
        {
            var camera = scene.camera;

            var up = camera.up.times(camera.zoom);
            var right = camera.right.times(camera.zoom);

            var minAxis = Math.Min(screenWidth, screenHeight);

            for (var y = 0; y < screenHeight; y++)
            {
                double recenterY = (y - (minAxis / 2.0)) / 2.0 / minAxis;
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
        }
    }
}

