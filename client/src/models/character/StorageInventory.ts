import { Inventory } from "./Inventory";
import { ref } from "vue";
import container from "../../inversify.config";
import { Character } from "./Character";
import TYPES from "../../types";
import { ItemStack } from "../items/ItemStack";
import { RegionService } from "../../services/RegionService";

export class StorageInventory extends Inventory {
  isStorage = true;

  MoveToCurrentInventory(itemStack: ItemStack) {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService));
    //  TODO Move to new method and check it from UI
    if (!regionService.value.inCity) {
      alert("You should be in City to move items.");
      return;
    }

    const character = ref(container.get<Character>(TYPES.Character));

    const foundInCurrentItemIndex = character.value.currentInventory
      .FindItemIndexByName(itemStack.item?.name!);
    const currentlyInInventory = foundInCurrentItemIndex !== -1 ?
      character.value.currentInventory.itemStacks[foundInCurrentItemIndex].quantity
      : 0;
    const quantityToChange = Math.min(itemStack.quantity,
      itemStack.item?.maximumInInventory! - currentlyInInventory);
    character.value.currentInventory.AddItem(itemStack.item!,
      quantityToChange);
    this.Remove(itemStack.item!, quantityToChange);
  }

  SellItem(itemId: number, quantity: number = 1) {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService));
    //  TODO Move to new method and check it from UI
    if (!regionService.value.inCity) {
      alert("You should be in City to move items.");
      return;
    }

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