<script setup>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';


const activeRecipe = computed(() => AppState.displayedRecipe)


</script>


<template>
    <!-- <div v-if="activeRecipe"> -->
    <div class="modal fade modal-lg" id="activeRecipeModal" tabindex="-1" aria-labelledby="activeRecipeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body container">
                    <div class="row">
                        <div class="col">
                            <img v-bind:src="activeRecipe?.img" alt="" class="img-fluid recipe-img">
                        </div>
                        <div class="col d-flex flex-column justify-content-between">
                            <div class="row">
                                <div class="d-flex align-items-center">
                                    <h3>{{ activeRecipe?.title }}</h3>
                                    <div class="px-2 py-1 mx-3 text-light glass">{{ activeRecipe?.category }}</div>
                                </div>
                                <div class="pt-3">
                                    {{ activeRecipe?.instructions }}
                                </div>
                            </div>

                            <div class="row text-end">
                                <div> {{ activeRecipe?.creator.name }}</div>
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
    max-width: 30dvw;
    height: auto;
}
</style>