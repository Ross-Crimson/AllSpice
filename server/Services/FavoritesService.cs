



namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteRecipe favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favoriteRecipe = _repository.GetFavoriteById(favoriteId);

        if (favoriteRecipe == null)
        {
            throw new Exception("No favorite to delete");
        }

        return favoriteRecipe;
    }

    internal string DestroyFavorite(int favoriteId, string userId)
    {
        Favorite favoriteToDestroy = GetFavoriteById(favoriteId);

        if (favoriteToDestroy.AccountId != userId)
        {
            throw new Exception("You cannot delete a favorite that isn't yours");
        }

        _repository.DestroyFavorite(favoriteId);

        return "Favorite was deleted";
    }

    internal List<FavoriteRecipe> GetUserFavoriteRecipes(string userId)
    {
        List<FavoriteRecipe> favoriteRecipes = _repository.GetUserFavoriteRecipes(userId);
        return favoriteRecipes;
    }
}