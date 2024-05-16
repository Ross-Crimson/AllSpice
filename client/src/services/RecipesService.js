import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
    async getRecipes() {
        const response = await api.get('api/recipes')
        console.log("recipe data", response)
        const recipes = response.data.map(recipeData => new Recipe(recipeData))

        AppState.recipes = recipes
    }
}

export const recipesService = new RecipesService