export class ResourceNodeProportion {
  constructor(
    id: number,
    value: number,
    territoryName: string,
    resourceNodeEventName: string) {
    this.id = id;
    this.value = value;
    this.territoryName = territoryName;
    this.resourceNodeEventName = resourceNodeEventName;
  }

  id: number;
  value: number;
  territoryName: string;
  resourceNodeEventName: string;
}