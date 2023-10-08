using System;

namespace ray_tracer.common
{
    class Vector
    {
        public readonly double x;

        public readonly double y;

        public readonly double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector times(double k)
        {
            return new Vector(k * x, k * y, k * z);
        }

        public Vector minus(Vector other)
        {
            return new Vector(x - other.x, y - other.y, z - other.z);
        }

        public Vector plus(Vector other)
        {
            return new Vector(x + other.x, y + other.y, z + other.z);
        }

        public double dot(Vector other)
        {
            return x * other.x + y * other.y + z * other.z;
        }

        public double mag2()
        {
            return x * x + y * y + z * z;
        }

        public double mag()
        {
            return Math.Sqrt(mag2());
        }

        public Vector norm()
        {
            return times(1 / mag());
        }

        public Vector cross(Vector other)
        {
            return new Vector(
                y * other.z - z * other.y,
                z * other.x - x * other.z,
                x * other.y - y * other.x
            );
        }
    }
}
