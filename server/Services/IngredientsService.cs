

namespace AllSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)
    {
        _repository = repository;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
    {
        Ingredient ingredient = _repository.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsForRecipe(recipeId);
        return ingredients;
    }
}