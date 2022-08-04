<script lang="ts" setup>

import {inject, ref, Ref} from "vue";
import {Character} from "../models/character/Character";
import {ResourceHerb} from "../models/items/ResourceHerb";

const character: Ref<Character> = inject("character") as Ref<Character>;

let herbs = ref(0);

function GatherHerbs() {
  character.value.currentInventory
      .AddItem(new ResourceHerb(1, "simpleHerb", "Herb", 5, 1), 1);
  console.log(character.value.currentInventory);
  herbs.value = character.value.currentInventory.CountItems("simpleHerb");
}
</script>

<template>
  <h1>Region</h1>
  <button @click="GatherHerbs">Gather Herbs</button>
  <h4>Herbs in inventory: {{ herbs }}</h4>
</template>

<style scoped>

</style>