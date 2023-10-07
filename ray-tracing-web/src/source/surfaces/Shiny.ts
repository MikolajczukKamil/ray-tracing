import { Color } from '../Color';
import { Vector } from '../Vector';
import { Surface } from '../Surface';

export class Shiny implements Surface {
    public readonly roughness = 250

    public diffuse(pos: Vector): Color {
        return Color.white;
    }

    public specular(pos: Vector): Color {
        return Color.grey;
    }

    public reflect(pos: Vector): number {
        return 0.7;
    }
}
