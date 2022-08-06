<script lang="ts" setup>

import { ref } from "vue";
import { Character } from "../models/character/Character";
import { RegionService } from "../services/RegionService";
import TYPES from "../types";
import container from "../inversify.config";

const character: Character = container.get<Character>(TYPES.Character);
const regionService: RegionService = container.get<RegionService>(TYPES.RegionService);

const herbsInInventory = ref(character.currentInventory
  .GetItemOrEmptyItemStack("simpleHerb"));

function Gather() {
  regionService.GatherHerbs();
  console.log(herbsInInventory);
}
</script>

<template>
  <h1>Region</h1>
  <button @click="Gather">
    Gather Herbs
  </button>
  <h4>Herbs in inventory: {{ herbsInInventory.quantity }}</h4>
</template>

<style scoped>

</style>