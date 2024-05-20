import { reactive } from 'vue'
import { Recipe } from './models/Recipe.js'
import { Favorite } from './models/Favorite.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,

  /** @type {Recipe[]} */
  visibleRecipes: [],

  /** @type {Recipe[]} */
  allRecipes: [],

  /** @type {Recipe[]} */
  favoriteRecipes: [],

  /** @type {Recipe[]} */
  userRecipes: [],

  /** @type {Recipe} */
  displayedRecipe: null,

  /** @type {Favorite[]} */
  usersFavorites: []
})