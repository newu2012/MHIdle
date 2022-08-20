import { ObjectWithProportion } from "../ObjectWithProportion";

export class Territory {
  constructor(id: number, name: string, description: string, regionId: number, territoryEvents: ObjectWithProportion<any>[]) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.regionId = regionId;
    this.territoryEvents = territoryEvents;
  }

  id: number;
  name: string;
  description: string;
  regionId: number;
  territoryEvents: ObjectWithProportion<any>[];
}