<script lang="ts" setup>
import TheMainMenuPanel from './components/TheMainMenuPanel.vue';
import TheMainPanel from './components/TheMainPanel.vue';
import {ref} from "vue";
import {Feature} from "./models/Feature";

const features = ref([
  new Feature("Inventory", true),
  new Feature("Region", false),
  new Feature("Craft", false),])

function ChangeActiveFeature(activeFeatureName: string) {
  for (let i = 0; i < features.value.length; i++) {
    features.value[i].active = features.value[i].name === activeFeatureName;
  }
}
</script>

<template>
  <TheMainMenuPanel :model-value="features" @update:modelValue="newValue => ChangeActiveFeature(newValue)"/>
  <TheMainPanel/>
</template>

<style scoped>

</style>
