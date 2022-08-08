import { injectable } from "inversify";

@injectable()
export class RandomService {
  GetRandIntBetween({ from = 0, to = 1 }): number {
    return Math.round((Math.random() * (to - from)) + from);
  }

  //  TODO Rand with values (0 - 25%, 1 - 50%, 2 - 25%)
}