<script lang="ts" setup>
import { ItemStack } from "../models/items/ItemStack";

defineProps<{
  itemStackProp: ItemStack
}>();

defineEmits(["update:itemStackProp"]);

</script>

<template>
  <div class="itemStack">
    <p>
      {{ itemStackProp?.item?.name ?? "" }} ({{ itemStackProp?.quantity }}/{{
        itemStackProp?.item?.maximumInStack ?? 0
      }})
    </p>
  </div>
</template>


<style scoped>
.itemStack {
  width: inherit;
}
</style>