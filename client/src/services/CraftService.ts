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

    const canCraftAmount = this.CanCraftAmount(this.activeRecipe);
    this.quantity = Math.min(this.quantity, canCraftAmount);


    if (this.quantity === 0) {
      console.log(`Not enough materials to create ${this.activeRecipe.item.name}`);

      actionService.SetCurrentAction(this.actionService.availableActions.explore(
        regionService.activeTerritory.durationExploreInTerritory));
      return;
    }

    //  TODO Change to notification
    console.log(`Crafted${this.quantity === 1 ? "" : " " + this.quantity + " of"} ${this.activeRecipe.item.name}`);
    for (let i = 0; i < this.activeRecipe.recipeMaterials.length; i++) {
      const rm = this.activeRecipe.recipeMaterials[i];
      character.storageInventory.Remove(rm.item, rm.quantity * this.quantity);
    }
    character.storageInventory.AddItem(this.activeRecipe.item, this.quantity);

    actionService.SetCurrentAction(this.actionService.availableActions.explore(
      regionService.activeTerritory.durationExploreInTerritory));
  }

  CanCraftAmount(recipe: Recipe): number {
    if (recipe === undefined) {
      return 0;
    }
    const character = ref(container.get<Character>(TYPES.Character)).value;

    let maximumAmount = recipe.item.maximumInStorage - (character.storageInventory
      .GetItemOrEmptyItemStack(recipe.item.name) as ItemStack).quantity;

    for (let i = 0; i < recipe.recipeMaterials.length; i++) {
      const rm = recipe.recipeMaterials[i];
      const is: ItemStack = character.storageInventory
        .GetItemOrEmptyItemStack(rm.item.name);

      if (is.quantity < rm.quantity) {
        return 0;
      }
      maximumAmount = Math.min(maximumAmount, Math.floor(is.quantity / rm.quantity));
    }

    return maximumAmount;
  }
}