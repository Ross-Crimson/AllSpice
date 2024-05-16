namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0provider;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0provider)
    {
        _favoritesService = favoritesService;
        _auth0provider = auth0provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<FavoriteRecipe>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            FavoriteRecipe favorite = _favoritesService.CreateFavorite(favoriteData);
            return Ok(favorite);

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [Authorize]
    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult<string>> DestroyFavorite(int favoriteId)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            string deleteMessage = _favoritesService.DestroyFavorite(favoriteId, userInfo.Id);
            return Ok(deleteMessage);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}