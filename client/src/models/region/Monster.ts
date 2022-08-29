import { TerritoryEvent } from "./TerritoryEvent";
import { MonsterPart } from "./MonsterPart";
import { TerritoryEventItem } from "./TerritoryEventItem";

export class Monster extends TerritoryEvent {
  constructor(
    obj: TerritoryEventItem[],
    name: string,
    type: string,
    description: string,
    capacity: number,
    duration: number,
    instrumentType: string,
    instrumentRequiredLevel: number,
    instrumentExpectedLevel: number,
    iconPath: string,
    maximumHealth: number,
    startingHealth: number,
    monsterParts: MonsterPart[]) {
    super(obj, name, type, description, iconPath, capacity, duration, instrumentType, instrumentRequiredLevel, instrumentExpectedLevel);
    this.iconPath = iconPath;
    this.maximumHealth = maximumHealth;
    this.startingHealth = startingHealth;
    this.monsterParts = monsterParts;
  }

  iconPath: string;
  maximumHealth: number;
  startingHealth: number;
  monsterParts: MonsterPart[];

  static FromParsedBody(json: any): Monster {
    return new Monster(
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
      json["capacity"],
      json["durationSeconds"] * 1000, //  Convert seconds to ms
      json["instrumentType"],
      json["instrumentRequiredLevel"],
      json["instrumentExpectedLevel"],
      json["iconPath"],
      json["maximumHealth"],
      json["startingHealth"],
      (json["monsterParts"] as MonsterPart[])
        .map(mp => {
          return new MonsterPart(
            mp.partName,
            mp.partType,
            mp.maximumHealth,
            mp.startingHealth,
          );
        }),
    );
  }
}