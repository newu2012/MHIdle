import { Resource } from "./Resource";

export class ResourceHerb implements Resource {
  constructor(id: number,
              name: string,
              description: string,
              rarity: number,
              value: number,
              maximumInInventory: number = 10,
              maximumInStorage: number = 10000) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.rarity = rarity;
    this.value = value;
    this.maximumInInventory = maximumInInventory;
    this.maximumInStorage = maximumInStorage;
  }

  id: number;
  name: string;
  description: string;
  rarity: number
  value: number;
  maximumInInventory: number;
  maximumInStorage: number;
}