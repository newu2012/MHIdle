import { ResourceHerb } from "../models/items/ResourceHerb";
import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { RandomService } from "./RandomService";
import { ref } from "vue";
import container from "../inversify.config";
import { Action } from "../models/Action";
import { Character } from "../models/character/Character";

@injectable()
export class RegionService {
  actionService: ActionService;
  character: Character;

  constructor(
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.Character) character: Character) {
    this.actionService = actionService;
    this.character = character;
    this.AutoGather();
  }

  AutoGather() {
    this.actionService.SetCurrentAction(new Action(
      "Gather herbs",
      10 * 1000,
      this.GatherHerbs, this.character));
  }

  GatherHerbs(...args: any[]) {
    const character = args[0][0];
    const amount = ref(container.get<RandomService>(TYPES.RandomService)).value
      .GetRandIntBetween({ from: 0, to: 3 });
    character.currentInventory
      .AddItem(new ResourceHerb(
          1,
          "simpleHerb",
          "Herb",
          1),
        amount);
  }
}