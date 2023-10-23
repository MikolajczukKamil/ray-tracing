using ray_tracer.common;

namespace ray_tracer.scene
{
    public class Intersection
    {
        public readonly Thing thing;
        public readonly Ray ray;
        public readonly Vector norm;
        public readonly double dist;

        public Intersection(Thing thing, Ray ray, Vector norm, double dist)
        {
            this.thing = thing;
            this.ray = ray;
            this.norm = norm;
            this.dist = dist;
        }
    }
}
