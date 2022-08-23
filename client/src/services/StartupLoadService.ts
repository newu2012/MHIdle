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

  async LoadResourceNodeEventsFromServer(): Promise<ResourceNode[]> {
    const response: HttpResponse<[]> = await useFetch<[]>("/api/event");
    const json = response!.parsedBody!;

    const resourceNodes = [];

    for (let i = 0; i < json.length; i++) {
      const resourceNodeItems: ResourceNodeItem[] = (json[i]["resourceNodeItems"] as ResourceNodeItem[])
        .map(rni => {
          return new ResourceNodeItem(
            rni.itemId,
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
}