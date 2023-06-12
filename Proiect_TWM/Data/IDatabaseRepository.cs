using Proiect_TWM.Model;
using Proiect_TWM.Model.ApiResponse;


namespace Proiect_TWM.Data
{
    public interface IDatabaseRepository
    {
        Task SavePlantsAsync(IEnumerable<ApiPlantInfoResponseModel> plants);
        Task SaveCustomPlantAsync(PersonalPlantsModel plant);
        Task<List<PlantFamilyModel>> GetFamilies();
        Task<IEnumerable<PersonalPlantsModel>> GetPersonalPlants();
        Task DeletePersonalPlant(PersonalPlantsModel plant);

    }
}
