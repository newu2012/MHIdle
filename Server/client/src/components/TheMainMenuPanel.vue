<script lang="ts" setup>
import TheMainMenuPanelItem from "./TheMainMenuPanelItem.vue";
import {Feature} from "../models/Feature";
import {ref} from "vue";

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
  <div class="TheMainMenuPanel">
    <ul>
      <li>
        <TheMainMenuPanelItem
            v-for="feature in features"
            :key="feature.name"
            :feature="feature"
            @set-active="ChangeActiveFeature(feature.name)"
        >
          {{ feature.name }}
        </TheMainMenuPanelItem>
      </li>
    </ul>
  </div>
</template>

<style scoped>
.TheMainMenuPanel {
  flex-basis: 320px;
  height: 100%;
  background-color: rgb(60, 63, 65);
}

ul {
  list-style: none;
  margin: 0;
  padding: 0;
}
</style>