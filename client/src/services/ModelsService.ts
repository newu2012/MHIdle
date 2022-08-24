import { injectable } from "inversify";
import { Region } from "../models/region/Region";
import { Territory } from "../models/region/Territory";
import { Item } from "../models/items/Item";
import { ResourceNode } from "../models/region/ResourceNode";
import { Recipe } from "../models/craft/Recipe";

@injectable()
export class ModelsService {
  regions: Region[] = [];
  territories: Territory[] = [];
  resourceNodeEvents: ResourceNode[] = [];
  items: Item[] = [];
  recipes: Recipe[] = [];
}