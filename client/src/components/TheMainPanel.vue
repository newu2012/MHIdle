<script lang="ts" setup>

import { Feature } from "../models/Feature";

const props = defineProps<{
  currentFeature: Feature
}>();

</script>

<template>
  <div class="TheMainPanel">
    <component :is="props.currentFeature.componentPanel" />
  </div>
</template>

<style scoped>
.TheMainPanel {
  flex-grow: 1;
  text-align: center;
  background-color: rgb(43, 43, 43);
}
</style>