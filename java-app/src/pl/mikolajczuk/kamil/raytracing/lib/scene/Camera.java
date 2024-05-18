package pl.mikolajczuk.kamil.raytracing.lib.scene;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;

public class Camera {
    private static final Vector down = new Vector(0.0, -1.0, 0.0);

    public final Vector position;
    public final Vector lookAt;

    public final Vector forward;
    public final Vector right;
    public final Vector up;

    public final double zoom;

    public Camera(Vector position, Vector lookAt, double zoom) {
        this.position = position;
        this.lookAt = lookAt;
        this.zoom = zoom;

        forward = lookAt.minus(position).norm();
        right = forward.cross(down).norm();
        up = forward.cross(right).norm();
    }
}
