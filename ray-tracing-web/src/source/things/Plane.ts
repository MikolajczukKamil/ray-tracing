import { Ray } from '../Ray';
import { Thing } from '../Thing';
import { Vector } from '../Vector';
import { Surface } from '../Surface';
import { Intersection } from '../Intersection';

export class Plane implements Thing {
    constructor(
        public readonly norm: Vector,
        public readonly offset: number,
        public readonly surface: Surface,
    ) {
    }

    public normal(pos: Vector): Vector {
        return this.norm;
    }

    public intersect(ray: Ray): Intersection | null {
        let denom = this.norm.dot(ray.dir);

        if (denom > 0) {
            return null;
        }

        let dist = (this.norm.dot(ray.start) + this.offset) / (-denom);

        return new Intersection(this, ray, dist);

    }
}
