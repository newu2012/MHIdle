<script lang="ts" setup>
import { RecipeMaterial } from "../models/craft/RecipeMaterial";
import { computed, ref } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import TYPES from "../types";
import { ItemStack } from "../models/items/ItemStack";

const props = defineProps<{
  recipeMaterial: RecipeMaterial,
}>();

defineEmits([
    "update:recipeMaterial",
  ],
);

const character = ref(container.get<Character>(TYPES.Character));

const quantityInStorage = computed(() => {
  const itemStack = character.value.storageInventory.GetItemOrEmptyItemStack(props.recipeMaterial.item.name) as ItemStack;
  return itemStack.item === undefined ? 0 : itemStack.quantity;
});
</script>

<template>
  <div class="recipe-material">
    <img
      :alt="recipeMaterial.item.description"
      :src="`${props.recipeMaterial.item.imagePath}`"
      class="recipe-material-icon"
    >
    <span>{{ props.recipeMaterial.item.name }}</span>
    <span>{{ quantityInStorage }}/{{ recipeMaterial.quantity }}</span>
  </div>
</template>

<style scoped>
.recipe-material {
  display: flex;
  gap: 16px;
  align-items: center;
  text-align: start;
}

.recipe-material-icon {
  height: 40px;
  width: 40px;
}
</style>