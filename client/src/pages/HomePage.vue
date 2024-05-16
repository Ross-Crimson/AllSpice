<script setup>
import { computed, onMounted } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';

const recipes = computed(() => AppState.recipes)

async function getRecipes() {
  try {
    await recipesService.getRecipes()
  } catch (error) {
    error.log(error)
  }
}

onMounted(() => getRecipes())
</script>

<template>
  <div>
    {{ recipes }}
  </div>
</template>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
