import { Vector } from "./Vector";

export class Camera {
    private static readonly down = new Vector(0.0, -1.0, 0.0);

    public readonly forward: Vector = this.lookAt.minus(this.position).norm();
    public readonly right: Vector = this.forward.cross(Camera.down).norm().times(1.5);
    public readonly up: Vector = this.forward.cross(this.right).norm().times(1.5);

    public constructor(
        public readonly position: Vector,
        private readonly lookAt: Vector,
    ) {
    }
}
