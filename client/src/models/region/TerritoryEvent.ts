import { TerritoryEventItem } from "./TerritoryEventItem";
import { ObjectWithProportion as owp } from "../ObjectWithProportion";

export class TerritoryEvent extends owp<TerritoryEventItem[]> {
  constructor(obj: TerritoryEventItem[],
              name: string,
              type: string,
              description: string,
              capacity: number,
              duration: number,
              instrumentType: string,
              instrumentRequiredLevel: number,
              instrumentExpectedLevel: number) {
    super(obj, 0, name, description);
    this.obj = obj;
    this.name = name;
    this.type = type;
    this.capacity = capacity;
    this.duration = duration;
    this.instrumentType = instrumentType;
    this.instrumentRequiredLevel = instrumentRequiredLevel;
    this.instrumentExpectedLevel = instrumentExpectedLevel;
  }

  declare obj: TerritoryEventItem[];
  name: string;
  type: string;
  capacity: number;
  duration: number;
  instrumentType: string;
  instrumentRequiredLevel: number;
  instrumentExpectedLevel: number;
}