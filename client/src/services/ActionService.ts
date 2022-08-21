import { injectable } from "inversify";
import { Ref, ref } from "vue";
import { Action } from "../models/Action";

@injectable()
export class ActionService {
  action: Ref<Action>;
  elapsed = ref(0);

  lastTime: number;
  handle: number;
  update: Function = this.Update.bind(this);

  Update() {
    if (this.elapsed.value === this.action.value?.duration) {
      this.RestartActionTimer();
      this.lastTime = performance.now();
      this.action.value.Execute(this.action.value.funcArgs);
    } else {
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

  RestartActionTimer() {
    this.elapsed.value = 0;
  }

  //  TODO Set changing currentAction only by selection from list of Actions
  availableActions = {
    explore: this.#Explore,
  };

  #Explore() {
    // return new Action(
    //   "Gather herbs",
    //   10 * 1000,
    //   this.regionService.GatherHerbs, this.character);
  }
}