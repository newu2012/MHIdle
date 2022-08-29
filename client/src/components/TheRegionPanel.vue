<script lang="ts" setup>
import container from "../inversify.config";
import TYPES from "../types";
import { ModelsService } from "../services/ModelsService";
import { RegionService } from "../services/RegionService";
import { computed, onUnmounted, ref } from "vue";
import { Territory } from "../models/region/Territory";
import { ActionHuntCharacterService } from "../services/ActionHuntCharacterService";
import { ActionMainService } from "../services/ActionMainService";
import { Monster } from "../models/region/Monster";
import { HuntService } from "../services/HuntService";

const modelsService = ref(container.get<ModelsService>(TYPES.ModelsService));
const regionService = ref(container.get<RegionService>(TYPES.RegionService));
const huntService = ref(container.get<HuntService>(TYPES.HuntService));
const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService));
const actionHuntCharacterService = ref(container.get<ActionHuntCharacterService>(TYPES.ActionHuntCharacterService));

const activeTerritory = ref(regionService.value.activeTerritory.name);

function SetActive(territory: Territory) {
  regionService.value.ChangeTerritory(territory);
  activeTerritory.value = territory.name;
}

onUnmounted(() => {
  cancelAnimationFrame(actionHuntCharacterService.value.handle);
});

const canGather = computed(() => {
  return (regionService.value.activeEvent?.type !== "Monster" ||
    huntService.value.monsterCurrentHealth <= 0)
});

const activeActionService = computed(() => {
  return actionHuntCharacterService.value.action.name !== "Idle" ?
    actionHuntCharacterService.value :
    actionMainService.value;
});

const characterActionProgressValue = computed(() => {
  return activeActionService.value.action?.duration === 0 ?
    0 :
    activeActionService.value.elapsed / (activeActionService.value.action?.duration ?? 1000);
});

const actionName = computed(() => {
  return activeActionService.value.action?.name;
});

const actionDuration = computed(() => {
  return (((activeActionService.value.action?.duration ?? 0) /
    1000 - activeActionService.value.elapsed / 1000).toFixed(1) ?? "0") + "s";
});

const eventMeterMax = computed(() => {
  return regionService.value.activeEvent?.type === "Monster" &&
  huntService.value.monsterCurrentHealth > 0 ?
    (regionService.value.activeEvent as Monster).maximumHealth :
    regionService.value.activeEvent?.capacity;
});

const eventMeterCurrent = computed(() => {
  return regionService.value.activeEvent?.type === "Monster" &&
  huntService.value.monsterCurrentHealth > 0 ?
    huntService.value.monsterCurrentHealth :
    regionService.value.activeEventCapacity;
});
</script>

<template>
  <h1>Region</h1>
  <h2>
    Current place: {{ regionService.activeTerritory.regionName }} -
    {{ regionService.activeTerritory.name }}
  </h2>
  <div
    class="event-panel"
  >
    <div
      class="character-hunt-action"
    >
      <p class="action-name">
        {{ actionName }}
      </p>
      <progress :value="characterActionProgressValue" />
      <p>
        {{ actionDuration }}
      </p>
    </div>
    <div
      class="territory-event-panel"
    >
      <h3>{{ regionService.activeEvent?.name ?? "Unknown" }}</h3>
      <img
        :alt="regionService.activeEvent?.description"
        :src="regionService.activeEvent?.iconPath ?? '/icons/Unknown_Icon.png'"
        class="territory-event-icon"
      >
      <meter
        :max="eventMeterMax"
        :min="0"
        :value="eventMeterCurrent"
        :class="{'can-gather': canGather}"
        class="territory-event-meter"
      />
    </div>
  </div>
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

.event-panel {
  display: flex;
  flex-flow: row;
  justify-content: space-evenly;
}

.territory-event-panel {
  display: flex;
  flex-flow: column;
  align-items: center;
}

.territory-event-icon {
  height: 64px;
  width: 64px;
}

.territory-event-meter::-webkit-meter-bar {
  background: red;
}

.can-gather::-webkit-meter-optimum-value {
  background: orange;
}
</style>