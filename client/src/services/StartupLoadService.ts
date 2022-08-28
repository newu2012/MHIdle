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
import { Instrument } from "../models/items/Instrument";

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
    await this.LoadResourceNodesFromServer().then(
      result => modelsService.resourceNodes = result,
    );
    await this.LoadTerritoriesFromServer(modelsService).then(
      result => {
        modelsService.territories = result;
        //  TODO Change to highest priority starting territory
        regionService.activeTerritory = modelsService.territories.filter(t => t.name === "Outskirts")[0];
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

  async LoadResourceNodesFromServer(): Promise<ResourceNode[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/resource-node");
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
        json[i]["name"],
        json[i]["description"],
        json[i]["regionName"],
        json[i]["durationSecondsExploreOnEnter"] * 1000,
        json[i]["durationSecondsExploreInTerritory"] * 1000,
        json[i]["instrumentType"],
        json[i]["instrumentRequiredLevel"],
        json[i]["instrumentExpectedLevel"],
        (json[i]["resourceNodeProportions"] as ResourceNodeProportion[])
          .map(rnp => new owp(
            modelsService.resourceNodes.filter(rn => rn.name === rnp.resourceNodeName)[0],
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