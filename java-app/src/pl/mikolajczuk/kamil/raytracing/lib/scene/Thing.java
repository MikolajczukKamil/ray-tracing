package pl.mikolajczuk.kamil.raytracing.lib.scene;

import java.util.Optional;

public interface Thing {
    Surface getSurface();

    Optional<Intersection> intersect(Ray ray);
}

