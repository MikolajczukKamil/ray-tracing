namespace ray_tracer.common
{
    public class Light
    {
        public readonly Vector pos;
        public readonly Color color;

        public Light(Vector pos, Color color)
        {
            this.pos = pos;
            this.color = color;
        }
    }
}
