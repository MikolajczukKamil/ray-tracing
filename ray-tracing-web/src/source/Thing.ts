import { Ray } from './Ray'
import { Vector } from './Vector'
import { Surface } from './Surface'
import { Intersection } from './Intersection'

export interface Thing {
    readonly surface: Surface;

    intersect(ray: Ray): Intersection | null;

    normal(pos: Vector): Vector;
}
