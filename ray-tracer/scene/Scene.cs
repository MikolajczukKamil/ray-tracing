using ray_tracer.common;

namespace ray_tracer.scene
{
    public class Scene
    {
        public readonly Thing[] things;
        public readonly Light[] lights;
        public readonly Camera camera;

        public Scene(Thing[] things, Light[] lights, Camera camera)
        {
            this.things = things;
            this.lights = lights;
            this.camera = camera;
        }
    }
}
