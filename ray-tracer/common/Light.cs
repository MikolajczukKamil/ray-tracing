namespace ray_tracer.common
{
    public class Light
    {
        public readonly Vector position;
        public readonly RColor color;

        public Light(Vector pos, RColor color)
        {
            this.position = pos;
            this.color = color;
        }
    }
}
