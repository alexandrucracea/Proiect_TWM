
using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Model.ApiResponse;
using Proiect_TWM.Services.RecipeService;

namespace Proiect_TWM.Services.DataService
{
    public class DataService : IDataService
    {
        public async Task<ApiPlantListResponseModel> GetAllPlantsAsync()
        {
            return await PlantProcessor.LoadPlants();
        }
       public async Task SaveAllPlantsAsync(IDatabaseRepository _databaseRepository)
        {
            var plants = await PlantProcessor.LoadPlants();
            if (plants is not null)
            {
                await _databaseRepository.SavePlantsAsync(plants.Plants);
            }
        }
        public async Task InsertCustomPlant(IDatabaseRepository databaseRepository, PersonalPlantsModel plant)
        {
            await databaseRepository.SaveCustomPlantAsync(plant);
        }
        public async Task<IEnumerable<PersonalPlantsModel>> GetUserPlants(IDatabaseRepository databaseRepository)
        {
           return await databaseRepository.GetPersonalPlants();
        }
        public async Task<List<PlantFamilyModel>> GetAllFamilies(IDatabaseRepository databaseRepository)
        {
            return await databaseRepository.GetFamilies();
        }
        public async Task DeletePersonalPlant(IDatabaseRepository repository, PersonalPlantsModel plant)
        {
            await repository.DeletePersonalPlant(plant);
        }
    }
}
