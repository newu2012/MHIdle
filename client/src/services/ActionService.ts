import { Ref, ref } from "vue";
import { Action } from "../models/Action";
import { injectable } from "inversify";

@injectable()
export abstract class ActionService {
  action: Ref<Action>;
  elapsed = ref(0);
  lastTime: number;
  handle: number;
  update: Function = this.Update.bind(this);

  Update() {
    //  TODO Think out how to work with undefined durations
    if (this.action.value?.duration === undefined) {
      this.action.value.duration = 0;
      this.action.value.Execute();
    } else if (this.elapsed.value >= this.action.value?.duration &&
      this.action.value?.duration !== 0) {
      this.RestartActionTimer();
      this.lastTime = performance.now();
      this.action.value.Execute();
    } else if (this.action.value?.duration !== 0) {
      const time = performance.now();
      this.elapsed.value += Math.min(time - this.lastTime, this.action.value?.duration! - this.elapsed.value);
      this.lastTime = time;
    }

    this.handle = requestAnimationFrame(<FrameRequestCallback>this.update);
  }

  SetCurrentAction(action: Action) {
    this.action = ref(action);
    this.RestartActionTimer();
    this.lastTime = performance.now();
    this.update();
  }

  //  Override with getting actual actionService and setting elapsed = 0
  RestartActionTimer() {
    // const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    // actionService.elapsed = 0;
    this.elapsed.value = 0;
  }

  availableActions = {
    idle: this.Idle,
  };

  Idle() {
    return new Action(
      "Idle",
      undefined,
      () => {
      });
  }
}