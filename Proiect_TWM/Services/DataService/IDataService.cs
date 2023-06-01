using Proiect_TWM.Data;
using Proiect_TWM.Model.ApiResponse;

namespace Proiect_TWM.Services.DataService
{
    public interface IDataService
    {
        Task<ApiPlantListResponseModel> GetAllPlantsAsync();
        Task SaveAllPlantsAsync(IDatabaseRepository _databaseRepository);
    }
}