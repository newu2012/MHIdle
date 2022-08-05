<script lang="ts" setup>
import { Feature } from "../models/Feature";

const props = defineProps<{
  feature: Feature
}>();

defineEmits(["set-active"]);
</script>

<template>
  <div class="TheMainMenuPanelItem">
    <button
      :class="{ active:props.feature.active }"
      @click="$emit('set-active', props.feature.name)"
    >
      <slot />
    </button>
  </div>
</template>

<style scoped>
.TheMainMenuPanelItem {
  height: 64px;
}

button {
  height: 100%;
  width: 100%;
  border: 0;
  border-bottom: 1px white solid;
  text-align: start;
  font-weight: 600;
  font-size: 24px;
}

button:hover {
  background-color: #5f96baaa;
}

.active {
  background-color: #5f96ba;
}
</style>