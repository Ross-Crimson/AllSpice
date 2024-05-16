



namespace AllSpice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO
        ingredients(name, quantity, recipeId)

        VALUES(@Name, @Quantity, @RecipeId);

        SELECT
        *
        FROM ingredients
        WHERE ingredients.id = LAST_INSERT_ID()
        ;";

        Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();

        return ingredient;


    }

    internal void DeleteIngredient(int ingredientId)
    {
        string sql = @"
        DELETE
        FROM ingredients
        WHERE Id = @ingredientId
        ;";

        _db.Execute(sql, new { ingredientId });
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE Id = @ingredientId
        ;";

        Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();

        return ingredient;
    }

    internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE recipeId = @recipeId
        ;";

        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();

        return ingredients;
    }
}