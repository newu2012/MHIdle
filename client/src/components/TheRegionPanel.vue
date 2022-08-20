<script lang="ts" setup>
import container from "../inversify.config";
import TYPES from "../types";
import { ModelsService } from "../services/ModelsService";

const modelsService = container.get<ModelsService>(TYPES.ModelsService);
</script>

<template>
  <h1>Region</h1>
  <h3>Regions</h3>
  <div
    v-for="region in modelsService.regions"
    :key="region.name"
  >
    <span>{{ region.name }} - {{ region.description }}</span>
  </div>
  <h3>Territories</h3>
  <div
    v-for="territory in modelsService.territories"
    :key="territory.name"
  >
    <span>{{ territory.name }} - {{ territory.description }}</span>
  </div>
  <h3>Items</h3>
  <div
    v-for="item in modelsService.items"
    :key="item.name"
  >
    <span>{{ item.name }} - {{ item.description }}</span>
  </div>
</template>

<style scoped>

</style>