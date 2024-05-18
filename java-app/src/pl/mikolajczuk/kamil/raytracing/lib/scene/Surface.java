package pl.mikolajczuk.kamil.raytracing.lib.scene;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;

public interface Surface {
    double getRoughness();

    RColor diffuse(Vector pos);

    RColor specular(Vector pos);

    double reflect(Vector pos);
}
