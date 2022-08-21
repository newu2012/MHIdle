//  TODO change to interface after creating other classes
export class ObjectWithProportion<T> {
  constructor(obj: T,
              value: number,
              name?: string,
              description?: string) {
    this.obj = obj;
    this.value = value;
    this.name = name;
    this.description = description;
  }

  obj: T;
  value: number;
  name?: string;
  description?: string;
}