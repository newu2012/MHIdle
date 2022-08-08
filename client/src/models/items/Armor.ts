import { Equipment } from "./Equipment";

export class Armor implements Equipment {
  id: number;
  name: string;
  description: string;
  maximumInStack: number;
  value: number;
}