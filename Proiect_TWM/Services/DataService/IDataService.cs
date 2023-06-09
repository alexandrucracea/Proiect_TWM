﻿using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Model.ApiResponse;
using Proiect_TWM.ViewModel;

namespace Proiect_TWM.Services.DataService
{
    public interface IDataService
    {
        Task<ApiPlantListResponseModel> GetAllPlantsAsync();
        Task SaveAllPlantsAsync(IDatabaseRepository _databaseRepository);
        Task InsertCustomPlant(IDatabaseRepository databaseRepository, PersonalPlantsModel plant);
        Task<IEnumerable<PersonalPlantsModel>> GetUserPlants(IDatabaseRepository databaseRepository);
        Task<List<PlantFamilyModel>> GetAllFamilies(IDatabaseRepository databaseRepository);
        Task DeletePersonalPlant(IDatabaseRepository repository, PersonalPlantsModel plant);
    }
}