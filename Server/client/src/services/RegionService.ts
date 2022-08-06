import { ResourceHerb } from "../models/items/ResourceHerb";
import { Character } from "../models/character/Character";
import { inject, injectable } from "inversify";
import TYPES from "../types";

@injectable()
export class RegionService {
  @inject(TYPES.Character) character: Character;

  GatherHerbs() {
    this.character.currentInventory
      .AddItem(new ResourceHerb(
          1,
          "simpleHerb",
          "Herb",
          5,
          1),
        1);
    console.log(this.character.currentInventory);

    return this.character.currentInventory
      .CountItems("simpleHerb");
  }
}