export interface Item {
  id: number;
  name: string;
  description?: string;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}