export class ResourceNodeProportion {
  constructor(
    id: number,
    value: number,
    territoryName: string,
    resourceNodeName: string) {
    this.id = id;
    this.value = value;
    this.territoryName = territoryName;
    this.resourceNodeName = resourceNodeName;
  }

  id: number;
  value: number;
  territoryName: string;
  resourceNodeName: string;
}