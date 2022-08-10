import { Inventory } from "./Inventory";
import { ref } from "vue";
import container from "../../inversify.config";
import { Character } from "./Character";
import TYPES from "../../types";
import { ItemStack } from "../items/ItemStack";

export class StorageInventory extends Inventory {
  isStorage = true;

  MoveToCurrentInventory(itemStack: ItemStack) {
    const character = ref(container.get<Character>(TYPES.Character));

    const currentlyInInventory = character.value.currentInventory.itemStacks[character.value.currentInventory
      .FindItemIndexByName(itemStack.item?.name!)] ?? 0;
    const quantityToChange = Math.min(itemStack.quantity,
      itemStack.item?.maximumInInventory! - currentlyInInventory.quantity);
    character.value.currentInventory.AddItem(itemStack.item!,
      quantityToChange);
    this.Remove(itemStack.item!, quantityToChange);
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
    character.currencies.zenny += sellValue;
    itemStack.quantity -= quantityToSell;
    console.log(`Sold ${quantityToSell} of ${itemStack.item?.name} for ${sellValue}`);

    if (itemStack.quantity === 0) {
      itemStack.item = undefined;
    }
  }
}