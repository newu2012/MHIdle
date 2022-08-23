import { Item } from "./Item";

export class Resource implements Item {
  constructor(id: number,
              type: string,
              name: string,
              description: string,
              rarity: number,
              value: number,
              imagePath: string = "/icons/Unknown_Icon.png",
              maximumInInventory: number = 10,
              maximumInStorage: number = 10000) {
    this.id = id;
    this.type = type;
    this.name = name;
    this.description = description;
    this.rarity = rarity;
    this.value = value;
    this.imagePath = imagePath;
    this.maximumInInventory = maximumInInventory;
    this.maximumInStorage = maximumInStorage;
  }

  id: number;
  type: string;
  name: string;
  description: string;
  rarity: number
  value: number;
  imagePath: string;
  //  TODO Make maximum's upgradable somehow
  maximumInInventory: number;
  maximumInStorage: number;
}