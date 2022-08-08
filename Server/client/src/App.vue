<script lang="ts" setup>
import { markRaw, ref } from "vue";

import TheMainMenuPanel from "./components/TheMainMenuPanel.vue";
import TheMainPanel from "./components/TheMainPanel.vue";
import TheInventoryPanel from "./components/TheInventoryPanel.vue";
import TheRegionPanel from "./components/TheRegionPanel.vue";
import TheCraftingPanel from "./components/TheCraftingPanel.vue";

import { Feature } from "./models/Feature";
import { RegionService } from "./services/RegionService";
import TYPES from "./types";
import container from "./inversify.config";

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

container.get<RegionService>(TYPES.RegionService);
</script>

<template>
  <TheMainMenuPanel
    :model-value="features"
    @update:model-value="newValue => ChangeActiveFeature(newValue)"
  />
  <TheMainPanel :current-feature="FindActiveFeature(features)" />
</template>

<style scoped>

</style>
