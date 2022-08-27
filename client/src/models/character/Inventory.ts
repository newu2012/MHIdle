import { Item } from "../items/Item";
import { reactive } from "vue";
import { ItemStack } from "../items/ItemStack";

export class Inventory {
  itemStacks: ItemStack[];
  isStorage = false;

  constructor(stacksQuantity: number) {
    this.itemStacks = reactive(new Array(stacksQuantity));
    for (let i = 0; i < stacksQuantity; i++) {
      this.itemStacks[i] = new ItemStack();
    }
  }

  FindItemIndexByName(itemName: string): number {
    for (let i = 0; i < this.itemStacks.length; i++) {
      if (this.itemStacks[i].item?.name === itemName) {
        return i;
      }
    }
    return -1;
  }

  FindEmptyItemStackIndex(): number {
    return this.itemStacks.findIndex((is) => is.item === undefined);
  }

  //  TODO Split into 2 methods, seems like this method does 2 different tasks
  GetItemOrEmptyItemStack(itemName: string) {
    const itemIndex = this.FindItemIndexByName(itemName);
    return itemIndex >= 0 ?
      this.itemStacks[itemIndex] :
      this.itemStacks[this.FindEmptyItemStackIndex()];
  }

  GetItemStacksByType(itemType: string) {
    return this.itemStacks.filter(is => is.item?.type === itemType);
  }

  AtMaximumCapacity = (item: Item, foundItemIndex: number): boolean => {
    return this.isStorage ?
      item.maximumInStorage === this.itemStacks[foundItemIndex].quantity :
      item.maximumInInventory === this.itemStacks[foundItemIndex].quantity;

  };

  AddItem(item: Item, quantity: number = 1) {
    if (quantity === 0) {
      return;
    }

    let foundItemIndex = this.FindItemIndexByName(item.name);
    if (foundItemIndex === -1) {
      foundItemIndex = this.FindEmptyItemStackIndex();
    }

    let result: string;

    if (foundItemIndex === -1) {
      result = `No more space in inventory for any new item. Lost ${quantity} of ${item.name}.`;
    } else if (this.AtMaximumCapacity(item, foundItemIndex)) {
      result = `No more space for item ${item.name}. Lost ${quantity} of ${item.name}.`;
    } else {
      if (this.itemStacks[foundItemIndex]!.item?.name !== item.name) {
        this.itemStacks[foundItemIndex]!.item = item;
      }
      const itemsToAdd = Math.min(
        (this.isStorage ? item.maximumInStorage : item.maximumInInventory) -
        this.itemStacks[foundItemIndex]!.quantity, quantity);
      this.itemStacks[foundItemIndex]!.quantity += itemsToAdd;

      result = `Added ${itemsToAdd} ${item.name} to ${this.isStorage ? "storage" : "current"} inventory.`;
      if (itemsToAdd !== quantity) {
        result += ` ${quantity - itemsToAdd} of ${item.name} was lost because there's no more space for this item.`;
      }
    }

    //  TODO Change to notification
    console.log(result);
    return;
  }

  Remove(item: Item, quantity: number = 1) {
    if (quantity === 0) {
      return;
    }

    const foundItemIndex = this.FindItemIndexByName(item.name);

    if (foundItemIndex === -1) {
      return;
    } else {
      this.itemStacks[foundItemIndex].quantity -=
        Math.min(quantity, this.itemStacks[foundItemIndex].quantity);
      if (this.itemStacks[foundItemIndex].quantity === 0) {
        this.itemStacks[foundItemIndex]!.item = undefined;
      }

      //  TODO Change to notification
      console.log(`Removed ${quantity} ${item.name} from ${this.isStorage ? "storage" : "current"} inventory.`);
    }
  }
}