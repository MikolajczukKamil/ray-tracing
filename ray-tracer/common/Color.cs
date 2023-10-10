using System;

namespace ray_tracer.common
{
    public class Color
    {
        public static readonly Color white = new Color(1.0, 1.0, 1.0);
        public static readonly Color grey = new Color(0.5, 0.5, 0.5);
        public static readonly Color black = new Color(0.0, 0.0, 0.0);

        public readonly double r;
        public readonly double g;
        public readonly double b;

        public Color(double r, double g, double b)
        {
            this.r = norm(r);
            this.g = norm(g);
            this.b = norm(b);
        }

        private double norm(double x)
        {
            return Math.Max(0, Math.Min(1, x));
        }

        public Color scale(double k)
        {
            return new Color(k * r, k * g, k * b);
        }

        public Color plus(Color other)
        {
            return new Color(r + other.r, g + other.g, b + other.b);
        }

        public Color times(Color other)
        {
            return new Color(r * other.r, g * other.g, b * other.b);
        }

        public Color toDrawingColor()
        {
            throw new Exception("toDrawingColor");
        }
    }
}
