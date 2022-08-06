import { Resource } from "./Resource";

export class ResourceHerb implements Resource {
  constructor(id: number,
              name: string,
              description: string,
              value: number,
              maximumInStack: number = 10) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.value = value;
    this.maximumInStack = maximumInStack;
  }

  id: number;
  name: string;
  description: string;
  maximumInStack: number;
  value: number;
}