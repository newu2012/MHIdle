<script lang="ts" setup>
import { ItemStack } from "../models/items/ItemStack";

defineProps<{
  itemStackProp: ItemStack
}>();

defineEmits(["update:itemStackProp"]);

</script>

<template>
  <div class="itemStack">
    <p class="quantity">
      {{ itemStackProp?.quantity }}
    </p>
  </div>
</template>


<style scoped>
.itemStack {
  width: inherit;
  position: relative;
}

.itemStack:hover {
  cursor: pointer;
}

.quantity {
  margin: 0;
  position: absolute;
  bottom: 0;
  font-size: small;
  text-align: center;
  width: 100%;
}
</style>