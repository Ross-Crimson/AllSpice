

namespace AllSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
    {
        _repository = repository;
        _recipesService = recipesService;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
    {
        //use ingredientData.recipeId to get recipe from recipe service and check the owner against userId to see if can create
        Recipe recipeToCheck = _recipesService.GetRecipeById(ingredientData.RecipeId);

        if (recipeToCheck.CreatorId != userId)
        {
            throw new Exception("Cannot add ingredient to recipe you don't own");
        }

        Ingredient ingredient = _repository.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal string DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient ingredientToDelete = GetIngredientById(ingredientId);
        Recipe recipeToCheck = _recipesService.GetRecipeById(ingredientToDelete.RecipeId);

        if (recipeToCheck.CreatorId != userId)
        {
            throw new Exception("You cannot delete an ingredient from another chef's recipe");
        }

        _repository.DeleteIngredient(ingredientId);

        return "Ingredient was deleted";
    }

    internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsForRecipe(recipeId);
        return ingredients;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _repository.GetIngredientById(ingredientId);

        if (ingredient == null)
        {
            throw new Exception($"Can't find ingredient with id: {ingredientId}");
        }
        return ingredient;
    }
}