export interface Item {
  id: number;
  type: string;
  name: string;
  description?: string;
  rarity: number;
  value: number;
  imagePath: string;
  maximumInInventory: number;
  maximumInStorage: number;
}