import { injectable } from "inversify";
import { Region } from "../models/region/Region";
import { Territory } from "../models/region/Territory";
import { Item } from "../models/items/Item";
import { Recipe } from "../models/craft/Recipe";
import { TerritoryEvent } from "../models/region/TerritoryEvent";

@injectable()
export class ModelsService {
  regions: Region[] = [];
  territories: Territory[] = [];
  territoryEvents: TerritoryEvent[] = [];
  items: Item[] = [];
  recipes: Recipe[] = [];
}