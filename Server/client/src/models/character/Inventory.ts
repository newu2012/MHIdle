import { ItemStack } from "../items/ItemStack";
import { Item } from "../items/Item";

export class Inventory {
  constructor(
    stacksQuantity: number = 10,
    itemStacks: ItemStack[]) {
    this.stacksQuantity = stacksQuantity;

    if (Array.isArray(itemStacks) && itemStacks.length) {
      this.itemStacks = itemStacks;
    } else {
      this.itemStacks = [];
      for (let i = 0; i < stacksQuantity; i++) {
        this.itemStacks.push(new ItemStack(undefined, 0));
      }
    }
  }

  stacksQuantity: number;
  itemStacks: ItemStack[];

  FindItem(itemName: string, quantityToAdd: number = 1) {
    for (let i = 0; i < this.itemStacks.length; i++) {
      if (this.itemStacks[i].item?.name === itemName) {
        if (quantityToAdd + this.itemStacks[i].quantity <= this.itemStacks[i].item!.maximumInStack) {
          return this.itemStacks[i];
        }
      }
    }
    return null;
  }

  AddItem(item: Item, quantity: number = 1) {
    const foundItem = this.FindItem(item.name, quantity) ?? this.itemStacks.find(is => is.item === undefined);

    if (foundItem !== null && foundItem !== undefined) {
      if (foundItem!.item?.name === item.name) {
        foundItem!.quantity += quantity;
      } else {
        foundItem!.item = item;
        foundItem!.quantity += quantity;
      }
    } else {
      alert("No more space in inventory");
    }
  }

  CountItems(itemName: string) {
    let count = 0;

    for (let i = 0; i < this.itemStacks.length; i++) {
      if (this.itemStacks[i].item !== undefined && this.itemStacks[i].item!.name === itemName) {
        count += this.itemStacks[i].quantity;
      }
    }

    return count;
  }
}