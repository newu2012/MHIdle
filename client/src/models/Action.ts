export class Action {
  constructor(name: string,
              duration: number,
              func?: Function) {
    this.name = name;
    this.duration = duration;
    this.func = func;
  }

  name: string;
  duration: number;
  func?: Function;

  Execute() {
    this.func!();
  }
}