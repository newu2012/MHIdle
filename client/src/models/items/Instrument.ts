import { Item } from "./Item";

export class Instrument implements Item {
  constructor(name: string,
              type: string,
              description: string,
              rarity: number,
              value: number,
              imagePath: string = "/icons/Unknown_Icon.png",
              maximumInInventory: number = 10,
              maximumInStorage: number = 100,
              instrumentType: string,
              instrumentLevel: number,
              chanceToBreak: number,
  ) {
    this.name = name;
    this.type = type;
    this.description = description;
    this.rarity = rarity;
    this.value = value;
    this.imagePath = imagePath;
    this.maximumInInventory = maximumInInventory;
    this.maximumInStorage = maximumInStorage;
    this.instrumentType = instrumentType;
    this.instrumentLevel = instrumentLevel;
    this.chanceToBreak = chanceToBreak;
  }

  name: string;
  type: string;
  description: string;
  rarity: number;
  value: number;
  imagePath: string;
  //  TODO Make maximum's upgradable somehow
  maximumInInventory: number;
  maximumInStorage: number;
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