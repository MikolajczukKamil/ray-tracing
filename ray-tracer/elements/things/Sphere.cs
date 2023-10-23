using ray_tracer.common;
using ray_tracer.scene;
using System;

namespace ray_tracer.elements.things
{
    public class Sphere : Thing
    {
        public Surface surface { get; set; }

        public readonly Vector center;
        public readonly double radius2;

        public Sphere(Vector center, double radius, Surface surface)
        {
            this.center = center;
            this.radius2 = radius * radius;
            this.surface = surface;
        }

        public Intersection intersect(Ray ray)
        {
            var eo = center.minus(ray.origin);
            var v = eo.dot(ray.direction);

            if (v >= 0)
            {
                var disc = radius2 - (eo.dot(eo) - v * v);

                if (disc >= 0)
                {
                    var dist = v - Math.Sqrt(disc);
                    if (dist == 0.0) return null;

                    var p = ray.origin.plus(ray.direction.times(dist));

                    return new Intersection(this, ray, p.minus(center).norm(), dist);
                }
            }

            return null;
        }
    }
}
