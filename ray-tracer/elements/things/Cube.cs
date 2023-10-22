using ray_tracer.common;
using ray_tracer.scene;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ray_tracer.elements.things
{
    public class Cube : Thing
    {
        public Surface surface { get; set; }

        public readonly Vector position;
        public readonly Vector size;
        private readonly Vector endPosition;

        private readonly List<Plane> sides;

        public Cube(Vector position, Vector size, Surface surface)
        {
            this.position = position;
            this.size = size;
            this.surface = surface;

            endPosition = position.plus(size);
            sides = new List<Plane>(6);

            for(int i = 0; i < 3; i++)
            {
                var vector = new Vector(
                    i == 0 ? 1 : 0,
                    i == 1 ? 1 : 0,
                    i == 2 ? 1 : 0
                );

                sides.Add(new Plane(vector, position[i] + size[i], surface));
                sides.Add(new Plane(vector.times(-1), position[i], surface));
            }
        }

        public Intersection intersect(Ray ray)
        {
            var tmin = 0.0;
            var tmax = double.PositiveInfinity;

            for (int axis = 0; axis < 3; ++axis)
            {
                var t1 = (position[axis] - ray.start[axis]) / ray.direction[axis];
                var t2 = (endPosition[axis] - ray.start[axis]) / ray.direction[axis];

                tmin = Math.Min(Math.Max(t1, tmin), Math.Max(t2, tmin));
                tmax = Math.Max(Math.Min(t1, tmax), Math.Min(t2, tmax));
            }

            if (tmin > tmax)
            {
                return null;
            }

            return new Intersection(this, ray, getClosestSide(ray).dist);
        }

        public Vector normal(Vector position)
        {
            return position.norm();
        }

        private Intersection getClosestSide(Ray ray)
        {
            Intersection closest = null;

            foreach(var side in sides) {
                var intersection = side.intersect(ray);

                if (intersection != null && (closest == null || closest.dist > intersection.dist))
                {
                    closest = intersection;
                }
            }

            return closest;
        }
    }
}
