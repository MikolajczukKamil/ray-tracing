using ray_tracer.common;
using System;

namespace ray_tracer.scene
{
    public class Camera
    {
        private static readonly Vector down = new Vector(0.0, -1.0, 0.0);

        public readonly Vector position;
        public readonly Vector lookAt;

        public readonly Vector forward;
        public readonly Vector right;
        public readonly Vector up;

        public readonly double zoom;

        public Camera(Vector position, Vector lookAt, double zoom)
        {
            this.position = position;
            this.lookAt = lookAt;
            this.zoom = zoom;

            forward = lookAt.minus(position).norm();
            right = forward.cross(down).norm();
            up = forward.cross(right).norm();
        }
    }
}
