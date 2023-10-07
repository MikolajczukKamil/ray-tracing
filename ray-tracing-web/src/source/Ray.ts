import { Vector } from './Vector';

export class Ray {
    constructor(
        public readonly start: Vector,
        public readonly dir: Vector,
    ) {
    }
}