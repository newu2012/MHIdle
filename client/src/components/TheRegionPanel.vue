<script lang="ts" setup>
import container from "../inversify.config";
import TYPES from "../types";
import { ModelsService } from "../services/ModelsService";
import { RegionService } from "../services/RegionService";
import { ref } from "vue";
import { Territory } from "../models/region/Territory";

const modelsService: ModelsService = container.get<ModelsService>(TYPES.ModelsService);
const regionService: RegionService = container.get<RegionService>(TYPES.RegionService);

const activeTerritory = ref(regionService.activeTerritory.name);

function SetActive(territory: Territory) {
  //  TODO call change active territory method in regionService
  regionService.ChangeTerritory(territory);
  activeTerritory.value = territory.name;
}
</script>

<template>
  <h1>Region</h1>
  <h2>
    Current place: {{ modelsService.regions.filter(r => r.id === regionService.activeTerritory.regionId)[0].name }} -
    {{ regionService.activeTerritory.name }}
  </h2>
  <h3>Regions</h3>
  <div
    v-for="region in modelsService.regions"
    :key="region.name"
  >
    <span>{{ region.name }} - {{ region.description }}</span>
    <h3>Territories</h3>
    <div
      v-for="territory in modelsService.territories.filter(t => t.regionId === region.id)"
      :key="territory.name"
    >
      <button
        :class="{activeTerritory: territory.name === activeTerritory}"
        @click="SetActive(territory)"
      >
        {{ territory.name }} - {{
          territory.description
        }}
      </button>
    </div>
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
.activeTerritory {
  background-color: #87939a;
}
</style>