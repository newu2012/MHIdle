export class ResourceNodeProportion {
  constructor(id: number, value: number, territoryId: number, resourceNodeEventId: number) {
    this.id = id;
    this.value = value;
    this.territoryId = territoryId;
    this.resourceNodeEventId = resourceNodeEventId;
  }

  id: number;
  value: number;
  territoryId: number;
  resourceNodeEventId: number;
}