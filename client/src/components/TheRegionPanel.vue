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
  regionService.ChangeTerritory(territory);
  activeTerritory.value = territory.name;
}
</script>

<template>
  <h1>Region</h1>
  <h2>
    Current place: {{ regionService.activeTerritory.regionName }} -
    {{ regionService.activeTerritory.name }}
  </h2>
  <div
    v-for="region in modelsService.regions"
    :key="region.name"
    class="regionStyle"
  >
    <h3>{{ region.name }} - {{ region.description }}</h3>
    <div
      v-for="territory in modelsService.territories.filter(t => t.regionName === region.name)"
      :key="territory.name"
      class="territoryStyle"
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
</template>

<style scoped>
.regionStyle {
  padding: 16px 32px;
  text-align: start;
}

.territoryStyle {
  padding: 8px 0;
}

.activeTerritory {
  background-color: #87939a;
}
</style>