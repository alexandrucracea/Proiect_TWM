using Proiect_TWM.Configuration.ApiHelper;
using Proiect_TWM.Model;

namespace Proiect_TWM.Services.RecipeService
{
    public static class RecipeProcessor
    {
        public static async Task<RecipesCatalogModel> LoadRecipes(string recipeName = "pizza")
        {
            string url = $"https://forkify-api.herokuapp.com/api/search?q={recipeName}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RecipesCatalogModel recipes = await response.Content.ReadAsAsync<RecipesCatalogModel>();
                    
                    return recipes;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase); 
                }
            }
        }
    }
}
