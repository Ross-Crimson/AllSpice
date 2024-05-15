


namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }

    internal string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipeToDestroy = GetRecipeById(recipeId);

        if (recipeToDestroy.CreatorId != userId)
        {
            throw new Exception("You cannot delete another Chef's creation");
        }

        _repository.DestroyRecipe(recipeId);

        return $"${recipeToDestroy.Title} has been deleted";
    }

    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repository.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"{recipeId} does not exist, search a new flavor");
        }

        return recipe;
    }

    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData, string userId)
    {
        Recipe recipeToUpdate = GetRecipeById(recipeId);

        if (recipeToUpdate.CreatorId != userId)
        {
            throw new Exception($"You do not have access to update recipe {recipeToUpdate.Title} Chef");
        }

        recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
        recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;

        Recipe updatedRecipe = _repository.UpdateRecipe(recipeToUpdate);
        return updatedRecipe;
    }
}