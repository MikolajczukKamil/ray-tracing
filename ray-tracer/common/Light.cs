namespace ray_tracer.common
{
    public class Light
    {
        public readonly Vector pos;
        public readonly RColor color;

        public Light(Vector pos, RColor color)
        {
            this.pos = pos;
            this.color = color;
        }
    }
}
