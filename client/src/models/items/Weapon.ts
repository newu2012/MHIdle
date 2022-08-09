import { Equipment } from "./Equipment";

export class Weapon implements Equipment {
  name: string;
  description: string;
  id: number;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}