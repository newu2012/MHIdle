import { ObjectWithProportion as owp } from "../ObjectWithProportion";

export class Territory {
  constructor(
    id: number,
    name: string,
    description: string,
    regionId: number,
    durationExploreOnEnter: number,
    durationExploreInTerritory: number,
    instrumentType: string,
    instrumentRequiredLevel: number,
    instrumentExpectedLevel: number,
    territoryEvents: owp<any>[]) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.regionId = regionId;
    this.territoryEvents = territoryEvents;
    this.durationExploreOnEnter = durationExploreOnEnter;
    this.durationExploreInTerritory = durationExploreInTerritory;
    this.instrumentType = instrumentType;
    this.instrumentRequiredLevel = instrumentRequiredLevel;
    this.instrumentExpectedLevel = instrumentExpectedLevel;
  }

  id: number;
  name: string;
  description: string;
  regionId: number;
  durationExploreOnEnter: number;
  durationExploreInTerritory: number;
  instrumentType: string = "binoculars";
  instrumentRequiredLevel: number;
  instrumentExpectedLevel: number;
  territoryEvents: owp<any>[];
}