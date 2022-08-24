<script lang="ts" setup>
</script>

<template>
  <h1>Crafting</h1>
  <div class="inventory-panel">
    <div class="grid-container">
      <div
        v-for="(itemStack, index) in selectedInventory.itemStacks"
        :key="index"
        class="grid-item"
        @click="SetActive(index)"
      >
        <CraftingItem
          :item-stack-prop="itemStack"
        />
      </div>
    </div>
  </div>
</template>

<style scoped>
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
</style>