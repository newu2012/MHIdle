import { Inventory } from "./Inventory";
import { ref } from "vue";
import container from "../../inversify.config";
import { Character } from "./Character";
import TYPES from "../../types";

export class StorageInventory extends Inventory {
  isStorage = true;

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