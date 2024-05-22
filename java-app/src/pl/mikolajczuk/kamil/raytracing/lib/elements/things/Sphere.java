package pl.mikolajczuk.kamil.raytracing.lib.elements.things;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;
import pl.mikolajczuk.kamil.raytracing.lib.scene.*;

import java.util.Optional;

public class Sphere implements Thing {
    private final Surface surface;

    public Surface getSurface() {
        return surface;
    }

    public final Vector center;
    public final double radius2;

    public Sphere(Vector center, double radius, Surface surface) {
        this.center = center;
        this.radius2 = radius * radius;
        this.surface = surface;
    }


    public Optional<Intersection> intersect(Ray ray) {
        var eo = center.minus(ray.origin);
        var v = eo.dot(ray.direction);

        if (v >= 0) {
            var disc = radius2 - (eo.dot(eo) - v * v);

            if (disc >= 0) {
                var dist = v - Math.sqrt(disc);
                if (dist <= 0) return Optional.empty();

                var p = ray.origin.plus(ray.direction.times(dist));

                return Optional.of(new Intersection(this, ray, p.minus(center).norm(), dist));
            }
        }

        return Optional.empty();
    }
}
