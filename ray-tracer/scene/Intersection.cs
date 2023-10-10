namespace ray_tracer.scene
{
    public class Intersection
    {
        public readonly Thing thing;
        public readonly Ray ray;
        public readonly double dist;

        public Intersection(Thing thing, Ray ray, double dist)
        {
            this.thing = thing;
            this.ray = ray;
            this.dist = dist;
        }
    }
}
