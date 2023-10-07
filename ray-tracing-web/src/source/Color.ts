abstract class BaseColor {
    public readonly r: number;
    public readonly g: number;
    public readonly b: number;

    public constructor(r: number, g: number, b: number) {
        this.r = this.norm(r)
        this.g = this.norm(g)
        this.b = this.norm(b)
    }

    protected abstract norm(v: number): number
}

export class Color8bit extends BaseColor {
    protected override norm(v: number): number {
        return Math.max(0, Math.min(255, v))
    }
}

export class Color extends BaseColor {
    public static readonly white = new Color(1.0, 1.0, 1.0);
    public static readonly grey = new Color(0.5, 0.5, 0.5);
    public static readonly black = new Color(0.0, 0.0, 0.0);

    protected override norm(v: number): number {
        return Math.max(0, Math.min(1, v))
    }

    public scale(k: number): Color {
        return new Color(k * this.r, k * this.g, k * this.b);
    }

    public plus(other: Color): Color {
        return new Color(this.r + other.r, this.g + other.g, this.b + other.b);
    }

    public times(other: Color): Color {
        return new Color(this.r * other.r, this.g * other.g, this.b * other.b);
    }

    public toDrawingColor(): Color8bit {
        return new Color8bit(this.r * 255, this.g * 255, this.b * 255)
    }
}
