import { ObjectWithProportion as owp } from "../ObjectWithProportion";
import { Item } from "../items/Item";

export class ResourceNode extends owp<owp<Item>[]> {
  constructor(obj: owp<Item>[],
              value: number,
              id: number,
              name: string,
              description: string,
              capacity: number,
              inTerritoryIds: number[]) {
    super(obj, value, name, description);
    this.obj = obj;
    this.id = id;
    this.capacity = capacity;
    this.inTerritoryIds = inTerritoryIds;
  }

  declare obj: owp<Item>[];
  id: number;
  capacity: number;
  inTerritoryIds: number[];
}