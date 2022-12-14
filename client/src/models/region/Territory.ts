import { ObjectWithProportion as owp } from "../ObjectWithProportion";

export class Territory {
  constructor(
    name: string,
    description: string,
    regionName: string,
    order: number,
    isCity: boolean,
    isCamp: boolean,
    durationExploreOnEnter: number,
    durationExploreInTerritory: number,
    instrumentType: string,
    instrumentRequiredLevel: number,
    instrumentExpectedLevel: number,
    territoryEvents: owp<any>[]) {
    this.name = name;
    this.description = description;
    this.regionName = regionName;
    this.order = order;
    this.isCity = isCity;
    this.isCamp = isCamp;
    this.territoryEvents = territoryEvents;
    this.durationExploreOnEnter = durationExploreOnEnter;
    this.durationExploreInTerritory = durationExploreInTerritory;
    this.instrumentType = instrumentType;
    this.instrumentRequiredLevel = instrumentRequiredLevel;
    this.instrumentExpectedLevel = instrumentExpectedLevel;
  }

  name: string;
  description: string;
  regionName: string;
  order: number;
  isCity: boolean;
  isCamp: boolean;
  durationExploreOnEnter: number;
  durationExploreInTerritory: number;
  instrumentType: string = "binoculars";
  instrumentRequiredLevel: number;
  instrumentExpectedLevel: number;
  territoryEvents: owp<any>[];
}