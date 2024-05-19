package pl.mikolajczuk.kamil.raytracing.lib;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;
import pl.mikolajczuk.kamil.raytracing.lib.scene.*;

import java.util.Optional;

public class RayTracer {
    private final RColor background = RColor.black;
    private final RColor defaultColor = RColor.black;

    private final Scene scene;
    private final int maxDepth;

    public RayTracer(Scene scene) {
        this.scene = scene;
        this.maxDepth = 10;
    }

        /*
    public Bitmap fragmentRender(int screenWidth, int screenHeight, int fragmentIndex, int fragments) {
        var image = new Bitmap(
                screenWidth,
                fragmentIndex == fragments - 1 ?
                        screenHeight - fragmentIndex * (screenHeight / fragments) :
                        screenHeight / fragments
        );

        var camera = scene.camera;

        var up = camera.up.times(camera.zoom);
        var right = camera.right.times(camera.zoom);

        var minAxis = Math.min(screenWidth, screenHeight);

        var start = fragmentIndex * (screenHeight / fragments);

        for (var y = 0; y < image.Height; y++) {
            double recenterY = ((start + y) - (minAxis / 2.0)) / 2.0 / minAxis;
            var pointY = camera.forward.plus(up.times(-recenterY));

            for (var x = 0; x < screenWidth; x++) {
                double recenterX = (x - (minAxis / 2.0)) / 2.0 / minAxis;

                var point = pointY.plus(right.times(recenterX)).norm();
                var ray = new Ray(camera.position, point);
                var color = traceRay(ray, scene, 0);

                image.SetPixel(x, y, color.toDrawingColor());
            }
        }

        return image;
    }
     */

    private Optional<Intersection> closestIntersection(Ray ray, Scene scene) {
        double closest = Double.POSITIVE_INFINITY;
        Optional<Intersection> closestInter = Optional.empty();

        for (Thing thing : scene.things) {
            var inter = thing.intersect(ray);

            if (inter.isPresent() && inter.get().dist < closest) {
                closestInter = inter;
                closest = inter.get().dist;
            }
        }

        return closestInter;
    }

    private RColor traceRay(Ray ray, Scene scene, int depth) {
        var isect = closestIntersection(ray, scene);

        if (isect.isEmpty()) return background;

        var direction = isect.get().ray.direction;
        var position = direction.times(isect.get().dist).plus(isect.get().ray.origin);
        var reflectDir = direction.minus(
                isect.get().norm.times(2 * isect.get().norm.dot(direction))
        );

        var naturalColor = background.plus(
                getNaturalColor(isect.get().thing, position, isect.get().norm, reflectDir, scene)
        );

        var reflectedColor = (depth >= maxDepth) ?
                RColor.grey :
                getReflectionColor(isect.get().thing, position, reflectDir, scene, depth);

        return naturalColor.plus(reflectedColor);
    }

    private RColor getReflectionColor(Thing thing, Vector position, Vector reflectDir, Scene scene, int depth) {
        return traceRay(new Ray(position, reflectDir), scene, depth + 1).scale(thing.getSurface().reflect(position));
    }

    private RColor getNaturalColor(Thing thing, Vector position, Vector norm, Vector reflectDir, Scene scene) {
        var color = defaultColor;
        var thingDiffuse = thing.getSurface().diffuse(position);
        var thingSpecular = thing.getSurface().specular(position);

        for (Light light : scene.lights) {
            var toLightDirection = light.position.minus(position);
            var toLightDirectionNorm = toLightDirection.norm();
            var closest = closestIntersection(new Ray(position, toLightDirectionNorm), scene);

            var isInShadow = closest.isPresent() && (closest.get().dist <= toLightDirection.mag());

            if (!isInShadow) {
                var illum = toLightDirectionNorm.dot(norm);
                var lColor = illum > 0 ? light.color.scale(illum) : defaultColor;

                var specular = toLightDirectionNorm.dot(reflectDir.norm());
                var sColor = specular > 0 ? light.color.scale(Math.pow(specular, thing.getSurface().getRoughness())) : defaultColor;

                color = color.plus(lColor.times(thingDiffuse).plus(sColor.times(thingSpecular)));
            }
        }

        return color;
    }
}
