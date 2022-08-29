<script lang="ts" setup>
import container from "../inversify.config";
import TYPES from "../types";
import { ModelsService } from "../services/ModelsService";
import { RegionService } from "../services/RegionService";
import { computed, ref } from "vue";
import { Territory } from "../models/region/Territory";

const modelsService = ref(container.get<ModelsService>(TYPES.ModelsService));
const regionService = ref(container.get<RegionService>(TYPES.RegionService));

const activeTerritory = ref(regionService.value.activeTerritory.name);

function SetActive(territory: Territory) {
  regionService.value.ChangeTerritory(territory);
  activeTerritory.value = territory.name;
}

const monsterInTerritory = computed(() => {
  return regionService.value.activeEvent?.type === "Monster";
});
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
    class="region-style"
  >
    <h3>{{ region.name }} - {{ region.description }}</h3>
    <div class="territories">
      <div
        v-for="territory in modelsService.territories.filter(t => t.regionName === region.name)"
        :key="territory.name"
        :title="territory.description"
        class="territory-style"
      >
        <button
          :class="{activeTerritory: territory.name === activeTerritory}"
          @click="SetActive(territory)"
        >
          {{ territory.name }}
        </button>
      </div>
    </div>
  </div>
  <div
    v-if="monsterInTerritory"
    class="hunt-panel"
  >
    <h3>{{ regionService.activeEvent?.name }}</h3>
    <img
      :alt="regionService.activeEvent?.description"
      :src="regionService.activeEvent?.iconPath"
      class="monster-icon"
    >
    <meter
      :max="regionService.activeEvent?.maximumHealth"
      :min="0"
      :value="regionService.activeEvent?.currentHealth"
      class="monster-health"
    />
  </div>
</template>

<style scoped>
.region-style {
  padding: 16px 32px;
  text-align: start;
}

.territories {
  display: flex;
  gap: 8px;
}

.activeTerritory {
  background-color: #87939a;
}

.hunt-panel {
  display: flex;
  flex-flow: column;
  align-items: center;
}

.monster-icon {
  height: 64px;
  width: 64px;
}

.monster-health::-webkit-meter-bar {
  background: red;
}
</style>