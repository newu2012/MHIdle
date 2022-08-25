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
import { ResourceNodeItem } from "../models/region/ResourceNodeItem";
import { ResourceNodeProportion } from "../models/region/ResourceNodeProportion";
import { ref } from "vue";
import { RecipeMaterial } from "../models/craft/RecipeMaterial";
import { Recipe } from "../models/craft/Recipe";

@injectable()
export class StartupLoadService {
  isLoaded = ref(false);

  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.RegionService) regionService: RegionService,
  ) {
    this.LoadServices(modelsService, regionService).then(r => {
      this.isLoaded.value = true;
      regionService.AutoExplore();
    });
  }

  async LoadServices(modelsService: ModelsService, regionService: RegionService) {
    await this.LoadItemsFromServer().then(
      result => modelsService.items = result,
    );
    await this.LoadResourceNodeEventsFromServer().then(
      result => modelsService.resourceNodeEvents = result,
    );
    await this.LoadTerritoriesFromServer(modelsService).then(
      result => {
        modelsService.territories = result;
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
    const resourceResponse: HttpResponse<[]> = await useFetch<[]>("/api/resource");
    const instrumentResponse: HttpResponse<[]> = await useFetch<[]>("/api/instrument");
    const json = resourceResponse!.parsedBody!.concat(instrumentResponse!.parsedBody!);

    const items = [];

    for (let i = 0; i < json.length; i++) {
      //  TODO Add other item types (armor, instruments, etc.)
      const item = new Resource(
        json[i]["name"],
        json[i]["type"],
        json[i]["description"],
        json[i]["rarity"],
        json[i]["value"],
        json[i]["imagePath"],
        json[i]["maximumInInventory"],
        json[i]["maximumInStorage"],
      );

      items.push(item);
    }

    return items;
  }

  async LoadResourceNodeEventsFromServer(): Promise<ResourceNode[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/event");
    const json = response!.parsedBody!;

    const resourceNodes = [];

    for (let i = 0; i < json.length; i++) {
      const resourceNodeItems: ResourceNodeItem[] = (json[i]["resourceNodeItems"] as ResourceNodeItem[])
        .map(rni => {
          return new ResourceNodeItem(
            rni.itemName,
            rni.value,
            rni.minimumQuantity,
            rni.maximumQuantity,
          );
        });
      const resourceNode = new ResourceNode(
        resourceNodeItems,
        json[i]["id"],
        json[i]["name"],
        json[i]["description"],
        json[i]["capacity"],
        json[i]["durationSeconds"] * 1000, //  Convert seconds to ms
        json[i]["instrumentType"],
        json[i]["instrumentRequiredLevel"],
        json[i]["instrumentExpectedLevel"],
      );

      resourceNodes.push(resourceNode);
    }

    return resourceNodes;
  }

  async LoadTerritoriesFromServer(modelsService: ModelsService): Promise<Territory[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/territory");
    const json = response!.parsedBody!;

    const territories: Territory[] = [];

    for (let i = 0; i < json.length; i++) {
      const region = new Territory(
        json[i]["id"],
        json[i]["name"],
        json[i]["description"],
        json[i]["regionId"],
        json[i]["durationSecondsExploreOnEnter"] * 1000,
        json[i]["durationSecondsExploreInTerritory"] * 1000,
        json[i]["instrumentType"],
        json[i]["instrumentRequiredLevel"],
        json[i]["instrumentExpectedLevel"],
        (json[i]["resourceNodeProportions"] as ResourceNodeProportion[])
          .map(rnp => new owp(
            modelsService.resourceNodeEvents.filter(rne => rne.id === rnp.resourceNodeEventId)[0],
            rnp.value)),
      );

      territories.push(region);
    }

    return territories;
  }

  async LoadRegionsFromServer(): Promise<Region[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/region");
    const json = response!.parsedBody!;

    const regions: Region[] = [];

    for (let i = 0; i < json.length; i++) {
      const region = new Region(
        json[i]["id"],
        json[i]["name"],
        json[i]["description"],
        (json[i]["territories"] as Territory[]),
      );

      regions.push(region);
    }

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
        json[i]["id"],
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