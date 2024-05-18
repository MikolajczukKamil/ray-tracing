package pl.mikolajczuk.kamil.raytracing.lib.scene;

import pl.mikolajczuk.kamil.raytracing.lib.common.Vector;

public class Ray {
    public final Vector origin;
    public final Vector direction;

    public Ray(Vector origin, Vector direction) {
        this.origin = origin;
        this.direction = direction;
    }
}
