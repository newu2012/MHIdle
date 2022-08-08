<script lang="ts" setup>
import { onUnmounted, ref } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import TYPES from "../types";
import { ActionService } from "../services/ActionService";

const character = ref(container.get<Character>(TYPES.Character));
const actionService = ref(container.get<ActionService>(TYPES.ActionService));

onUnmounted(() => {
  cancelAnimationFrame(actionService.value.handle);
});
</script>

<template>
  <div class="character-info">
    <p class="character-name">
      {{ character.name }}
    </p>
    <div class="stats">
      <div>
        <span>Health </span>
        <img>
        <span>{{ character.health }}/{{ character.maxHealth }}</span>
      </div>
      <div>
        <span>Stamina </span>
        <img>
        <span>{{ character.stamina }}/{{ character.maxStamina }}</span>
      </div>
    </div>
    <div class="current-action">
      <p class="action-name">
        {{ actionService.action?.name ?? "Nothing" }}
      </p>
      <progress :value="(actionService.elapsed / actionService.action?.duration)" />
      <p>{{ (actionService.action?.duration / 1000 - actionService.elapsed / 1000).toFixed(1) ?? "0" }}s</p>
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

.stats {
  display: flex;
  gap: 8px;
  justify-content: space-between;
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