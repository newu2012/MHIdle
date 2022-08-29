import { inject, injectable } from "inversify";
import { HttpResponse, useFetch } from "../fetch";
import { Resource } from "../models/items/Resource";
import { ObjectWithProportion as owp } from "../models/ObjectWithProportion";
import TYPES from "../types";
import { RegionService } from "./RegionService";
import { Region } from "../models/region/Region";
import { Territory } from "../models/region/Territory";
import { ResourceNode } from "../models/region/ResourceNode";
import { ModelsService } from "./ModelsService";
import { Item } from "../models/items/Item";
import { TerritoryEventProportion } from "../models/region/TerritoryEventProportion";
import { ref } from "vue";
import { RecipeMaterial } from "../models/craft/RecipeMaterial";
import { Recipe } from "../models/craft/Recipe";
import { Instrument } from "../models/items/Instrument";
import { TerritoryEvent } from "../models/region/TerritoryEvent";
import { Monster } from "../models/region/Monster";

@injectable()
export class StartupLoadService {
  isLoaded = ref(false);

  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.RegionService) regionService: RegionService,
  ) {
    this.LoadServices(modelsService, regionService).then(() => {
      this.isLoaded.value = true;
    });
  }

  async LoadServices(modelsService: ModelsService, regionService: RegionService) {
    await this.LoadItemsFromServer().then(
      result => modelsService.items = result,
    );
    await this.LoadTerritoryEventsFromServer().then(
      result => modelsService.territoryEvents = result,
    );
    await this.LoadTerritoriesFromServer(modelsService).then(
      result => {
        modelsService.territories = result;
        //  TODO Change to highest priority starting territory
        regionService.activeTerritory = modelsService.territories[0];
      },
    );
    await this.LoadRegionsFromServer().then(
      result => modelsService.regions = result,
    );
    await this.LoadRecipesFromServer(modelsService).then(
      result => modelsService.recipes = result,
    );
  }

  async LoadItemsFromServer(): Promise<Item[]> {
    const responses = [
      (await (await useFetch<[]>("/api/resource"))).parsedBody!,
      (await (await useFetch<[]>("/api/instrument"))).parsedBody!,
    ];
    const json = [].concat(...responses);
    const items = [];

    for (let i = 0; i < json.length; i++) {
      //  TODO Add other item types (armor, instruments, etc.)
      let item: Item;
      switch (json[i]["type"]) {
        case "Resource":
          item = Resource.FromParsedBody(json[i]);
          break;
        case "Instrument":
          item = Instrument.FromParsedBody(json[i]);
          break;
        default:
          console.log(json[i]);
          return items;
      }

      items.push(item);
    }

    return items;
  }

  //  TODO update to TerritoryEvent with Monster and ResourceNode
  async LoadTerritoryEventsFromServer(): Promise<TerritoryEvent[]> {
    const responses = [
      (await (await useFetch<[]>("/api/resource-node"))).parsedBody!,
      (await (await useFetch<[]>("/api/monster"))).parsedBody!,
    ];
    const json = [].concat(...responses);
    const territoryEvents = [];

    for (let i = 0; i < json.length; i++) {
      let territoryEvent: TerritoryEvent;

      switch (json[i]["type"]) {
        case "Resource node":
          territoryEvent = ResourceNode.FromParsedBody(json[i]);
          break;
        case "Monster":
          territoryEvent = Monster.FromParsedBody(json[i]);
          break;
        default:
          console.log(json[i]);
          return territoryEvents;
      }

      territoryEvents.push(territoryEvent);
    }

    return territoryEvents;
  }

  async LoadTerritoriesFromServer(modelsService: ModelsService): Promise<Territory[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/territory");
    const json = response!.parsedBody!;

    const territories: Territory[] = [];

    for (let i = 0; i < json.length; i++) {
      const region = new Territory(
        json[i]["name"],
        json[i]["description"],
        json[i]["regionName"],
        json[i]["order"],
        json[i]["isCity"],
        json[i]["isCamp"],
        json[i]["durationSecondsExploreOnEnter"] * 1000,
        json[i]["durationSecondsExploreInTerritory"] * 1000,
        json[i]["instrumentType"],
        json[i]["instrumentRequiredLevel"],
        json[i]["instrumentExpectedLevel"],
        (json[i]["territoryEventProportions"] as TerritoryEventProportion[])
          .map(rnp => new owp(
            modelsService.territoryEvents.filter(rn => rn.name === rnp.territoryEventName)[0],
            rnp.value)),
      );

      territories.push(region);
    }
    territories.sort((a, b) => a.order - b.order);

    return territories;
  }

  async LoadRegionsFromServer(): Promise<Region[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/region");
    const json = response!.parsedBody!;

    const regions: Region[] = [];

    for (let i = 0; i < json.length; i++) {
      const region = new Region(
        json[i]["name"],
        json[i]["order"],
        json[i]["description"],
        (json[i]["territories"] as Territory[]),
      );

      regions.push(region);
    }
    regions.sort((a, b) => a.order - b.order);

    return regions;
  }

  async LoadRecipesFromServer(modelsService: ModelsService): Promise<Recipe[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/recipe");
    const json = response!.parsedBody!;

    const recipes = [];

    for (let i = 0; i < json.length; i++) {
      const recipeMaterials: RecipeMaterial[] = (json[i]["recipeMaterials"] as RecipeMaterial[])
        .map(rm => {
          return new RecipeMaterial(
            rm.itemName,
            modelsService.items.filter(i => i.name === rm.itemName)[0],
            rm.quantity,
          );
        });
      const recipe = new Recipe(
        json[i]["name"],
        json[i]["type"],
        modelsService.items.filter(item => item.name === json[i]["itemName"])[0],
        json[i]["durationSeconds"] * 1000, //  Convert seconds to ms
        recipeMaterials,
        json[i]["instrumentType"],
        json[i]["instrumentRequiredLevel"],
        json[i]["instrumentExpectedLevel"],
      );

      recipes.push(recipe);
    }

    return recipes;
  }
}