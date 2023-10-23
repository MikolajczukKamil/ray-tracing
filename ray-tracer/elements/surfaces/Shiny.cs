using System;
using ray_tracer.common;
using ray_tracer.scene;


namespace ray_tracer.elements.surfaces
{
    public class Shiny : Surface
    {
        public double roughness => 100.0;

        public RColor diffuse(Vector pos)
        {
            return RColor.white;
        }

        public double reflect(Vector pos)
        {
            return 0.7;
        }

        public RColor specular(Vector pos)
        {
            return RColor.grey;
        }
    }
}
