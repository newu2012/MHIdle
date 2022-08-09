<script lang="ts" setup>
import TYPES from "../types";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import InventoryItemStack from "./InventoryItemStack.vue";
import { computed, ref } from "vue";
import TheInventoryItemPanel from "./TheInventoryItemPanel.vue";

const character = ref(container.get<Character>(TYPES.Character));

const currentInventory = ref(true);
const selectedInventory = computed(() => {
  return currentInventory.value ? character.value.currentInventory : character.value.storageInventory;
});

let selectedItemIndex = ref(-1);
let selectedItemStack =
  computed(() => selectedItemIndex.value !== -1 &&
  selectedInventory.value.itemStacks[selectedItemIndex.value].item === undefined ?
    undefined :
    selectedInventory.value.itemStacks[selectedItemIndex.value]);

function SetActive(itemStackIndex: number) {
  selectedItemIndex.value = itemStackIndex;
}

function SellItem(quantity: number) {
  selectedInventory.value.SellItem(selectedInventory.value.itemStacks[selectedItemIndex.value].item!.id!, quantity);
  if (selectedInventory.value.itemStacks[selectedItemIndex.value].item === undefined) {
    selectedItemIndex.value = -1;
  }
}
</script>

<template>
  <h1>Inventory</h1>
  <div class="inventory-switch">
    <p>Storage</p>
    <label class="switch">
      <input
        v-model="currentInventory"
        type="checkbox"
      >
      <span class="slider round" />
    </label>
    <p>Current</p>
  </div>
  <div class="inventory-panel">
    <div class="grid-container">
      <div
        v-for="(itemStack, index) in selectedInventory.itemStacks"
        :key="index"
        class="grid-item"
        @click="SetActive(index)"
      >
        <InventoryItemStack
          :item-stack-prop="itemStack"
        />
      </div>
    </div>
    <TheInventoryItemPanel
      :item-panel-prop="selectedItemStack"
      class="the-inventory-item-panel"
      @sell-item="newValue => SellItem(newValue)"
    />
  </div>
</template>

<style scoped>
.inventory-switch {
  display: inline-flex;
  align-items: center;
  gap: 8px;
}

.inventory-panel {
  display: flex;
  flex-flow: row;
  padding: 32px;
  gap: 32px;
}

.the-inventory-item-panel {
  flex-basis: 400px;
  width: 400px;
}

.grid-container {
  flex-grow: 1;
  display: grid;
  height: min-content;
  padding: 16px;
  grid-template-columns: repeat(auto-fill, 64px);
  grid-auto-rows: 64px;
  grid-gap: 16px;
  justify-content: center;
  border: inset darkgoldenrod;
  border-radius: 16px;
}

.grid-item {
  display: flex;
  height: 64px;
  width: 64px;
  border-radius: 16px;
  background-color: rgba(135, 147, 154, 0.96);
}

/* The switch - the box around the slider */
.switch {
  align-content: start;
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

/* Hide default HTML checkbox */
.switch input {
  opacity: 0;
  width: 0;
  height: 0;
}

/* The slider */
.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>