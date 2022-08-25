import { Territory } from "./Territory";

export class Region {
  constructor(
    name: string,
    description: string,
    territories: Territory[]) {
    this.name = name;
    this.description = description;
    this.territories = territories;
  }

  name: string;
  description: string;
  territories: Territory[];
}