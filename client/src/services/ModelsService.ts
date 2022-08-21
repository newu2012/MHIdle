import { injectable } from "inversify";
import { Region } from "../models/region/Region";
import { Territory } from "../models/region/Territory";
import { Item } from "../models/items/Item";
import { ObjectWithProportion } from "../models/ObjectWithProportion";
import { ResourceNodeItem } from "../models/region/ResourceNodeItem";
import { ResourceNodeProportion } from "../models/region/ResourceNodeProportion";

@injectable()
export class ModelsService {
  regions: Region[] = [];
  territories: Territory[] = [];
  resourceNodeEvents: ObjectWithProportion<any>[] = [];
  resourceNodeProportions: ResourceNodeProportion[] = [];
  resourceNodeItems: ResourceNodeItem[] = [];
  items: Item[] = [];
}