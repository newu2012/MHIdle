import { Equipment } from "./Equipment";

export class Armor implements Equipment {
  id: number;
  name: string;
  description: string;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}