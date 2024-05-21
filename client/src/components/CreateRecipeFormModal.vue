<script setup>
import { computed, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';
import { Modal } from 'bootstrap';

const account = computed(() => AppState.account)

const recipeData = ref({
    title: '',
    instructions: '',
    img: '',
    category: ''
})

async function createRecipe() {
    try {
        await recipesService.createRecipe(account.value.id, recipeData.value)

        recipeData.value = {
            title: '',
            instructions: '',
            img: '',
            category: ''
        }

        Modal.getOrCreateInstance('#createRecipeModal').hide()
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div class="modal fade" id="createRecipeModal" tabindex="-1" aria-labelledby="createRecipeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="createRecipeModalLabel">Modal title</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <form action="">

                    </form>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>