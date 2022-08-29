import { TerritoryEvent } from "./TerritoryEvent";
import { TerritoryEventItem } from "./TerritoryEventItem";

export class ResourceNode extends TerritoryEvent {
  static FromParsedBody(json: any): ResourceNode {
    return new ResourceNode(
      (json["territoryEventItems"] as TerritoryEventItem[])
        .map(rni => {
          return new TerritoryEventItem(
            rni.itemName,
            rni.value,
            rni.minimumQuantity,
            rni.maximumQuantity,
          );
        }),
      json["name"],
      json["type"],
      json["description"],
      json["iconPath"],
      json["capacity"],
      json["durationSeconds"] * 1000, //  Convert seconds to ms
      json["instrumentType"],
      json["instrumentRequiredLevel"],
      json["instrumentExpectedLevel"],
    );
  }
}