<script lang="ts" setup>

import { Recipe } from "../models/craft/Recipe";
import { computed, ref } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import TYPES from "../types";
import { ItemStack } from "../models/items/ItemStack";
import CraftingPanelRecipeMaterial from "./CraftingPanelRecipeMaterial.vue";
import { CraftService } from "../services/CraftService";

const props = defineProps<{
  recipe?: Recipe,
}>();

defineEmits([
  "update:itemPanelProp",
  "craft-item"]);

const character = ref(container.get<Character>(TYPES.Character));
const craftService = ref(container.get<CraftService>(TYPES.CraftService));

const itemInStorage = computed(() => {
  return props.recipe === undefined ?
    undefined :
    character.value.storageInventory
      .GetItemOrEmptyItemStack(props.recipe?.item.name) as ItemStack;
});
const storageFull = computed(() => {
  return (character.value.storageInventory
      .GetItemOrEmptyItemStack(props.recipe?.item.name!) as ItemStack).quantity ===
    props.recipe?.item.maximumInStorage;
});

const itemInCurrent = computed(() => {
  return props.recipe === undefined ?
    undefined :
    character.value.currentInventory
      .GetItemOrEmptyItemStack(props.recipe?.item.name) as ItemStack;
});
const currentFull = computed(() => {
  return (character.value.currentInventory
      .GetItemOrEmptyItemStack(props.recipe?.item.name!) as ItemStack).quantity ===
    props.recipe?.item.maximumInInventory;
});

const maximumToCraft = computed(() => {
  return craftService.value.CanCraftAmount(props.recipe!);
});
</script>

<template>
  <div class="the-crafting-item-panel">
    <h2
      v-if="recipe === undefined"
      class="no-item-selected"
    >
      No item selected
    </h2>
    <div
      v-else
      class="item"
    >
      <div class="item-name-and-type">
        <h3 class="item-name">
          {{ recipe.item?.name }}
        </h3>
        <h3 class="item-type">
          {{ recipe.item?.type }}
        </h3>
      </div>
      <div class="item-info">
        <div class="item-description-row">
          <img
            :src="`${props.recipe?.item?.imagePath}`"
            alt="Item image"
            class="item-icon"
          >
          <p class="item-description">
            {{ recipe.item?.description }}
          </p>
        </div>
        <div class="item-additional-info">
          <p class="item-rarity">
            Rarity {{ recipe.item?.rarity }}
          </p>
          <p class="item-value">
            Value {{ recipe.item?.value }}
          </p>
          <div>
            <p
              :class="{'item-quantity-full': currentFull }"
              class="item-quantity"
            >
              In Inventory
              {{ itemInCurrent?.quantity ?? 0 }}/{{ recipe.item?.maximumInInventory }}
            </p>
            <p
              :class="{'item-quantity-full': storageFull }"
              class="item-quantity"
            >
              In Storage
              {{ itemInStorage?.quantity ?? 0 }}/{{ recipe.item?.maximumInStorage }}
            </p>
          </div>
        </div>
      </div>
      <div
        class="recipe-materials"
      >
        <CraftingPanelRecipeMaterial
          v-for="recipeMaterial in recipe.recipeMaterials"
          :key="recipeMaterial.itemId"
          :recipe-material="recipeMaterial"
        />
      </div>
      <div class="actions-row">
        <div class="craft-one">
          <button
            :disabled="maximumToCraft === 0"
            @click="$emit('craft-item', 1)"
          >
            Craft 1
          </button>
          <span>{{ recipe.duration / 1000 }} s</span>
        </div>
        <div class="craft-all">
          <button
            :disabled="maximumToCraft === 0"
            @click="$emit('craft-item', maximumToCraft)"
          >
            Craft All ({{ maximumToCraft }})
          </button>
          <span>{{ recipe.duration * maximumToCraft / 1000 }} s</span>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.the-crafting-item-panel {
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
  gap: 16px;
}

.item-name-and-type {
  display: flex;
  justify-content: space-between;
}

.item-name {
  margin: 0;
}

.item-type {
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
  align-items: center;
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

.recipe-materials {
  width: 100%;
  display: flex;
  flex-flow: column;
  gap: 8px;
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