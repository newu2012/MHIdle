import { injectable } from "inversify";
import { ref } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import TYPES from "../types";
import { RegionService } from "./RegionService";
import { ActionHuntCharacterService } from "./ActionHuntCharacterService";
import { Monster } from "../models/region/Monster";
import { ActionMainService } from "./ActionMainService";

@injectable()
export class HuntService {
  monster?: Monster;
  monsterCurrentHealth?: number;

  Hunt() {
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;
    const actionHuntCharacterService = ref(container.get<ActionHuntCharacterService>(TYPES.ActionHuntCharacterService)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;

    if (regionService.activeEvent === undefined ||
      regionService.activeEvent?.type !== "Monster") {
      console.log(`No active monster to hunt found`);
      actionHuntCharacterService.SetCurrentAction(actionHuntCharacterService.availableActions.idle());
      return;
    } else if (this.monster === undefined) {
      this.monster = regionService.activeEvent as Monster;
      this.monsterCurrentHealth = this.monster.startingHealth;
    }

    actionHuntCharacterService.SetCurrentAction(actionHuntCharacterService.availableActions.attack());
  }

  RunAway() {
    this.monster = undefined;
    this.monsterCurrentHealth = undefined;
  }

  Attack() {
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;
    const actionHuntCharacterService = ref(container.get<ActionHuntCharacterService>(TYPES.ActionHuntCharacterService)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;

    if (this.monster === undefined || this.monsterCurrentHealth === undefined) {
      this.monster = regionService.activeEvent as Monster;
      this.monsterCurrentHealth = this.monster.startingHealth;
    }

    this.monsterCurrentHealth -= 5;

    if (this.monsterCurrentHealth <= 0) {
      this.monster = undefined;
      actionHuntCharacterService.SetCurrentAction(actionHuntCharacterService.availableActions.idle());
      actionMainService.SetCurrentAction(actionMainService.availableActions.gather());
      return;
    }
  }
}