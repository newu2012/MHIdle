import { ObjectWithProportion as owp } from "../ObjectWithProportion";
import { ResourceNodeItem } from "./ResourceNodeItem";

export class ResourceNode extends owp<ResourceNodeItem[]> {
  constructor(obj: ResourceNodeItem[],
              id: number,
              name: string,
              description: string,
              capacity: number) {
    super(obj, 0, name, description);
    this.obj = obj;
    this.id = id;
    this.capacity = capacity;
  }

  declare obj: ResourceNodeItem[];
  id: number;
  capacity: number;
}