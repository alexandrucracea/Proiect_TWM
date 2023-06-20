using Newtonsoft.Json;
using Proiect_TWM.Configuration.ApiHelper;
using Proiect_TWM.Model.ApiResponse;

namespace Proiect_TWM.Services.RecipeService
{
    public static class PlantProcessor
    {
        public static async Task<ApiPlantListResponseModel> LoadPlants()
        {
            string url = $"{ApiHelper.ApiClient.BaseAddress}all-lite";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var plants = await response.Content.ReadAsStringAsync();
                    if(plants is not null)
                    {
                        var plantList = JsonConvert.DeserializeObject<List<ApiPlantInfoResponseModel>>(plants);
                        foreach(var plant in plantList)
                        {
                            plant.LatinName = plant?.LatinName ?? "Draecena"; 
                            plant.Id = plant?.Id ?? "111111111111"; 
                            plant.Img = plant?.Img ?? string.Empty;
                            plant.Family = plant?.Family ?? string.Empty;
                            plant.Description = plant?.Description
                                                ?? 
                                                "It is a climbing, evergreen perennial vine that is perhaps most noted for its large perforated leaves on thick plant stems " +
                                                "and its long cord-like aerial roots.";
                            plant.Climat = plant?.Climat ?? string.Empty;
                        }
                        return new ApiPlantListResponseModel { Plants = plantList };
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(plants));
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase); 
                }
            }
        }
    }
}
