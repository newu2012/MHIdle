import { Item } from "../items/Item";

export class RecipeMaterial {
  constructor(
    itemId: number,
    item: Item,
    quantity: number) {
    this.itemId = itemId;
    this.item = item;
    this.quantity = quantity;
  }

  itemId: number;
  item: Item;
  quantity: number;
}