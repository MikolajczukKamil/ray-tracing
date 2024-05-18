package pl.mikolajczuk.kamil.raytracing.lib.elements.things;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;
import pl.mikolajczuk.kamil.raytracing.lib.scene.*;

import java.util.Optional;

public class Plane implements Thing {
    private final Surface surface;

    public Surface getSurface() {
        return this.surface;
    }

    public final Vector norm;
    public final double offset;

    public Plane(Vector norm, double offset, Surface surface) {
        this.norm = norm;
        this.offset = offset;
        this.surface = surface;
    }

    public Optional<Intersection> intersect(Ray ray) {
        var normRayDirectionDot = norm.dot(ray.direction);

        if (normRayDirectionDot > 0) return Optional.empty();

        var dist = -(norm.dot(ray.origin) + offset) / normRayDirectionDot;

        return Optional.of(new Intersection(this, ray, norm, dist));
    }
}

    