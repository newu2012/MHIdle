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

@injectable()
export class StartupLoadService {
  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.RegionService) regionService: RegionService,
  ) {
    this.LoadServices(modelsService, regionService);

    regionService.AutoExplore();
  }

  async LoadServices(modelsService: ModelsService, regionService: RegionService) {
    await this.LoadItemsFromServer().then(
      result => modelsService.items = result,
    );
    await this.LoadRegionsFromServer().then(
      result => modelsService.regions = result,
    );
    await this.LoadResourceNodeEventsFromServer(modelsService).then(
      result => modelsService.resourceNodeEvents = result,
    );
    await this.LoadTerritoriesFromServer(modelsService).then(
      result => {
        modelsService.territories = result;
        regionService.activeTerritory = modelsService.territories[0];
      },
    );
  }

  async LoadItemsFromServer(): Promise<Item[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/item");
    const json = response!.parsedBody!;

    const items = [];

    for (let i = 0; i < json.length; i++) {
      //  TODO Add other item types (armor, etc.)
      const item = new Resource(
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

    return items;
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

    return regions;
  }

  async LoadResourceNodeEventsFromServer(modelsService: ModelsService): Promise<ResourceNode[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/event");
    const json = response!.parsedBody!;

    const resourceNodes = [];

    for (let i = 0; i < json.length; i++) {
      const resourceNodeItems: owp<Item>[] = (json[i]["resourceNodeItems"] as ResourceNodeItem[])
        .map(rni => new owp<Item>(
          modelsService.items.filter(it => it.id === rni.itemId)[0],
          rni.proportionValue,
        ));
      const resourceNode = new ResourceNode(
        resourceNodeItems,
        (json[i]["resourceNodeProportions"] as ResourceNodeProportion[])
          .filter(rnp => rnp.resourceNodeEventId === json[i]["id"])[0].proportionValue,
        json[i]["id"],
        json[i]["name"],
        json[i]["description"],
        json[i]["capacity"],
      );

      //  TODO Add value calculation based on events, when there will be more than 1 event
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
        (json[i]["resourceNodeProportions"] as ResourceNodeProportion[])
          .map(rnp => new owp(
            modelsService.resourceNodeEvents.filter(rne => rne.id === rnp.resourceNodeEventId)[0],
            rnp.proportionValue)),
      );

      territories.push(region);
    }

    return territories;
  }
}