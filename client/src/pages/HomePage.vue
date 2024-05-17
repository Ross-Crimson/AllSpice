<script setup>
import { computed, onMounted, watch } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';
import Pop from '../utils/Pop.js';

const recipes = computed(() => AppState.recipes)
const account = computed(() => AppState.account)

watch(account, getFavorites)

async function getRecipes() {
  try {
    await recipesService.getRecipes()
  } catch (error) {
    error.log(error)
  }
}

async function getFavorites() {
  try {
    console.log("geting favorites")
    await recipesService.getFavorites()
  }
  catch (error) {
    Pop.error(error);
  }
}

onMounted(() => getRecipes())
</script>

<template>
  <section class="container">

    <div class="row mt-3 mb-5 hero-banner align-items-end align-content-end text-center">
      <div class="text-light">
        <h1 style="text-shadow: ;">RECIPE</h1>
      </div>
      <div style="transform: translate(0px, 45px);">
        <div class="btn-group" role="group" aria-label="Basic example">
          <button type="button" class="button-group-button px-5 py-4"
            style="border-radius: 4px 0px 0px 4px">Home</button>
          <button type="button" class="button-group-button px-5 py-4" style="border-radius: 0px 0px 0px 0px">My
            Recipes</button>
          <button type="button" class="button-group-button px-5 py-4"
            style="border-radius: 0px 4px 4px 0px">Favorites</button>
        </div>
      </div>

    </div>

    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-4 p-3">
        <RecipeCard :recipe="recipe" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.hero-banner {
  background-image: url('../assets/img/fork.jpg');
  height: 30dvh;
  background-position: center;
  background-size: cover;

  filter: contrast(150%);
}

.button-group-button {
  align-items: center;
  appearance: button;
  background-color: #515151;
  color: white;
  border-style: none;
  box-shadow: rgba(255, 255, 255, 0.26) 0 1px 2px inset;
  box-sizing: border-box;
  cursor: pointer;
  display: flex;
  flex-direction: row;
  flex-shrink: 0;
  font-size: 100%;
  line-height: 1.15;
  margin: 0;
  padding: 10px 21px;
  text-align: center;
  text-transform: none;
  transition: color .13s ease-in-out, background .13s ease-in-out, opacity .13s ease-in-out, box-shadow .13s ease-in-out;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
}

.button-group-button:active {
  background-color: wheat;
}

.button-group-button:hover {
  background-color: wheat;
  color: #515151;
}
</style>
