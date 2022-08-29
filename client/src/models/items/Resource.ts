import { Item } from "./Item";

export class Resource extends Item {
  constructor(name: string, type: string, description: string, rarity: number, value: number, imagePath: string, maximumInInventory: number, maximumInStorage: number, resourceType: string) {
    super(name, type, description, rarity, value, imagePath, maximumInInventory, maximumInStorage);
    this.resourceType = resourceType;
  }

  resourceType: string;

  static FromParsedBody(json: any): Resource {
    return new Resource(
      json["name"],
      json["type"],
      json["description"],
      json["rarity"],
      json["value"],
      json["imagePath"],
      json["maximumInInventory"],
      json["maximumInStorage"],
      json["resourceType"],
    );
  }
}