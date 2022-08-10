import { Resource } from "./Resource";

export class ResourceHerb implements Resource {
  constructor(id: number,
              name: string,
              description: string,
              rarity: number,
              value: number,
              imagePath: string = "/icons/Herb_Icon_Green.png",
              maximumInInventory: number = 10,
              maximumInStorage: number = 10000) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.rarity = rarity;
    this.value = value;
    this.imagePath = imagePath;
    this.maximumInInventory = maximumInInventory;
    this.maximumInStorage = maximumInStorage;
  }

  id: number;
  name: string;
  description: string;
  rarity: number
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}