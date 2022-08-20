import { Territory } from "./Territory";

export class Region {
  constructor(id: number, name: string, description: string, territories: Territory[]) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.territories = territories;
  }

  id: number;
  name: string;
  description: string;
  territories: Territory[];
}