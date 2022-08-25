import { Item } from "../items/Item";

export class RecipeMaterial {
  constructor(
    itemName: string,
    item: Item,
    quantity: number) {
    this.itemName = itemName;
    this.item = item;
    this.quantity = quantity;
  }

  itemName: string;
  item: Item;
  quantity: number;
}