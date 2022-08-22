<script lang="ts" setup>
import { markRaw, ref } from "vue";

import TheMainMenuPanel from "./components/TheMainMenuPanel.vue";
import TheMainPanel from "./components/TheMainPanel.vue";
import TheInventoryPanel from "./components/TheInventoryPanel.vue";
import TheRegionPanel from "./components/TheRegionPanel.vue";
import TheCraftingPanel from "./components/TheCraftingPanel.vue";

import { Feature } from "./models/Feature";
import TYPES from "./types";
import container from "./inversify.config";
import { StartupLoadService } from "./services/StartupLoadService";

const features = ref([
  new Feature("Inventory", true, markRaw(TheInventoryPanel)),
  new Feature("Region", false, markRaw(TheRegionPanel)),
  new Feature("Crafting", false, markRaw(TheCraftingPanel))]);

function ChangeActiveFeature(activeFeatureName: string) {
  for (let i = 0; i < features.value.length; i++) {
    features.value[i].active = features.value[i].name === activeFeatureName;
  }
}

function FindActiveFeature(features: Feature[]) {
  const activeFeature = features.find(f => f.active);
  if (activeFeature === undefined) {
    throw new TypeError("No active feature found.");
  }

  return activeFeature;
}

const startupLoadService = ref(container.get<StartupLoadService>(TYPES.StartupLoadService));
</script>

<template>
  <div
    v-if="startupLoadService.isLoaded"
    class="startupServiceLoaded"
  >
    <TheMainMenuPanel
      :model-value="features"
      @update:model-value="newValue => ChangeActiveFeature(newValue)"
    />
    <TheMainPanel :current-feature="FindActiveFeature(features)" />
  </div>
  <div
    v-else
    class="startupServiceLoading"
  >
    <div class="lds-ring">
      <div />
      <div />
      <div />
      <div />
    </div>
    <h1>Loading</h1>
  </div>
</template>

<style scoped>
.startupServiceLoaded {
  display: flex;
  height: 100%;
  width: 100%;
}

.startupServiceLoading {
  display: flex;
  flex-flow: column;
  height: 100%;
  width: 100%;
  align-items: center;
  place-content: center;
}

.lds-ring {
  display: inline-block;
  position: relative;
  width: 80px;
  height: 80px;
}

.lds-ring div {
  box-sizing: border-box;
  display: block;
  position: absolute;
  width: 64px;
  height: 64px;
  margin: 8px;
  border: 8px solid #fff;
  border-radius: 50%;
  animation: lds-ring 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
  border-color: #fff transparent transparent transparent;
}

.lds-ring div:nth-child(1) {
  animation-delay: -0.45s;
}

.lds-ring div:nth-child(2) {
  animation-delay: -0.3s;
}

.lds-ring div:nth-child(3) {
  animation-delay: -0.15s;
}

@keyframes lds-ring {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}

</style>
