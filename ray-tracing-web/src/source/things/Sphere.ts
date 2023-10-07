import { Ray } from '../Ray';
import { Thing } from '../Thing';
import { Vector } from '../Vector';
import { Surface } from '../Surface';
import { Intersection } from '../Intersection';

export class Sphere implements Thing {

    private readonly radius2 = this.radius * this.radius;

    public constructor(
        public readonly center: Vector,
        public readonly radius: number,
        public readonly surface: Surface,
    ) {
    }

    public normal(pos: Vector): Vector {
        return pos.minus(this.center).norm();
    }

    public intersect(ray: Ray): Intersection | null {
        const eo = this.center.minus(ray.start);
        const v = eo.dot(ray.dir);
        let dist = 0;

        if (v >= 0) {
            let disc = this.radius2 - (eo.dot(eo) - v * v);

            if (disc >= 0) {
                dist = v - Math.sqrt(disc);
            }
        }

        if (dist === 0) {
            return null;
        }

        return new Intersection(this, ray, dist);
    }

}
