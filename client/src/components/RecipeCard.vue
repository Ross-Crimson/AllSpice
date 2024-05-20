<script setup>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { Favorite } from '../models/Favorite.js';
import { AppState } from '../AppState.js';


const props = defineProps({ recipe: { type: Recipe, required: true } })

const userFavorites = computed(() => AppState.usersFavorites)
const backgroundImg = computed(() => `url(${props.recipe?.img})`)
const account = computed(() => AppState.account)

</script>


<template>
    <section v-if="recipe">
        <div class="card d-flex justify-content-between text-light">
            <div class="px-1 py-1 d-flex justify-content-between align-items-center">

                <div class="text-start glass px-3 py-1">
                    {{ recipe.category }}
                </div>

                <div class="px-3 fs-3">
                    <div v-if="account && userFavorites.find(fav => fav.id == recipe.id)">
                        <i class="mdi mdi-heart" style="color: red;"></i>
                    </div>
                    <div v-else>
                        <i class="mdi mdi-heart-outline"></i>
                    </div>
                </div>
            </div>

            <div class="m-1 p-2 glass">
                <div>{{ recipe.title }}</div>
            </div>
        </div>
    </section>
</template>


<style lang="scss" scoped>
.card {
    aspect-ratio: 1/1;
    width: 90%;
    border-radius: 1em;
    filter: drop-shadow(0 0 0.5rem rgb(68, 68, 68));
    background-image: v-bind(backgroundImg);
    background-position: center;
    background-size: cover;
}

.glass {
    background: rgba(68, 68, 68, 0.59);
    border-radius: 1em;
    backdrop-filter: blur(7.5px);
    -webkit-backdrop-filter: blur(7.5px);
}
</style>