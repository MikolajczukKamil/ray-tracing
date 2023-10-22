﻿using ray_tracer.common;

namespace ray_tracer.scene
{
    public class Ray
    {
        public readonly Vector start;
        public readonly Vector direction;

        public Ray(Vector start, Vector direction)
        {
            this.start = start;
            this.direction = direction;
        }
    }
}
