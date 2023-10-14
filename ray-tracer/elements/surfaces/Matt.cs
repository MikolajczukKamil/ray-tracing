using System;
using ray_tracer.common;
using ray_tracer.scene;


namespace ray_tracer.elements.surfaces
{
    public class Matt : Surface
    {
        public double roughness => 50.0;

        public RColor diffuse(Vector pos)
        {
            return RColor.white;
        }

        public double reflect(Vector pos)
        {
            return 0.05;
        }

        public RColor specular(Vector pos)
        {
            return RColor.grey;
        }
    }
}
