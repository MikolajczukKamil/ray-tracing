namespace ray_tracer.scene
{
    public interface Thing
    {
        Surface surface { get; }

        Intersection intersect(Ray ray); // Optional
    }
}
