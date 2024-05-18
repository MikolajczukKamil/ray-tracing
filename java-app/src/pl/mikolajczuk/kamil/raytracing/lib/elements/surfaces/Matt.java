package pl.mikolajczuk.kamil.raytracing.lib.elements.surfaces;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;
import pl.mikolajczuk.kamil.raytracing.lib.scene.*;

public class Matt implements Surface {
    public double getRoughness() {
        return 10.0;
    }

    public RColor diffuse(Vector pos) {
        return RColor.white;
    }

    public double reflect(Vector pos) {
        return 0.05;
    }

    public RColor specular(Vector pos) {
        return RColor.grey;
    }
}
