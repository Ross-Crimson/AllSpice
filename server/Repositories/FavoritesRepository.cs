




namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE favorites.id = LAST_INSERT_ID()
        ;";

        FavoriteRecipe favorite = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
        {
            recipe.favoriteId = favorite.Id;
            recipe.Creator = profile;
            return recipe;
        }, favoriteData).FirstOrDefault();

        return favorite;
    }

    internal void DestroyFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites WHERE id = @favoriteId
        ;";

        int rowsAffected = _db.Execute(sql, new { favoriteId });

        if (rowsAffected == 0)
        {
            throw new Exception("DELETE failed");
        }
        if (rowsAffected > 1)
        {
            throw new Exception("Deleted all favorites, this shouldn't have happened");
        }
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"
        SELECT * FROM favorites WHERE id = @favoriteId
        ;";

        Favorite favoriteRecipe = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();

        return favoriteRecipe;
    }

    internal List<FavoriteRecipe> GetUserFavoriteRecipes(string userId)
    {
        string sql = @"
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE favorites.accountId = @userId
        ;";

        List<FavoriteRecipe> favoriteRecipes = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
        {
            recipe.favoriteId = favorite.Id;
            recipe.Creator = profile;
            return recipe;
        }, new { userId }).ToList();

        return favoriteRecipes;
    }
}