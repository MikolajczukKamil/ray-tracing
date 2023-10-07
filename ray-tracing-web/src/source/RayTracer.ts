// @ts-nocheck

import { Ray } from "./Ray";
import { Scene } from './Scene';
import { Intersection } from './Intersection';
import { Color } from "./Color";
import { Vector } from "./Vector";
import { Thing } from "./Thing";

export class RayTracer {
    private readonly maxDepth = 5;
    private readonly background = Color.black;
    private readonly defaultColor = Color.black;

    private intersections(ray: Ray, scene: Scene): Intersection | null {
        let closest = +Infinity;
        let closestInter: Intersection | null = null;

        for (let i in scene.things) {
            let inter = scene.things[i].intersect(ray);

            if (inter != null && inter.dist < closest) {
                closestInter = inter;
                closest = inter.dist;
            }
        }

        return closestInter;
    }

    private testRay(ray: Ray, scene: Scene): number | null {
        return this.intersections(ray, scene)?.dist || null;
    }

    private traceRay(ray: Ray, scene: Scene, depth: number): Color {
        let isect = this.intersections(ray, scene);

        if (isect === null) {
            return this.background;
        }

        return this.shade(isect, scene, depth);
    }

    private shade(isect: Intersection, scene: Scene, depth: number) {
        let d = isect.ray.dir;
        let pos = d.times(isect.dist).plus(isect.ray.start);
        let normal = isect.thing.normal(pos);
        let reflectDir = d.minus(normal.times(normal.dot(d) * 2));
        let naturalColor = this.background.plus(this.getNaturalColor(isect.thing, pos, normal, reflectDir, scene));
        let reflectedColor = (depth >= this.maxDepth) ? Color.grey : this.getReflectionColor(isect.thing, pos, normal, reflectDir, scene, depth);

        return naturalColor.plus(reflectedColor);
    }

    private getReflectionColor(thing: Thing, pos: Vector, normal: Vector, rd: Vector, scene: Scene, depth: number) {
        return this.traceRay(new Ray(pos, rd), scene, depth + 1).scale(thing.surface.reflect(pos));
    }

    private getNaturalColor(thing: Thing, pos: Vector, norm: Vector, rd: Vector, scene: Scene) {
        let addLight = (col: Color, light: Color) => {
            let ldis = Vector.minus(1, pos);
            let livec = Vector.norm(ldis);
            let neatIsect = this.testRay({start: pos, dir: livec}, scene);
            let isInShadow = (neatIsect === undefined) ? false : (neatIsect <= Vector.mag(ldis));
            if (isInShadow) {
                return col;
            } else {
                let illum = livec.dot(norm);
                let lcolor = (illum > 0) ? illum.scale(light)
                    : this.defaultColor;

                let specular = Vector.dot(livec, Vector.norm(rd));
                let scolor = (specular > 0) ? Color.scale(Math.pow(specular, thing.surface.roughness), light.color)
                    : Color.defaultColor;
                return Color.plus(col, Color.plus(Color.times(thing.surface.diffuse(pos), lcolor),
                    Color.times(thing.surface.specular(pos), scolor)));
            }
        }
        return scene.lights.reduce(addLight, Color.defaultColor);
    }

    render(scene, ctx, screenWidth, screenHeight) {
        let getPoint = (x, y, camera) => {
            let recenterX = x => (x - (screenWidth / 2.0)) / 2.0 / screenWidth;
            let recenterY = y => -(y - (screenHeight / 2.0)) / 2.0 / screenHeight;
            return Vector.norm(Vector.plus(camera.forward, Vector.plus(Vector.times(recenterX(x), camera.right), Vector.times(recenterY(y), camera.up))));
        }
        for (let y = 0; y < screenHeight; y++) {
            for (let x = 0; x < screenWidth; x++) {
                let color = this.traceRay({start: scene.camera.pos, dir: getPoint(x, y, scene.camera)}, scene, 0);
                let c = color.toDrawingColor();
                ctx.fillStyle = "rgb(" + String(c.r) + ", " + String(c.g) + ", " + String(c.b) + ")";
                ctx.fillRect(x, y, x + 1, y + 1);
            }
        }
    }
}
