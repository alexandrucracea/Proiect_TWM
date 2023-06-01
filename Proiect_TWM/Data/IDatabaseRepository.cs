using Proiect_TWM.Model.ApiResponse;


namespace Proiect_TWM.Data
{
    public interface IDatabaseRepository
    {
        Task SavePlantsAsync(IEnumerable<ApiPlantInfoResponseModel> plants);
    
    }
}
