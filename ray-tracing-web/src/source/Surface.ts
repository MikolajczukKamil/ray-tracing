import { Vector } from './Vector'
import { Color } from './Color'

export interface Surface {
    readonly roughness: number;

    diffuse(pos: Vector): Color;

    specular(pos: Vector): Color;

    reflect(pos: Vector): number;

}