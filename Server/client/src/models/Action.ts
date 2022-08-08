export class Action {
  name?: string;
  duration?: number;
  func?: Function
  funcArgs?: any

  constructor(name?: string,
              duration?: number,
              func?: Function,
              ...args: any[]) {
    this.name = name;
    this.duration = duration;
    this.func = func;
    this.funcArgs = args;
  }

  Execute(...args: any[]) {
    this.func!(...args);
  }
}