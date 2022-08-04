<script lang="ts" setup>
import TheMainMenuPanel from './components/TheMainMenuPanel.vue';
import TheMainPanel from './components/TheMainPanel.vue';
import {ref} from "vue";
import {Feature} from "./models/Feature";

const features = ref([
  new Feature("Inventory", true),
  new Feature("Region", false),
  new Feature("Crafting", false),])

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
</script>

<template>
  <TheMainMenuPanel :model-value="features" @update:modelValue="newValue => ChangeActiveFeature(newValue)"/>
  <TheMainPanel :currentFeature="FindActiveFeature(features)"/>
</template>

<style scoped>

</style>
