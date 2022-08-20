import { ResourceHerb } from "../models/items/ResourceHerb";
import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { RandomService } from "./RandomService";
import { ref } from "vue";
import container from "../inversify.config";
import { Action } from "../models/Action";
import { Character } from "../models/character/Character";
import { HttpResponse, useFetch } from "../fetch";
import { ResourceNode } from "../models/region/ResourceNode";
import { ObjectWithProportion as owp } from "../models/ObjectWithProportion";
import { Resource } from "../models/items/Resource";

@injectable()
export class RegionService {
  actionService: ActionService;
  character: Character;
  eventsInRegion: owp<any>[] = [];

  constructor(
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.Character) character: Character) {
    this.actionService = actionService;
    this.character = character;
    this.GenerateItemsFromDb();
    this.AutoExplore();
  }

  async GenerateItemsFromDb() {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/region");
    const json = response!.parsedBody!;

    //  TODO convert response to array of explorationEvents
    const basicResourceNodeResources = [];

    for (let i = 0; i < json.length; i++) {
      const resource = new ResourceHerb(
        json[i]["id"],
        json[i]["type"],
        json[i]["name"],
        json[i]["description"],
        json[i]["rarity"],
        json[i]["value"],
        json[i]["imagePath"],
        json[i]["maximumInInventory"],
        json[i]["maximumInStorage"],
      );

      basicResourceNodeResources.push(new owp(
        resource,
        1 / (Math.pow(1.5, resource.rarity - 1)),
      ));
    }

    //  TODO Add value calculation based on events, when there will be more than 1 event
    this.eventsInRegion.push(new ResourceNode(
      basicResourceNodeResources,
      1,
      "herb patch",
    ));

    console.log(this.eventsInRegion);
  }

  AutoExplore() {
    this.actionService.SetCurrentAction(new Action(
      "Exploring",
      10 * 1000,
      this.Explore, this.character));
  }

  Explore(...args: any[]) {
    const character = args[0][0];
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;

    //  TODO Change from owp<ResourceNode> to owp<any> ???
    const randomEvent: owp<Resource>[] = randomService.GetRandFromProportion(regionService.eventsInRegion);
    const randomResource = randomService.GetRandFromProportion(randomEvent);
    const amount = randomService.GetRandIntBetween({ from: 0, to: 3 });

    character.currentInventory
      .AddItem(randomResource, amount);
    character.currencies.researchPoints += amount * randomResource.value;
  }
}