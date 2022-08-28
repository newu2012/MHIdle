import { injectable } from "inversify";
import { Ref, ref } from "vue";
import { Action } from "../models/Action";
import container from "../inversify.config";
import TYPES from "../types";
import { RegionService } from "./RegionService";
import { CraftService } from "./CraftService";

@injectable()
export class ActionService {
  constructor() {
    this.action = ref(this.availableActions.idle());
  }

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
    } else if (this.action.value.name !== "Idle") {
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
    idle: this.Idle,
    explore: this.Explore,
    gather: this.Gather,
    craft: this.Craft,
  };

  Idle() {
    return new Action(
      "Idle",
      0,
      () => {
      });
  }

  Explore() {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;

    return new Action(
      "Exploring",
      regionService.GetExploreDuration(),
      () => {
        const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
        return regionService.Explore();
      });
  }

  Gather() {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;

    return new Action(
      "Gathering",
      regionService.GetGatherDuration(),
      () => {
        const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
        return regionService.Gather();
      });
  }

  Craft() {
    const craftService = ref(container.get<CraftService>(TYPES.CraftService)).value;

    return new Action(
      "Crafting",
      craftService.GetCraftDuration(),
      () => {
        const craftService = ref(container.get<CraftService>(TYPES.CraftService)).value;
        return craftService.Craft();
      });
  }
}