import { ResourceHerb } from "../models/items/ResourceHerb";
import { Character } from "../models/character/Character";
import { inject, injectable } from "inversify";
import TYPES from "../types";

@injectable()
export class RegionService {
  @inject(TYPES.Character) character: Character;

  constructor() {
    this.AutoGather();
  }

  AutoGather() {
    setInterval(() => {
      this.GatherHerbs(Math.round((Math.random() * 3) + 1));
    }, 10000);
  }

  GatherHerbs(amount: number = 1) {
    this.character.currentInventory.value
      .AddItem(new ResourceHerb(
          1,
          "simpleHerb",
          "Herb",
          1),
        amount);
  }
}