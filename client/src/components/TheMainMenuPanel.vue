<script lang="ts" setup>
import TheMainMenuPanelItem from "./TheMainMenuPanelItem.vue";
import TheMainMenuCharacterInfo from "./TheMainMenuCharacterInfo.vue";
import { Feature } from "../models/Feature";

defineProps<{ modelValue: Feature[] }>();

defineEmits(["update:model-value"]);
</script>

<template>
  <div class="TheMainMenuPanel">
    <ul>
      <TheMainMenuCharacterInfo />
      <TheMainMenuPanelItem
        v-for="feature in modelValue"
        :key="feature.name"
        :feature="feature"
        @set-active="$emit('update:model-value', feature.name)"
      >
        {{ feature.name }}
      </TheMainMenuPanelItem>
    </ul>
  </div>
</template>

<style scoped>
.TheMainMenuPanel {
  flex-basis: 320px;
  width: 320px;
  height: 100%;
  background-color: rgb(60, 63, 65);
}

ul {
  list-style: none;
  margin: 0;
  padding: 0;
}
</style>