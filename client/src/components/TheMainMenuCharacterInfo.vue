<script lang="ts" setup>
import { computed, onUnmounted, ref } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import TYPES from "../types";
import { ActionMainService } from "../services/ActionMainService";

const character = ref(container.get<Character>(TYPES.Character));
const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService));

onUnmounted(() => {
  cancelAnimationFrame(actionMainService.value.handle);
});

const progressValue = computed(() => {
  return actionMainService.value.action?.duration === 0 ?
    0 :
    actionMainService.value.elapsed / (actionMainService.value.action?.duration ?? 1000);
});
</script>

<template>
  <div class="character-info">
    <p class="character-name">
      {{ character.name }}
    </p>
    <div class="currencies">
      <div>
        <span>Zenny </span>
        <img>
        <span>{{ character.currencies.zennyFormatted }}</span>
      </div>
      <div>
        <span>ResearchPoints </span>
        <img>
        <span>{{ character.currencies.researchPointsFormatted }}</span>
      </div>
    </div>
    <div class="current-action">
      <p class="action-name">
        {{ actionMainService.action?.name ?? "Nothing" }}
      </p>
      <progress :value="progressValue" />
      <p>{{ ((actionMainService.action?.duration ?? 0) / 1000 - actionMainService.elapsed / 1000).toFixed(1) ?? "0" }}s</p>
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

.currencies {
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