import { Equipment } from "./Equipment";

export class Weapon implements Equipment {
  name: string;
  type: string;
  description: string;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}