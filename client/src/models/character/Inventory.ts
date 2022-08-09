import { ItemStack } from "../items/ItemStack";
import { Item } from "../items/Item";
import { ref } from "vue";
import container from "../../inversify.config";
import TYPES from "../../types";
import { Character } from "./Character";

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

  FindItemIndex(itemName: string): number {
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

  GetItemOrEmptyItemStack(itemName: string) {
    const itemIndex = this.FindItemIndex(itemName);
    return itemIndex >= 0 ?
      this.itemStacks[itemIndex] :
      this.itemStacks[this.FindEmptyItemStackIndex()];
  }

  AddItem(item: Item, quantity: number = 1) {
    if (quantity === 0) {
      return;
    }

    let foundItemIndex = this.FindItemIndex(item.name);
    if (foundItemIndex === -1) {
      foundItemIndex = this.FindEmptyItemStackIndex();
    }

    let result: string;

    if (foundItemIndex === -1) {
      result = `No more space in inventory for any new item. Lost ${quantity} of ${item.name}.`;
    } else if (this.itemStacks[foundItemIndex].AtMaximumCapacity()) {
      result = `No more space for item ${item.name}. Lost ${quantity} of ${item.name}.`;
    } else {
      if (this.itemStacks[foundItemIndex]!.item?.name !== item.name) {
        this.itemStacks[foundItemIndex]!.item = item;
      }
      const itemsToAdd = Math.min(item.maximumInStack -
        this.itemStacks[foundItemIndex]!.quantity, quantity);
      this.itemStacks[foundItemIndex]!.quantity += itemsToAdd;

      result = `Added ${itemsToAdd} ${item.name} to inventory.`;
      if (itemsToAdd !== quantity) {
        result += ` ${quantity - itemsToAdd} of ${item.name} was lost because there's no more space for this item.`;
      }
    }

    console.log(result);
    console.log(this.itemStacks);
    return;
  }

  SellItem(itemId: number, quantity: number = 1) {
    const itemStack = this.itemStacks.find((is) => is.item?.id === itemId);
    if (itemStack === undefined) {
      throw new Error(`Can't find ${itemId} in ${this.itemStacks}`);
    }

    const quantityToSell = itemStack.quantity - quantity >= 0 ?
      quantity :
      itemStack.quantity;

    const character = ref(container.get<Character>(TYPES.Character)).value;
    const sellValue = quantityToSell * itemStack.item?.value!;
    character.currencies.money += sellValue;
    itemStack.quantity -= quantityToSell;
    console.log(`Sold ${quantityToSell} of ${itemStack.item?.name} for ${sellValue}`);

    if (itemStack.quantity === 0) {
      itemStack.item = undefined;
    }
  }
}