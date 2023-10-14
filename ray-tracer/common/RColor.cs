using System;
using System.Drawing;

namespace ray_tracer.common
{
    public class RColor
    {
        public static readonly RColor white = new RColor(1.0, 1.0, 1.0);
        public static readonly RColor grey = new RColor(0.5, 0.5, 0.5);
        public static readonly RColor black = new RColor(0.0, 0.0, 0.0);

        public readonly double r;
        public readonly double g;
        public readonly double b;

        public RColor(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        private double norm(double x, double max = 1)
        {
            return Math.Max(0, Math.Min(max, x));
        }

        public RColor scale(double k)
        {
            return new RColor(k * r, k * g, k * b);
        }

        public RColor plus(RColor other)
        {
            return new RColor(r + other.r, g + other.g, b + other.b);
        }

        public RColor times(RColor other)
        {
            return new RColor(r * other.r, g * other.g, b * other.b);
        }

        public Color toDrawingColor()
        {
            return Color.FromArgb(
                (int)Math.Round(norm(r) * 255),
                (int)Math.Round(norm(g) * 255),
                (int)Math.Round(norm(b) * 255)
                );
        }
    }
}
