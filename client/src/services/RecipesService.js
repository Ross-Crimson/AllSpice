import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
    async getRecipes() {
        const response = await api.get('api/recipes')
        const recipes = response.data.map(recipeData => new Recipe(recipeData))

        AppState.allRecipes = recipes
        //console.log("recipe data", AppState.recipes)
    }

    //here we'll assign the different categories of displayable recipes as well since the user has to be logged in to have favorites and have their own created recipes
    async getFavorites() {
        const response = await api.get('account/favorites')
        const favorites = response.data.map(favoriteData => new Favorite(favoriteData))

        const userFavorites = favorites.filter(favorite => favorite.creatorId == AppState.account.id)
        AppState.usersFavorites = userFavorites

        //turn favorite data into recipes
        const userFavRecipes = userFavorites.map(favRecipeData => new Recipe(favRecipeData))
        AppState.favoriteRecipes = userFavRecipes

        //filter all recipes for userId
        const userRecipes = AppState.allRecipes.filter(recipe => recipe.creator.id == AppState.account.id)
        AppState.userRecipes = userRecipes

        console.log("favorite data", userRecipes)
    }
}

export const recipesService = new RecipesService