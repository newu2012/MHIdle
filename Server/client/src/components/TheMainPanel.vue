<script lang="ts" setup>

import {Feature} from "../models/Feature";

import TheInventoryPanel from "./TheInventoryPanel.vue";
import TheRegionPanel from "./TheRegionPanel.vue";
import TheCraftingPanel from "./TheCraftingPanel.vue";

const props = defineProps<{
  currentFeature: Feature
}>()

</script>

<template>
  <div class="TheMainPanel">
    <TheInventoryPanel v-if="props.currentFeature.name === 'Inventory'"></TheInventoryPanel>
    <TheRegionPanel v-else-if="props.currentFeature.name === 'Region'"></TheRegionPanel>
    <TheCraftingPanel v-else-if="props.currentFeature.name === 'Crafting'"></TheCraftingPanel>
  </div>
</template>

<style scoped>
.TheMainPanel {
  flex-grow: 1;
  text-align: center;
  height: 100%;
  background-color: rgb(43, 43, 43);
}
</style>