<script lang="ts" setup>
import { ref } from "vue";
import container from "../inversify.config";
// import { Character } from "../models/character/Character";
import TYPES from "../types";

import TheCraftingItemPanel from "./TheCraftingItemPanel.vue";
import { ModelsService } from "../services/ModelsService";
import CraftingRecipe from "./CraftingRecipe.vue";

// const character = ref(container.get<Character>(TYPES.Character));
const modelsService = ref(container.get<ModelsService>(TYPES.ModelsService));

let selectedRecipe = ref(-1);

function SetActive(itemStackIndex: number) {
  selectedRecipe.value = itemStackIndex;
}

function CraftItem(quantity: number) {
  //  TODO Change to craft
  console.log(quantity);
  // storageInventory.SellItem(
  //   selectedInventory.value.itemStacks[selectedItemIndex.value].item!.id!, quantity);
  // if (selectedInventory.value.itemStacks[selectedItemIndex.value].item === undefined) {
  //   selectedItemIndex.value = -1;
  // }
}
</script>

<template>
  <h1>Crafting</h1>
  <div class="crafting-panel">
    <div class="grid-container">
      <div
        v-for="(recipe, index) in modelsService.recipes"
        :key="index"
        class="grid-item"
        @click="SetActive(index)"
      >
        <CraftingRecipe
          :recipe="recipe"
        />
      </div>
    </div>
    <TheCraftingItemPanel
      :recipe="modelsService.recipes[selectedRecipe]"
      class="the-crafting-item-panel"

      @craft-item="newValue => CraftItem(newValue)"
    />
  </div>
</template>

<style scoped>
.crafting-panel {
  display: flex;
  flex-flow: row;
  padding: 32px;
  gap: 32px;
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

.the-crafting-item-panel {
  flex-basis: 400px;
  width: 400px;
}
</style>