import { Thing } from "./Thing";
import { Light } from "./Light";
import { Camera } from "./Camera";

export class Scene {
    public constructor(
        public readonly things: Thing[],
        public readonly lights: Light[],
        public readonly camera: Camera,
    ) {
    }
}
