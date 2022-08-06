import { Item } from "./Item";

export class ItemStack {
  constructor(item?: Item, quantity: number = 0) {
    this.item = item;
    this.quantity = quantity;
  }

  item?: Item;
  quantity: number;

  AtMaximumCapacity = (): boolean => this.item?.maximumInStack === this.quantity;
}