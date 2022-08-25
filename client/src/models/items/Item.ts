export interface Item {
  name: string;
  type: string;
  description?: string;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}