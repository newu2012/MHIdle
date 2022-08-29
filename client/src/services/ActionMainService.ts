import { injectable } from "inversify";
import { ref } from "vue";
import { Action } from "../models/Action";
import container from "../inversify.config";
import TYPES from "../types";
import { RegionService } from "./RegionService";
import { CraftService } from "./CraftService";
import { HuntService } from "./HuntService";
import { ActionService } from "./ActionService";

@injectable()
export class ActionMainService extends ActionService {
  constructor() {
    super();
    this.action = ref(this.availableActions.idle());
  }

  RestartActionTimer() {
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;
    actionMainService.elapsed = 0;
  }

  availableActions = {
    idle: this.Idle,
    explore: this.Explore,
    gather: this.Gather,
    craft: this.Craft,
    hunt: this.Hunt,
  };

  Idle() {
    return new Action(
      "Idle",
      undefined,
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

  Hunt() {
    return new Action(
      "Hunting",
      undefined,
      () => {
        const huntService = ref(container.get<HuntService>(TYPES.HuntService)).value;
        return huntService.Hunt();
      });
  }
}