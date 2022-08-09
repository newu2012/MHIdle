import { Item } from "./Item";
import { Inventory } from "../character/Inventory";

export class ItemStack {
  constructor(item?: Item, quantity: number = 0) {
    this.item = item;
    this.quantity = quantity;
  }

  item?: Item;
  quantity: number;

  AtMaximumCapacity = (inventoryType: Inventory): boolean =>
      this.item?.maximumInInventory === this.quantity;
}