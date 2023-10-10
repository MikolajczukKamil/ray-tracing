using System;
using ray_tracer.common;
using ray_tracer.scene;


namespace ray_tracer.elements.surfaces
{
    public class Shiny : Surface
    {
        public double roughness => 250.0;

        public Color diffuse(Vector pos)
        {
            return Color.white;
        }

        public double reflect(Vector pos)
        {
            return 0.7;
        }

        public Color specular(Vector pos)
        {
            return Color.grey;
        }
    }
}
