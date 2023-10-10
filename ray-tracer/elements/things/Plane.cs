﻿using ray_tracer.common;
using ray_tracer.scene;
using System;

namespace ray_tracer.elements.things
{
    public class Plane : Thing
    {
        public Surface surface { get; set; }

        public readonly Vector norm;
        public readonly double offset;

        public Plane(Vector norm, double offset, Surface surface)
        {
            this.norm = norm;
            this.offset = offset;
            this.surface = surface;
        }

        public Intersection intersect(Ray ray)
        {
            var denom = norm.dot(ray.dir);

            if (denom > 0)
            {
                return null;
            }

            var dist = (norm.dot(ray.start) + offset) / (-denom);

            return new Intersection(this, ray, dist);
        }

        public Vector normal(Vector pos)
        {
            return norm;
        }
    }
}
