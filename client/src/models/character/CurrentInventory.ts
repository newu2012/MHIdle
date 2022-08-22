import { Inventory } from "./Inventory";
import { ItemStack } from "../items/ItemStack";
import { ref } from "vue";
import container from "../../inversify.config";
import { Character } from "./Character";
import TYPES from "../../types";
import { RegionService } from "../../services/RegionService";

export class CurrentInventory extends Inventory {
  MoveToStorageInventory(itemStack: ItemStack) {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService));
    //  TODO Move to new method and check it from UI
    if (!regionService.value.inCity) {
      alert("You should be in City to move items.");
      return;
    }

    const character = ref(container.get<Character>(TYPES.Character));

    character.value.storageInventory.AddItem(itemStack.item!, itemStack.quantity);
    this.Remove(itemStack.item!, itemStack.quantity);
  }
}