using ray_tracer.common;
using System;

namespace ray_tracer.scene
{
    public interface Surface
    {
        double roughness { get; }

        Color diffuse(Vector pos);

        Color specular(Vector pos);

        double reflect(Vector pos);
    }
}
