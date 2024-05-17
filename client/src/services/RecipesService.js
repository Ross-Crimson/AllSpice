import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
    async getRecipes() {
        const response = await api.get('api/recipes')
        const recipes = response.data.map(recipeData => new Recipe(recipeData))

        AppState.recipes = recipes
        //console.log("recipe data", AppState.recipes)
    }

    async getFavorites() {
        const response = await api.get('account/favorites')
        const favorites = response.data.map(favoriteData => new Favorite(favoriteData))
        AppState.allFavorites = favorites;
        const userFavorites = favorites.filter(favorite => favorite.creatorId == AppState.account.id)
        AppState.usersFavorites = userFavorites

        console.log("favorite data", AppState.usersFavorites)
    }
}

export const recipesService = new RecipesService