//  TODO change to interface after creating other classes
export class ObjectWithProportion<T> {
  constructor(obj: T,
              value: number,
              name?: string) {
    this.obj = obj;
    this.value = value;
    this.name = name;
  }

  obj: T;
  value: number;
  name?: string;
}