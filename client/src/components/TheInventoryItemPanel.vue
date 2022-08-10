<script lang="ts" setup>
import { ItemStack } from "../models/items/ItemStack";
import { computed } from "vue";

const itemQuantityFull = computed(() => {
  return props.itemPanelProp!.quantity === (props.isStorage ? props.itemPanelProp!.item?.maximumInStorage : props.itemPanelProp!.item?.maximumInInventory);
});

const props = defineProps<{
  itemPanelProp?: ItemStack,
  isStorage: boolean,
}>();

defineEmits([
  "update:itemPanelProp",
  "sell-item",
  "send-to-current",
  "send-to-storage"]);
</script>

<template>
  <div class="the-inventory-item-panel">
    <h2
      v-if="itemPanelProp === undefined"
      class="no-item-selected"
    >
      No item selected
    </h2>
    <div
      v-else
      class="item"
    >
      <h3 class="item-name">
        {{ itemPanelProp.item?.name }}
      </h3>
      <div class="item-info">
        <div class="item-description-row">
          <img
            :src="`${props.itemPanelProp.item?.imagePath}`"
            alt="Item image"
            class="item-icon"
          >
          <p class="item-description">
            {{ itemPanelProp.item?.description }}
          </p>
        </div>
        <div class="item-additional-info">
          <p class="item-rarity">
            Rarity {{ itemPanelProp.item?.rarity }}
          </p>
          <p class="item-value">
            Value {{ itemPanelProp.item?.value }}
          </p>
          <p
            :class="{'item-quantity-full': itemQuantityFull }"
            class="item-quantity"
          >
            In {{ isStorage ? "storage" : "current" }}
            {{ itemPanelProp.quantity }}/{{
              isStorage ? itemPanelProp.item?.maximumInStorage : itemPanelProp.item?.maximumInInventory
            }}
          </p>
        </div>
      </div>
      <div
        v-if="isStorage"
        class="actions-row"
      >
        <div class="sell-one">
          <button @click="$emit('sell-item', 1)">
            Sell 1
          </button>
          <span>{{ itemPanelProp.item?.value }} zenny</span>
        </div>
        <div class="sell-all">
          <button @click="$emit('sell-item', itemPanelProp?.quantity)">
            Sell All
          </button>
          <span>{{ (itemPanelProp.item?.value ?? 0) * itemPanelProp?.quantity }} zenny</span>
        </div>
        <div class="send-to-current">
          <button @click="$emit('send-to-current', itemPanelProp)">
            Send to inventory
          </button>
        </div>
      </div>
      <div
        v-else
        class="actions-row"
      >
        <div class="send-to-storage">
          <button @click="$emit('send-to-storage', itemPanelProp)">
            Send to storage
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.the-inventory-item-panel {
  width: 100%;
  background-color: #3c3f41;
  border-radius: 16px;
  padding: 16px;
}

.no-item-selected {
  margin: 0;
  padding: 16px;
}

.item {
  display: flex;
  flex-flow: column;
  gap: 8px;
}

.item-name {
  margin: 0;
}

.item-info {
  display: flex;
  flex-flow: column;
  gap: 8px;
  text-align: start;
}

.item-description-row {
  display: flex;
  flex-flow: row;
  gap: 8px;
}

.item-icon {
  height: 40px;
  width: 40px;
}

.item-description {
  margin: 0;
}

.item-additional-info {
  display: flex;
  flex-flow: row;
  gap: 8px;
  justify-content: space-between;
}

.item-rarity {
  margin: 0;
}

.item-value {
  margin: 0;
}

.item-quantity {
  margin: 0;
}

.item-quantity-full {
  color: darkorange;
}

.actions-row {
  display: flex;
  justify-content: space-between;
}

.actions-row > div {
  display: flex;
  flex-flow: column;
  gap: 4px;
}

.actions-row > div > button {
  border-color: maroon;
  border-radius: 8px;
}
</style>