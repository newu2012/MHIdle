<script lang="ts" setup>
import {markRaw, provide, ref} from "vue";

import TheMainMenuPanel from './components/TheMainMenuPanel.vue';
import TheMainPanel from './components/TheMainPanel.vue';
import TheInventoryPanel from './components/TheInventoryPanel.vue';
import TheRegionPanel from './components/TheRegionPanel.vue';
import TheCraftingPanel from './components/TheCraftingPanel.vue';

import {Feature} from "./models/Feature";
import {Character} from "./models/character/Character";

const features = ref([
  new Feature("Inventory", true, markRaw(TheInventoryPanel) ),
  new Feature("Region", false, markRaw(TheRegionPanel)),
  new Feature("Crafting", false, markRaw(TheCraftingPanel)),])

const character = ref(new Character());

function ChangeActiveFeature(activeFeatureName: string) {
  for (let i = 0; i < features.value.length; i++) {
    features.value[i].active = features.value[i].name === activeFeatureName;
  }
}

function FindActiveFeature(features: Feature[]) {
  const activeFeature = features.find(f => f.active);
  if (activeFeature === undefined) {
    throw new TypeError("No active feature found.")
  }

  return activeFeature;
}

provide("character", character);
</script>

<template>
  <TheMainMenuPanel :model-value="features" @update:modelValue="newValue => ChangeActiveFeature(newValue)"/>
  <TheMainPanel :currentFeature="FindActiveFeature(features)"/>
</template>

<style scoped>

</style>
