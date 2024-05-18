package pl.mikolajczuk.kamil.raytracing.lib.common;

public class Vector
    {
        public double x;

        public double y;

        public double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        private double[] array;

        public double get(int i) {
            return asArray()[i];
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

        public double mag()
        {
            return Math.sqrt(x * x + y * y + z * z);
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

        public double[] asArray()
        {
            if (array == null) array = new double[] { x, y, z };

            return array;
        }
    }
