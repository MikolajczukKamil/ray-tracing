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

        public Camera(Vector position, Vector lookAt)
        {
            this.position = position;
            this.lookAt = lookAt;

            forward = lookAt.minus(position).norm();
            right = forward.cross(down).norm().times(1.5);
            up = forward.cross(right).norm().times(1.5);
        }
    }
}
