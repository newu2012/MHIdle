<script lang="ts" setup>
import TheMainMenuPanelItem from "./TheMainMenuPanelItem.vue";
import {Feature} from "../models/Feature";

defineProps<{ modelValue: Feature[] }>()
</script>

<template>
  <div class="TheMainMenuPanel">
    <ul>
      <li>
        <TheMainMenuPanelItem
            v-for="feature in modelValue"
            :key="feature.name"
            :feature="feature"
            @set-active="$emit('update:modelValue', feature.name)"
        >
          {{ feature.name }}
        </TheMainMenuPanelItem>
      </li>
    </ul>
  </div>
</template>

<style scoped>
.TheMainMenuPanel {
  flex-basis: 320px;
  height: 100%;
  background-color: rgb(60, 63, 65);
}

ul {
  list-style: none;
  margin: 0;
  padding: 0;
}
</style>