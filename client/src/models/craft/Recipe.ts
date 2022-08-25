import { Item } from "../items/Item";
import { RecipeMaterial } from "./RecipeMaterial";

export class Recipe {
  constructor(
    name: string,
    type: string,
    item: Item,
    duration: number,
    recipeMaterials: RecipeMaterial[],
    instrumentType: string,
    instrumentRequiredLevel: number,
    instrumentExpectedLevel: number) {
    this.name = name;
    this.type = type;
    this.item = item;
    this.duration = duration;
    this.recipeMaterials = recipeMaterials;
    this.instrumentType = instrumentType;
    this.instrumentRequiredLevel = instrumentRequiredLevel;
    this.instrumentExpectedLevel = instrumentExpectedLevel;
  }

  name: string;
  type: string;
  item: Item;
  duration: number;
  recipeMaterials: RecipeMaterial[];
  instrumentType: string;
  instrumentRequiredLevel: number;
  instrumentExpectedLevel: number;
}