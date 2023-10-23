using System;
using ray_tracer.common;
using ray_tracer.scene;


namespace ray_tracer.elements.surfaces
{
    public class Checkerboard : Surface
    {
        public double roughness => 150.0;

        public RColor diffuse(Vector pos)
        {
            if (isBlackField(pos)) return RColor.white;

            return RColor.black;
        }

        public double reflect(Vector pos)
        {
            if (isBlackField(pos)) return 0.1;

            return 0.7;
        }

        public RColor specular(Vector pos)
        {
            return RColor.white;
        }

        private bool isBlackField(Vector pos)
        {
            return (int) (Math.Floor(pos.z) + Math.Floor(pos.x)) % 2 != 0;
        }
    }
}
