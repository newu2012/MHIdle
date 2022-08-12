import { ResourceHerb } from "../models/items/ResourceHerb";
import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { RandomService } from "./RandomService";
import { ref } from "vue";
import container from "../inversify.config";
import { Action } from "../models/Action";
import { Character } from "../models/character/Character";
import { Item } from "../models/items/Item";
import { HttpResponse, useFetch } from "../fetch";

@injectable()
export class RegionService {
  actionService: ActionService;
  character: Character;
  foundItems: Item[] = [];
  itemsInRegion: any[] = [];

  constructor(
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.Character) character: Character) {
    this.actionService = actionService;
    this.character = character;
    this.GenerateItemsFromDb();
    // this.TestGenerateRandomItems();
    this.AutoGather();
  }

  async GenerateItemsFromDb() {
    const response: HttpResponse<[]> = await useFetch<[]>("/weatherforecast");

    //  TODO convert response to array of items
    this.itemsInRegion = response!.parsedBody!;

    for (let i = 0; i < this.itemsInRegion.length; i++) {
      console.log(this.itemsInRegion[i]);
    }

    const firstResource = new ResourceHerb(
      0,
      "Simple Herb",
      "Some simple herb needed to create various potions and build basic stuff. Nothing special.",
      1,
      1,
      "/icons/Herb_Icon_Green.png");
    const secondResource = new ResourceHerb(
      0,
      "Not so simple Herb",
      "Other herb.",
      2,
      10,
      "/icons/Herb_Icon_Red.png");

    this.itemsInRegion = [firstResource, secondResource];
  }

  TestGenerateRandomItems() {
    for (let i = 1; i < 677; i++) {
      const rarity = Math.round(Math.random() * 10);
      this.foundItems.push(new ResourceHerb(
        i,
        `Item #${i}`,
        `Description of Item #${i}`,
        rarity,
        rarity * 10,
        `/test/icon(${i}).png`));
    }
  }

  AutoGather() {
    this.actionService.SetCurrentAction(new Action(
      "Gather herbs",
      10 * 1000,
      this.GatherHerbs, this.character));
  }

  GatherHerbs(...args: any[]) {
    const character = args[0][0];
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;

    const randomItemId = randomService.GetRandIntBetween({ from: 0, to: regionService.itemsInRegion.length - 1 });
    const randomItem = regionService.itemsInRegion[randomItemId];
    const amount = randomService.GetRandIntBetween({ from: 0, to: 3 });

    character.currentInventory
      .AddItem(randomItem, amount);
    character.currencies.researchPoints += amount * randomItem.value;
  }
}