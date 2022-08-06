<script lang="ts" setup>

import { RegionService } from "../services/RegionService";
import TYPES from "../types";
import container from "../inversify.config";

const regionService: RegionService = container.get<RegionService>(TYPES.RegionService);

function Gather() {
  regionService.GatherHerbs();
}
</script>

<template>
  <h1>Region</h1>
  <button @click="Gather">
    Gather Herbs
  </button>
</template>

<style scoped>

</style>