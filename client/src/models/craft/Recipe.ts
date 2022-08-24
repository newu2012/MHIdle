import { Item } from "../items/Item";
import { RecipeMaterial } from "./RecipeMaterial";

export class Recipe {
  constructor(
    id: number,
    type: string,
    item: Item,
    duration: number,
    recipeMaterials: RecipeMaterial[],
    instrumentType: string,
    instrumentRequiredLevel: number,
    instrumentExpectedLevel: number) {
    this.id = id;
    this.type = type;
    this.item = item;
    this.duration = duration;
    this.recipeMaterials = recipeMaterials;
    this.instrumentType = instrumentType;
    this.instrumentRequiredLevel = instrumentRequiredLevel;
    this.instrumentExpectedLevel = instrumentExpectedLevel;
  }

  id: number;
  type: string;
  item: Item;
  duration: number;
  recipeMaterials: RecipeMaterial[];
  instrumentType: string;
  instrumentRequiredLevel: number;
  instrumentExpectedLevel: number;
}