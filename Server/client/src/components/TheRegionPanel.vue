<script lang="ts" setup>

import { ref } from "vue";
import { Character } from "../models/character/Character";
import { RegionService } from "../services/RegionService";
import TYPES from "../types";
import container from "../inversify.config";

const character: Character = container.get<Character>(TYPES.Character);
const regionService: RegionService = container.get<RegionService>(TYPES.RegionService);

const herbs = ref(character.currentInventory
  .CountItems("simpleHerb") ?? 0);

function Gather() {
  herbs.value = regionService.GatherHerbs();
}

console.log(character.currentInventory);
</script>

<template>
  <h1>Region</h1>
  <button @click="Gather">
    Gather Herbs
  </button>
  <h4>Herbs in inventory: {{ herbs }}</h4>
</template>

<style scoped>

</style>