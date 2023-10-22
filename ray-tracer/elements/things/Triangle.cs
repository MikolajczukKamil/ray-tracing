using ray_tracer.common;
using ray_tracer.scene;
using System;

namespace ray_tracer.elements.things
{
    public class Triangle : Thing
    {
        public Surface surface { get; set; }

        public readonly Vector v1;
        public readonly Vector v2;
        public readonly Vector v3;

        private readonly Vector edge1;
        private readonly Vector edge2;
        private readonly Vector edge3;
        private readonly Vector norm;

        public Triangle(Vector v1, Vector v2, Vector v3, Surface surface)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.surface = surface;

            edge1 = v2.minus(v1);
            edge2 = v3.minus(v2);
            edge3 = v1.minus(v3);
            norm = edge1.cross(v3.minus(v1)).norm();
        }

        public Intersection intersect(Ray ray)
        {
            var normRayDirectionDot = norm.dot(ray.direction);

            var areParallel = Math.Abs(normRayDirectionDot) <= double.Epsilon;
            if (areParallel) return null;

            var D = -norm.dot(v1);
            var t = -(norm.dot(ray.start) + D) / normRayDirectionDot;

            var isBehind = t < 0;
            //if (isBehind) return null;

            var relativeP = ray.direction.times(t);
            var p = ray.start.plus(relativeP);

            if (!isPointInside(p)) return null;

            return new Intersection(this, ray, relativeP.mag());
        }

        public Vector normal(Vector pos)
        {
            return norm;
        }

        public bool isPointInside(Vector p)
        {
            if (
                norm.dot(edge1.cross(p.minus(v1))) < 0 ||
                norm.dot(edge2.cross(p.minus(v2))) < 0 ||
                norm.dot(edge3.cross(p.minus(v3))) < 0
            ) return false;

            return true;
        }
    }
}

// https://scratchapixel.com/lessons/3d-basic-rendering/ray-tracing-rendering-a-triangle/ray-triangle-intersection-geometric-solution.html
