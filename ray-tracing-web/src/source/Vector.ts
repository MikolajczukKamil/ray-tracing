export class Vector {
    public constructor(
        public readonly x: number,
        public readonly y: number,
        public readonly z: number,
    ) {
    }

    public times(k: number): Vector {
        return new Vector(k * this.x, k * this.y, k * this.z);
    }

    public minus(other: Vector): Vector {
        return new Vector(this.x - other.x, this.y - other.y, this.z - other.z);
    }

    public plus(other: Vector): Vector {
        return new Vector(this.x + other.x, this.y + other.y, this.z + other.z);
    }

    public dot(other: Vector): number {
        return this.x * other.x + this.y * other.y + this.z * other.z;
    }

    public mag2(): number {
        return this.x * this.x + this.y * this.y + this.z * this.z;
    }

    public mag(): number {
        return Math.sqrt(this.mag2());
    }

    public norm(): Vector {
        return this.times(1 / this.mag());
    }

    public cross(other: Vector): Vector {
        return new Vector(
            this.y * other.z - this.z * other.y,
            this.z * other.x - this.x * other.z,
            this.x * other.y - this.y * other.x,
        );
    }
}
