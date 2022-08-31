import { inject, injectable } from "inversify";
import { ActionService } from "./ActionService";
import TYPES from "../types";
import { ref } from "vue";
import container from "../inversify.config";
import { Recipe } from "../models/craft/Recipe";
import { Character } from "../models/character/Character";
import { ItemStack } from "../models/items/ItemStack";
import { Instrument } from "../models/items/Instrument";
import { ActionMainService } from "./ActionMainService";

@injectable()
export class CraftService {
  constructor(
    @inject(TYPES.ActionMainService) actionMainService: ActionMainService) {
    this.actionMainService = actionMainService;
  }

  actionMainService: ActionService;
  activeRecipe?: Recipe;
  quantity: number = 0;

  SetRecipe(recipe: Recipe, quantity: number) {
    this.activeRecipe = recipe;
    this.quantity = quantity;
  }

  //  TODO Change craft when quantity > 0 from "big duration" to "multiple durations"
  Craft() {
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;

    if (this.activeRecipe === undefined) {
      console.log(`No active recipe found`);
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.idle());
      return;
    }

    const canCraftAmount = this.CanCraftAmount(this.activeRecipe);
    this.quantity = Math.min(this.quantity, canCraftAmount);

    if (this.quantity === 0) {
      console.log(`Not enough materials to create ${this.activeRecipe.item.name}`);
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.idle());
      return;
    }

    //  TODO Change to notification
    console.log(`Crafted${this.quantity === 1 ? "" : " " + this.quantity + " of"} ${this.activeRecipe.item.name}`);
    for (let i = 0; i < this.activeRecipe.recipeMaterials.length; i++) {
      const rm = this.activeRecipe.recipeMaterials[i];
      character.storageInventory.Remove(rm.item, rm.quantity * this.quantity);
    }
    character.storageInventory.AddItem(this.activeRecipe.item, this.quantity);

    actionMainService.SetCurrentAction(this.actionMainService.availableActions.idle());
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

  GetCraftDuration(): number {
    const craftService = ref(container.get<CraftService>(TYPES.CraftService)).value;

    if (craftService.activeRecipe === undefined) {
      console.log("CraftService.activeRecipe was undefined");
      return -1;
    }

    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;

    return actionMainService
      .CalculateActionDurationFromInstrumentType(
        craftService.activeRecipe.duration,
        craftService.activeRecipe.instrumentType,
        craftService.activeRecipe.instrumentExpectedLevel);
  }
}