package pl.mikolajczuk.kamil.raytracing.lib.common;

public class Light {
    public final Vector position;
    public final RColor color;

    public Light(Vector pos, RColor color) {
        this.position = pos;
        this.color = color;
    }
}

