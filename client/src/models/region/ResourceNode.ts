import { Resource } from "../items/Resource";
import { ObjectWithProportion as owp } from "../ObjectWithProportion";

export class ResourceNode extends owp<owp<Resource>[]> {

  constructor(obj: owp<Resource>[], value: number, name: string, capacity: number) {
    super(obj, value, name);
    this.obj = obj;
    this.capacity = capacity;
  }

  declare obj: owp<Resource>[];
  capacity: number;
}