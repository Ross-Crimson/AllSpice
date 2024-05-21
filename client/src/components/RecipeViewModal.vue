<script setup>
import { computed, ref, watch } from 'vue';
import { AppState } from '../AppState.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Pop from '../utils/Pop.js';

const account = computed(() => AppState.account)
const activeRecipe = computed(() => AppState.displayedRecipe)
const currentIngredients = computed(() => AppState.activeRecipeIngredients)
const usersRecipe = computed(() => {
    if (account.value?.id == activeRecipe.value?.creator.id) return true
    return false
})

watch(activeRecipe, getIngredients)

async function getIngredients() {
    try {
        if (activeRecipe.value == null) return
        await ingredientsService.getIngredients(activeRecipe.value.id)
    }
    catch (error) {
        Pop.error(error);
    }
}


//ingredients
const ingredientFormData = ref({
    name: '',
    quantity: ''
})

async function createIngredient() {
    try {
        await ingredientsService.createIngredient(activeRecipe.value.id, ingredientFormData.value)

        ingredientFormData.value = {
            name: '',
            quantity: ''
        }
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <!-- <div v-if="activeRecipe"> -->
    <div class="modal fade modal-lg" id="activeRecipeModal" tabindex="-1" aria-labelledby="activeRecipeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body container">
                    <div class="row">
                        <div class="col-12 col-md-4 p-0 order-2 order-md-1">
                            <img v-bind:src="activeRecipe?.img" alt="" class="img-fluid">
                        </div>
                        <div class="col-12 col-md-8 d-flex flex-column justify-content-between order-1 order-md-2">
                            <div class="row">
                                <div class="d-flex align-items-center">
                                    <h3>{{ activeRecipe?.title }}</h3>
                                    <div class="px-2 py-1 mx-3 text-light glass">{{ activeRecipe?.category }}</div>
                                </div>

                                <div>
                                    <div class="p-3 mt-4 visual">
                                        <h5 class="fw-bold">Instructions</h5>
                                        <hr>
                                        <div>
                                            {{ activeRecipe?.instructions }}
                                        </div>
                                    </div>
                                </div>

                                <div v-if="currentIngredients.length > 0">
                                    <div class="p-3 mt-4 visual">
                                        <h5 class="fw-bold">Ingredients</h5>
                                        <hr>
                                        <div v-for="ingredient in currentIngredients" :key="ingredient.id">
                                            <div class="d-flex">{{ ingredient.quantity }} {{ ingredient.name }}</div>

                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="row mt-2">

                                <div v-if="usersRecipe" class="pt-2">
                                    <h5>Add Ingredient</h5>

                                    <form @submit.prevent="createIngredient()" class="d-flex">
                                        <div class="form-floating mb-3">
                                            <input v-model="ingredientFormData.name" type="text" class="form-control"
                                                id="name" placeholder="Name of ingredient" required maxlength="255">
                                            <label for="name">Name</label>
                                        </div>

                                        <div class="form-floating mb-3">
                                            <input v-model="ingredientFormData.quantity" type="text"
                                                class="form-control" id="quantity" placeholder="Quantity of ingredient"
                                                required maxlength="255">
                                            <label for="name">Quantity</label>
                                        </div>
                                        <div style="transform: translateY(10px);">
                                            <button type="submit" class="btn btn-dark">Add</button>
                                        </div>
                                    </form>

                                </div>

                                <div class="text-end pt-2">
                                    <div> {{ activeRecipe?.creator.name }}</div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
                <!-- <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div> -->
            </div>
        </div>
    </div>
    <!-- </div> -->
</template>


<style lang="scss" scoped>
.glass {
    background: rgba(68, 68, 68, 0.59);
    border-radius: 1em;
    backdrop-filter: blur(7.5px);
    -webkit-backdrop-filter: blur(7.5px);
}

.recipe-img {
    max-width: 20dvw;
    height: auto;
}

.visual {
    background-color: rgb(250, 235, 204);
    border-radius: 1em;
}
</style>