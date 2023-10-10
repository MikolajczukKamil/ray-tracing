using ray_tracer.common;

namespace ray_tracer.scene
{
    public class Ray
    {
        public readonly Vector start;
        public readonly Vector dir;

        public Ray(Vector start, Vector dir)
        {
            this.start = start;
            this.dir = dir;
        }
    }
}
