import { ObjectWithProportion as owp } from "../ObjectWithProportion";
import { ResourceNodeItem } from "./ResourceNodeItem";

export class ResourceNode extends owp<ResourceNodeItem[]> {
  constructor(obj: ResourceNodeItem[],
              id: number,
              name: string,
              description: string,
              capacity: number,
              duration: number,
              instrumentType: string,
              instrumentRequiredLevel: number,
              instrumentExpectedLevel: number) {
    super(obj, 0, name, description);
    this.obj = obj;
    this.id = id;
    this.capacity = capacity;
    this.duration = duration;
    this.instrumentType = instrumentType;
    this.instrumentRequiredLevel = instrumentRequiredLevel;
    this.instrumentExpectedLevel = instrumentExpectedLevel;
  }

  declare obj: ResourceNodeItem[];
  id: number;
  capacity: number;
  duration: number;
  instrumentType: string;
  instrumentRequiredLevel: number;
  instrumentExpectedLevel: number;
}