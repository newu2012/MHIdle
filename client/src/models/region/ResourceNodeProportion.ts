export class ResourceNodeProportion {
  constructor(
    id: number,
    value: number,
    territoryName: string,
    territoryEventName: string) {
    this.id = id;
    this.value = value;
    this.territoryName = territoryName;
    this.territoryEventName = territoryEventName;
  }

  id: number;
  value: number;
  territoryName: string;
  territoryEventName: string;
}