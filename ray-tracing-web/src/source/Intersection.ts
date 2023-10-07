import { Ray } from './Ray'
import { Thing } from './Thing'

export class Intersection {
    constructor(
        readonly thing: Thing,
        readonly ray: Ray,
        readonly dist: number,
    ) {
    }
}
