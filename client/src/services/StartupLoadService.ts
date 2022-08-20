import { inject, injectable } from "inversify";
import { HttpResponse, useFetch } from "../fetch";
import { ResourceHerb } from "../models/items/ResourceHerb";
import { ObjectWithProportion as owp } from "../models/ObjectWithProportion";
import TYPES from "../types";
import { RegionService } from "./RegionService";
import { Region } from "../models/region/Region";
import { Territory } from "../models/region/Territory";
import { ResourceNode } from "../models/region/ResourceNode";
import { ModelsService } from "./ModelsService";
import { Item } from "../models/items/Item";

@injectable()
export class StartupLoadService {
  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.RegionService) regionService: RegionService,
  ) {
    this.LoadRegionsFromServer().then(
      result => modelsService.regions = result,
    );
    this.LoadTerritoriesFromServer().then(
      result => modelsService.territories = result,
    );
    this.LoadItemsFromServer().then(
      result => modelsService.items = result,
    );
    this.LoadResourceNodesFromServer().then(
      result => regionService.eventsInTerritories = result,
    );

    regionService.AutoExplore();
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
        json[i]["territories"],
      );

      regions.push(region);
    }

    console.log(regions);

    return regions;
  }

  async LoadTerritoriesFromServer(): Promise<Territory[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/territory");
    const json = response!.parsedBody!;

    const territories: Territory[] = [];

    for (let i = 0; i < json.length; i++) {
      const region = new Territory(
        json[i]["id"],
        json[i]["name"],
        json[i]["description"],
        json[i]["regionId"],
        json[i]["territoryEvents"],
      );

      territories.push(region);
    }

    console.log(territories);

    return territories;
  }

  async LoadResourceNodesFromServer(): Promise<ResourceNode[]> {
    //  TODO Change to load items
    const response: HttpResponse<[]> = await useFetch<[]>("/api/item");
    const json = response!.parsedBody!;

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
    const resourceNodes = [];
    resourceNodes.push(new ResourceNode(
      basicResourceNodeResources,
      1,
      "herb patch",
    ));

    console.log(resourceNodes);
    return resourceNodes;
  }

  async LoadItemsFromServer(): Promise<Item[]> {
    //  TODO Change to load items
    const response: HttpResponse<[]> = await useFetch<[]>("/api/item");
    const json = response!.parsedBody!;

    const items = [];

    for (let i = 0; i < json.length; i++) {
      const item = new ResourceHerb(
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

      items.push(item);
    }

    console.log(items);
    return items;
  }
}