<script lang="ts" setup>
import { ItemStack } from "../models/items/ItemStack";
// import { computed } from "vue";

// const imagePath = computed(() => {
//   return props.itemStackProp.item?.imagePath;
// });

defineProps<{
  itemStackProp: ItemStack
}>();

defineEmits(["update:itemStackProp"]);
</script>

<template>
  <div
    v-if="itemStackProp.item !== undefined"
    class="itemStack"
    :style="{'backgroundImage': 'url(' + require('@/assets/icons/Herb_Icon_Green.png') +')'}"
  >
<!--    <img-->
<!--      alt="Item Icon"-->
<!--      :src="require(`@/assets/icons/Herb_Icon_Green.png`)"-->
<!--    >-->
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
  bottom: 0;
  font-size: small;
  text-align: center;
  width: 100%;
}
</style>