<script lang="ts" setup>
import { onUnmounted, ref } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import TYPES from "../types";

const character = ref(container.get<Character>(TYPES.Character));

//  TODO Change to actual action progress
const duration = ref(15 * 1000);
const elapsed = ref(0);
const actionName = ref("Exploring");

let lastTime = performance.now();
let handle: number;
const update = () => {
  const time = performance.now();
  elapsed.value += Math.min(time - lastTime, duration.value - elapsed.value);
  lastTime = time;
  handle = requestAnimationFrame(update);
};

update();
onUnmounted(() => {
  cancelAnimationFrame(handle);
});
</script>

<template>
  <div class="character-info">
    <p class="character-name">
      {{ character.name }}
    </p>
    <div class="stats">
      <div>
        <span>Items </span>
        <img>
        <span>{{ character.currentInventory.itemStacks.length }}</span>
      </div>
    </div>
    <div class="current-action">
      <p class="action-name">
        {{ actionName }}
      </p>
      <progress :value="elapsed / duration" />
      <p>{{ (duration / 1000 - elapsed / 1000).toFixed(1) }}s</p>
    </div>
  </div>
</template>

<style scoped>
* {
  margin: 0;
}

.character-info {
  padding: 8px;
}

.character-name {
  font-size: larger;
  font-weight: 600;
}

.current-action {
  display: flex;
  gap: 8px;
  align-items: center;
}

.action-name {
  width: 140px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

progress {
  width: 100px;
}
</style>