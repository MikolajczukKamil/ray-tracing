using ray_tracer.common;
using System;

namespace ray_tracer.scene
{
    public interface Surface
    {
        double roughness { get; }

        RColor diffuse(Vector pos);

        RColor specular(Vector pos);

        double reflect(Vector pos);
    }
}
