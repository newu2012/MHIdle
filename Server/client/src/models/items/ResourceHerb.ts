import { Resource } from "./Resource";

export class ResourceHerb implements Resource {
  constructor(id: number, name: string, description: string, maximumInStack: number, value: number) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.maximumInStack = maximumInStack;
    this.value = value;
  }

  id: number;
  name: string;
  description: string;
  maximumInStack: number;
  value: number;
}