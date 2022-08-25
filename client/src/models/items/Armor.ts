import { Equipment } from "./Equipment";

export class Armor implements Equipment {
  name: string;
  type: string;
  description: string;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}