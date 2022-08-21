import { injectable } from "inversify";
import { Region } from "../models/region/Region";
import { Territory } from "../models/region/Territory";
import { Item } from "../models/items/Item";
import { ObjectWithProportion } from "../models/ObjectWithProportion";

@injectable()
export class ModelsService {
  regions: Region[] = [];
  territories: Territory[] = [];
  resourceNodeEvents: ObjectWithProportion<any>[] = [];
  items: Item[] = [];
}