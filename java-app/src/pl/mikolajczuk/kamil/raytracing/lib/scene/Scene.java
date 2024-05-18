package pl.mikolajczuk.kamil.raytracing.lib.scene;

import pl.mikolajczuk.kamil.raytracing.lib.common.*;

public class Scene {
    public final Thing[] things;
    public final Light[] lights;
    public final Camera camera;

    public Scene(Thing[] things, Light[] lights, Camera camera) {
        this.things = things;
        this.lights = lights;
        this.camera = camera;
    }
}
