using System;
using ray_tracer.common;
using ray_tracer.scene;


namespace ray_tracer.elements.surfaces
{
    public class Checkerboard : Surface
    {
        public double roughness => 150.0;

        public Color diffuse(Vector pos)
        {
            if (isBlackField(pos))
            {
                return Color.white;
            }

            return Color.black;
        }

        public double reflect(Vector pos)
        {
            if (isBlackField(pos))
            {
                return 0.1;
            }

            return 0.7;
        }

        public Color specular(Vector pos)
        {
            return Color.white;
        }

        private bool isBlackField(Vector pos)
        {
            return (int) (Math.Floor(pos.z) + Math.Floor(pos.x)) % 2 != 0;
        }
    }
}
