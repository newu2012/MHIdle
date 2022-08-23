import { injectable } from "inversify";
import { ObjectWithProportion as owp } from "../models/ObjectWithProportion";

@injectable()
export class RandomService {
  GetRandIntBetween({ from = 0, to = 1 }): number {
    return Math.round((Math.random() * (to - from)) + from);
  }

  GetRandFromProportion<T>(objects: owp<T>[]): owp<T> {
    const maxValue = objects.reduce((sum, o) => sum + o.value, 0);

    const random = Math.random() * maxValue;
    let currentMaxValue = 0;
    for (let i = 0; i < objects.length; i++) {
      currentMaxValue += objects[i].value;
      if (currentMaxValue >= random) {
        return objects[i];
      }
    }

    return objects[0];
  }
}