import { ResourceHerb } from "../models/items/ResourceHerb";
import { Character } from "../models/character/Character";
import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { Action } from "../models/Action";
import { RandomService } from "./RandomService";
import { ref } from "vue";
import container from "../inversify.config";

@injectable()
export class RegionService {
  character: Character;
  actionService: ActionService;
  randomService: RandomService;

  constructor(
    @inject(TYPES.Character) character: Character,
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.RandomService) randomService: RandomService,
  ) {
    this.character = character;
    this.actionService = actionService;
    this.randomService = randomService;
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