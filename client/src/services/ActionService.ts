import { injectable } from "inversify";
import { Ref, ref } from "vue";
import { Action } from "../models/Action";
import container from "../inversify.config";
import TYPES from "../types";
import { RegionService } from "./RegionService";
import { CraftService } from "./CraftService";

@injectable()
export class ActionService {
  action: Ref<Action>;
  elapsed = ref(0);
  lastTime: number;
  handle: number;
  update: Function = this.Update.bind(this);

  Update() {
    if (this.elapsed.value >= this.action.value?.duration) {
      this.RestartActionTimer();
      this.lastTime = performance.now();
      this.action.value.Execute();
    } else {
      const time = performance.now();
      this.elapsed.value += Math.min(time - this.lastTime, this.action.value?.duration! - this.elapsed.value);
      this.lastTime = time;
    }

    this.handle = requestAnimationFrame(<FrameRequestCallback>this.update);
  }

  SetCurrentAction(action: Action) {
    this.action = ref(action);
    this.RestartActionTimer();
    this.lastTime = performance.now();
    this.update();
  }

  RestartActionTimer() {
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    actionService.elapsed = 0;
  }

  availableActions = {
    explore: this.Explore,
    gather: this.Gather,
    craft: this.Craft,
  };

  Explore(duration: number) {
    return new Action(
      "Exploring",
      duration,
      () => {
        const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
        return regionService.Explore();
      });
  }

  Gather(duration: number) {
    return new Action(
      "Gathering",
      duration,
      () => {
        const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
        return regionService.Gather();
      });
  }

  Craft(duration: number) {
    return new Action(
      "Crafting",
      duration,
      () => {
        const craftService = ref(container.get<CraftService>(TYPES.CraftService)).value;
        return craftService.Craft();
      });
  }
}