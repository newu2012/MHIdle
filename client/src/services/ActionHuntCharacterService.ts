import { injectable } from "inversify";
import { Ref, ref } from "vue";
import { Action } from "../models/Action";
import container from "../inversify.config";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { HuntService } from "./HuntService";

@injectable()
export class ActionHuntCharacterService extends ActionService {
  constructor() {
    super();
    this.action = ref(this.availableActions.idle());
  }

  RestartActionTimer() {
    const actionHuntCharacterService =
      ref(container.get<ActionHuntCharacterService>(TYPES.ActionHuntCharacterService)).value;
    actionHuntCharacterService.elapsed = 0;
  }

  availableActions = {
    idle: this.Idle,
    attack: this.Attack,
  };

  Idle() {
    return new Action(
      "Idle",
      undefined,
      () => {
      });
  }

  Attack() {
    return new Action(
      "Attacking",
      3 * 1000,
      () => {
        const huntService = ref(container.get<HuntService>(TYPES.HuntService)).value;
        return huntService.Attack();
      });
  }
}