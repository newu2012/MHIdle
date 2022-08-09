<script lang="ts" setup>
import { ItemStack } from "../models/items/ItemStack";

defineProps<{
  itemPanelProp?: ItemStack
}>();

defineEmits(["update:itemPanelProp", 'sell-item']);
</script>

<template>
  <div class="the-inventory-item-panel">
    <h3>TheInventoryItemPanel</h3>
    <div
      v-if="itemPanelProp !== undefined"
      class="item"
    >
      <h4>{{ itemPanelProp.item?.name }}</h4>
      <button @click="$emit('sell-item', 1)">
        Sell 1
      </button>
    </div>
  </div>
</template>

<style scoped>
.the-inventory-item-panel {
  width: 100%;
  background-color: #3c3f41;
  border-radius: 16px;
}
</style>