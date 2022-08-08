import { ResourceHerb } from "../models/items/ResourceHerb";
import { Character } from "../models/character/Character";
import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { Action } from "../models/Action";

@injectable()
export class RegionService {
  character: Character;
  actionService: ActionService;

  constructor(
    @inject(TYPES.Character) character: Character,
    @inject(TYPES.ActionService) actionService: ActionService,
  ) {
    this.character = character;
    this.actionService = actionService;
    this.AutoGather();
  }

  AutoGather() {
    //  TODO Move random function to calculating function
    this.actionService.SetCurrentAction(new Action(
      "Gather herbs",
      10 * 1000,
      this.GatherHerbs, this.character, Math.round((Math.random() * 3) + 1)));
  }

  GatherHerbs(...args: any[]) {
    const character = args[0][0];
    const amount = args[0][1];
    character.currentInventory
      .AddItem(new ResourceHerb(
          1,
          "simpleHerb",
          "Herb",
          1),
        amount);
  }
}