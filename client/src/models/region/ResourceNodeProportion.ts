export class ResourceNodeProportion {
  constructor(id: number, proportionValue: number, territoryId: number, resourceNodeEventId: number) {
    this.id = id;
    this.proportionValue = proportionValue;
    this.territoryId = territoryId;
    this.resourceNodeEventId = resourceNodeEventId;
  }

  id: number;
  proportionValue: number;
  territoryId: number;
  resourceNodeEventId: number;
}