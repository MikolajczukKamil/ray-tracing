import { Color } from "./Color";
import { Vector } from "./Vector";

export class Light {
    public constructor(
        public readonly pos: Vector,
        public readonly color: Color,
    ) {
    }
}
