import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { api } from "./AxiosService.js"


class IngredientsService {
    async createIngredient(recipeId, ingredientFormData) {
        const ingredientData = { name: ingredientFormData.name, quantity: ingredientFormData.quantity, recipeId: recipeId }
        const response = await api.post(`api/ingredients`, ingredientData)

        const newIngredient = new Ingredient(response.data)
        AppState.activeRecipeIngredients.push(newIngredient)
    }
    async getIngredients(recipeId) {
        AppState.activeRecipeIngredients = []
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        //console.log("recipe ingredients", response.data)
        const ingredients = response.data.map(ing => new Ingredient(ing))

        AppState.activeRecipeIngredients = ingredients
    }

}

export const ingredientsService = new IngredientsService