export abstract class Item {
  constructor(name: string, type: string, description: string, rarity: number, value: number, imagePath: string, maximumInInventory: number, maximumInStorage: number) {
    this.name = name;
    this.type = type;
    this.description = description;
    this.rarity = rarity;
    this.value = value;
    this.imagePath = imagePath;
    this.maximumInInventory = maximumInInventory;
    this.maximumInStorage = maximumInStorage;
  }

  name: string;
  type: string;
  description?: string;
  rarity: number;
  value: number;
  imagePath: string;
  //  TODO Make maximum's upgradable somehow
  maximumInInventory: number;
  maximumInStorage: number;
}