import { Item } from "./Item";

export class Resource implements Item {
  constructor(name: string,
              type: string,
              description: string,
              rarity: number,
              value: number,
              imagePath: string = "/icons/Unknown_Icon.png",
              maximumInInventory: number = 10,
              maximumInStorage: number = 100,
              resourceType: string) {
    this.name = name;
    this.type = type;
    this.description = description;
    this.rarity = rarity;
    this.value = value;
    this.imagePath = imagePath;
    this.maximumInInventory = maximumInInventory;
    this.maximumInStorage = maximumInStorage;
    this.resourceType = resourceType;
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
  resourceType: string;

  static FromParsedBody(json: any): Resource {
    return new Resource(
      json["name"],
      json["type"],
      json["description"],
      json["rarity"],
      json["value"],
      json["imagePath"],
      json["maximumInInventory"],
      json["maximumInStorage"],
      json["resourceType"],
    );
  }
}