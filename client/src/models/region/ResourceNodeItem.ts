export class ResourceNodeItem {
  constructor(id: number, proportionValue: number, itemId: number, resourceNodeEventId: number) {
    this.id = id;
    this.proportionValue = proportionValue;
    this.itemId = itemId;
    this.resourceNodeEventId = resourceNodeEventId;
  }

  id: number;
  proportionValue: number;
  itemId: number;
  resourceNodeEventId: number;
}