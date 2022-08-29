import { Item } from "./Item";

export class Instrument extends Item {
  constructor(name: string, type: string, description: string, rarity: number, value: number, imagePath: string, maximumInInventory: number, maximumInStorage: number, instrumentType: string, instrumentLevel: number, chanceToBreak: number) {
    super(name, type, description, rarity, value, imagePath, maximumInInventory, maximumInStorage);
    this.instrumentType = instrumentType;
    this.instrumentLevel = instrumentLevel;
    this.chanceToBreak = chanceToBreak;
  }

  instrumentType: string;
  instrumentLevel: number;
  chanceToBreak: number;

  static FromParsedBody(json: any): Instrument {
    return new Instrument(
      json["name"],
      json["type"],
      json["description"],
      json["rarity"],
      json["value"],
      json["imagePath"],
      json["maximumInInventory"],
      json["maximumInStorage"],
      json["instrumentType"],
      json["instrumentLevel"],
      json["chanceToBreak"],
    );
  }
}