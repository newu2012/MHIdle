import { Territory } from "./Territory";

export class Region {
  constructor(
    name: string,
    order: number,
    description: string,
    territories: Territory[]) {
    this.name = name;
    this.order = order;
    this.description = description;
    this.territories = territories;
  }

  name: string;
  order: number;
  description: string;
  territories: Territory[];
}