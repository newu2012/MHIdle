<script lang="ts" setup>
import { ItemStack } from "../models/items/ItemStack";

const props = defineProps<{
  itemStackProp: ItemStack
}>();

defineEmits(["update:itemStackProp"]);
</script>

<template>
  <div
    v-if="itemStackProp.item !== undefined"
    :style="{backgroundImage: `url(${props.itemStackProp.item?.imagePath})`}"
    class="itemStack"
  >
    <p class="quantity">
      {{ itemStackProp?.quantity }}
    </p>
  </div>
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

.quantity {
  margin: 0;
  position: absolute;
  bottom: -4px;
  font-size: small;
  text-align: center;
  width: 100%;
}
</style>