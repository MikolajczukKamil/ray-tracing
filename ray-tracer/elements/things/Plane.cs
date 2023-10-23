using ray_tracer.common;
using ray_tracer.scene;

namespace ray_tracer.elements.things
{
    public class Plane : Thing
    {
        public Surface surface { get; set; }

        public readonly Vector norm;
        public readonly double offset;

        public Plane(Vector norm, double offset, Surface surface)
        {
            this.norm = norm;
            this.offset = offset;
            this.surface = surface;
        }

        public Intersection intersect(Ray ray)
        {
            var normRayDirectionDot = norm.dot(ray.direction);

            if (normRayDirectionDot > double.Epsilon) return null;

            var dist = -(norm.dot(ray.origin) + offset) / normRayDirectionDot;

            return new Intersection(this, ray, norm, dist);
        }
    }
}
