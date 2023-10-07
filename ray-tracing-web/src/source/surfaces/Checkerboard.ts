import { Color } from '../Color';
import { Vector } from '../Vector';
import { Surface } from '../Surface';

export class Checkerboard implements Surface {
    public readonly roughness = 150

    public diffuse(pos: Vector): Color {
        if ((Math.floor(pos.z) + Math.floor(pos.x)) % 2 !== 0) {
            return Color.white;
        }

        return Color.black;

    }

    public specular(pos: Vector): Color {
        return Color.white;
    }

    public reflect(pos: Vector): number {
        if ((Math.floor(pos.z) + Math.floor(pos.x)) % 2 !== 0) {
            return 0.1;
        }

        return 0.7;
    }
}
