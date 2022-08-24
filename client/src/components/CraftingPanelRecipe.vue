<script lang="ts" setup>
import { Recipe } from "../models/craft/Recipe";

const props = defineProps<{
  recipe: Recipe
}>();

defineEmits(["update:recipe"]);
</script>

<template>
  <div
    v-if="recipe.item !== undefined"
    :style="{backgroundImage: `url(${props.recipe.item?.imagePath})`}"
    class="itemStack"
  />
</template>


<style scoped>
.itemStack {
  width: inherit;
  position: relative;
  background-repeat: no-repeat;
  background-position: center;
  background-size: 40px 40px;
}

.itemStack:hover {
  cursor: pointer;
}
</style>