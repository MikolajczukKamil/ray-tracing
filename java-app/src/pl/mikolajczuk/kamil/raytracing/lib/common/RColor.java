package pl.mikolajczuk.kamil.raytracing.lib.common;

public class RColor
    {
        public static final RColor white = new RColor(1.0, 1.0, 1.0);
        public static final RColor grey  = new RColor(0.5, 0.5, 0.5);
        public static final RColor black = new RColor(0.0, 0.0, 0.0);

        public final double r;
        public final double g;
        public final double b;

        public RColor(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        private static double norm(double x)
        {
            return Math.max(0, Math.min(1, x));
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

        /*
        public Color toDrawingColor()
        {
            return Color.FromArgb(
                (int)Math.round(norm(r) * 255.0),
                (int)Math.round(norm(g) * 255.0),
                (int)Math.round(norm(b) * 255.0)
                );
        }
        */

        public static RColor from(int r, int g, int b)
        {
            return new RColor(norm(r / 255.0), norm(g / 255.0), norm(b / 255.0));
        }
    }

