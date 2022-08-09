import { Inventory } from "./Inventory";
import { ItemStack } from "../items/ItemStack";
import { ref } from "vue";
import container from "../../inversify.config";
import { Character } from "./Character";
import TYPES from "../../types";

export class CurrentInventory extends Inventory {
  MoveToStorageInventory(itemStack: ItemStack) {
    const character = ref(container.get<Character>(TYPES.Character));

    character.value.storageInventory.AddItem(itemStack.item!, itemStack.quantity);
    this.Remove(itemStack.item!, itemStack.quantity);
  }
}