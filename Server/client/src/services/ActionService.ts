import { injectable } from "inversify";
import { Ref, ref } from "vue";
import { Action } from "../models/Action";

@injectable()
export class ActionService {
  action: Ref<Action>;
  elapsed = ref(0);

  lastTime: number;
  handle: number;

  RefreshAction() {
    if (this.elapsed.value === this.action.value?.duration) {
      this.elapsed.value = 0;
      this.lastTime = performance.now();
      this.action.value.Execute(this.action.value.funcArgs);
      this.Update();
    } else {
      this.Update();
    }
  }

  Update() {
    const time = performance.now();
    this.elapsed.value += Math.min(time - this.lastTime, this.action.value?.duration! - this.elapsed.value);
    this.lastTime = time;
    this.handle = requestAnimationFrame(this.Update);
  }

  SetCurrentAction(action: Action) {
    this.action = ref(action);
    this.elapsed.value = 0;
    this.lastTime = performance.now();
    setInterval(() => {
      this.RefreshAction();
    }, 1000);
  }
}