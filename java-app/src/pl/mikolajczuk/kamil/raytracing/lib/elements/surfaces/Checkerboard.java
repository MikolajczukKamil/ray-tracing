package pl.mikolajczuk.kamil.raytracing.lib.elements.surfaces;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;
import pl.mikolajczuk.kamil.raytracing.lib.scene.*;

public class Checkerboard implements Surface {
    public double getRoughness() {
        return 150.0;
    }

    public RColor diffuse(Vector pos) {
        if (isBlackField(pos)) return RColor.white;

        return RColor.black;
    }

    public double reflect(Vector pos) {
        if (isBlackField(pos)) return 0.1;

        return 0.7;
    }

    public RColor specular(Vector pos) {
        return RColor.white;
    }

    private boolean isBlackField(Vector pos) {
        return (int) (Math.floor(pos.z) + Math.floor(pos.x)) % 2 != 0;
    }
}
