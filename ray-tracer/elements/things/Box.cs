using System;
using System.Collections.Generic;

using ray_tracer.common;
using ray_tracer.scene;

namespace ray_tracer.elements.things
{
    public class Box : Thing
    {
        public Surface surface { get; set; }

        public readonly Vector position;
        public readonly Vector size;

        private readonly List<Triangle> sides = new List<Triangle>(12);

        public Box(Vector position, Vector size, Surface surface)
        {
            this.position = position;
            this.size = size;
            this.surface = surface;

            var sx = new Vector(size.x, 0, 0);
            var sy = new Vector(0, size.y, 0);
            var sz = new Vector(0, 0, size.z);

            var v1 = position;
            var v2 = position.plus(sx);
            var v3 = v2.plus(sy);
            var v4 = v1.plus(sy);
            var v5 = v1.plus(sz);
            var v6 = v2.plus(sz);
            var v7 = v3.plus(sz);
            var v8 = v4.plus(sz);

            //Vector[] vs = { v1, v2, v3, v4, v5, v6, v7, v8 };

            //for (int i = 0; i < vs.Length; i++)
            //    for (int j = i + 1; j < vs.Length; j++)
            //        for (int k = j + 1; k < vs.Length; k++)
            //            sides.Add(new Triangle(vs[i], vs[j], vs[k], surface));

            sides.Add(new Triangle(v1, v2, v3, surface));
            sides.Add(new Triangle(v1, v4, v3, surface));
            sides.Add(new Triangle(v5, v6, v7, surface));
            sides.Add(new Triangle(v5, v8, v7, surface));

            sides.Add(new Triangle(v2, v6, v7, surface));
            sides.Add(new Triangle(v2, v3, v7, surface));
            sides.Add(new Triangle(v1, v5, v8, surface));
            sides.Add(new Triangle(v1, v4, v8, surface));

            sides.Add(new Triangle(v1, v2, v6, surface));
            sides.Add(new Triangle(v1, v5, v6, surface));
            sides.Add(new Triangle(v4, v3, v7, surface));
            sides.Add(new Triangle(v4, v8, v7, surface));
        }

        public Intersection intersect(Ray ray)
        {
            // ClosestSideIntersection

            Intersection closest = null;

            foreach (var side in sides)
            {
                var intersection = side.intersect(ray);

                if (intersection != null && (closest == null || closest.dist > intersection.dist)) closest = intersection;
            }

            return closest;
        }

        public Vector normal(Vector position)
        {
            throw new Exception("Unexpected Box normal, box return Triangle Intersection");
        }
    }
}
