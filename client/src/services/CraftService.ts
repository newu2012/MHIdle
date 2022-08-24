import { inject, injectable } from "inversify";
import { ActionService } from "./ActionService";
import TYPES from "../types";
import { ref } from "vue";
import container from "../inversify.config";
import { Recipe } from "../models/craft/Recipe";
import { RegionService } from "./RegionService";
import { Character } from "../models/character/Character";
import { ItemStack } from "../models/items/ItemStack";

@injectable()
export class CraftService {
  constructor(
    @inject(TYPES.ActionService) actionService: ActionService) {
    this.actionService = actionService;
  }

  actionService: ActionService;
  activeRecipe?: Recipe;
  quantity: number = 0;

  //  TODO Change craft when quantity > 0 from "big duration" to "multiple durations"
  Craft() {
    if (this.activeRecipe === undefined) {
      return;
    }
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;

    const itemStack: ItemStack = character.storageInventory
      .GetItemOrEmptyItemStack(this.activeRecipe.item.name);

    if (itemStack.item !== undefined &&
      itemStack.item.maximumInStorage - itemStack.quantity < this.quantity) {
      this.quantity = itemStack.item!.maximumInStorage - itemStack.quantity;
    }

    for (let i = 0; i < this.activeRecipe.recipeMaterials.length; i++) {
      const rm = this.activeRecipe.recipeMaterials[i];
      const is: ItemStack = character.storageInventory
        .GetItemOrEmptyItemStack(rm.item.name);

      if (is.quantity < rm.quantity) {
        console.log(`There were only ${is.quantity} of ${rm.item.name}, but ${rm.quantity} was needed`);
        actionService.SetCurrentAction(this.actionService.availableActions.explore(
          regionService.activeTerritory.durationExploreInTerritory));
        return;
      }
    }

    //  TODO Change to notification
    console.log(`Crafted ${this.quantity == 1 ? "" : this.quantity + " of"} ${this.activeRecipe.item.name}`);
    for (let i = 0; i < this.activeRecipe.recipeMaterials.length; i++) {
      const rm = this.activeRecipe.recipeMaterials[i];
      character.storageInventory.Remove(rm.item, rm.quantity);
    }
    character.storageInventory.AddItem(this.activeRecipe.item, this.quantity);

    actionService.SetCurrentAction(this.actionService.availableActions.explore(
      regionService.activeTerritory.durationExploreInTerritory));
  }
}