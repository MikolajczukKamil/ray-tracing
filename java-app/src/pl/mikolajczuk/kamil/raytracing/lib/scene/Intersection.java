package pl.mikolajczuk.kamil.raytracing.lib.scene;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;

public class Intersection {
    public final Thing thing;
    public final Ray ray;
    public final Vector norm;
    public final double dist;

    public Intersection(Thing thing, Ray ray, Vector norm, double dist) {
        this.thing = thing;
        this.ray = ray;
        this.norm = norm;
        this.dist = dist;
    }
}
