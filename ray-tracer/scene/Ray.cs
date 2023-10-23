using ray_tracer.common;

namespace ray_tracer.scene
{
    public class Ray
    {
        public readonly Vector origin;
        public readonly Vector direction;

        public Ray(Vector origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
    }
}
