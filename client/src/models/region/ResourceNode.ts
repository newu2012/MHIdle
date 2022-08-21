import { ObjectWithProportion as owp } from "../ObjectWithProportion";
import { Item } from "../items/Item";

export class ResourceNode extends owp<owp<Item>[]> {
  constructor(obj: owp<Item>[],
              value: number,
              id: number,
              name: string,
              description: string,
              capacity: number) {
    super(obj, value, name, description);
    this.obj = obj;
    this.id = id;
    this.capacity = capacity;
  }

  declare obj: owp<Item>[];
  id: number;
  capacity: number;
}