using Proiect_TWM.Model;
using Proiect_TWM.Model.ApiResponse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proiect_TWM.Data
{
    public class DatabaseRepository: IDatabaseRepository
    {
        const string dbName = "PlantsCatalog.db";
        SQLiteAsyncConnection connection;

        private async Task Initialize()
        {
            
                if (connection is null)
                {
                    var path = Path.Combine(FileSystem.AppDataDirectory, dbName);
                    var flags = SQLite.SQLiteOpenFlags.ReadWrite
                        | SQLite.SQLiteOpenFlags.Create
                        | SQLite.SQLiteOpenFlags.SharedCache;
                    connection = new SQLiteAsyncConnection(path, flags);
                try { 
                    await connection.CreateTableAsync<ApiPlantInfoResponseModel>();
                    await connection.CreateTableAsync<PersonalPlantsModel>();
                    await connection.CreateTableAsync<PlantFamilyModel>();
                    var families = await connection.Table<PlantFamilyModel>().ToListAsync();
                    if (families is null || families.Count == 0)
                    {
                        await PopulateFamilyTable();
                    }
                }catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }

        }
                
        }
        private async Task PopulateFamilyTable()
        {
            if(connection is not null)
            {
                List<PlantFamilyModel> families = new List<PlantFamilyModel>();
                families.Add(new PlantFamilyModel { Name = "Liliaceae" });
                families.Add(new PlantFamilyModel { Name = "Arecaceae" });
                families.Add(new PlantFamilyModel { Name = "Araceae" });
                families.Add(new PlantFamilyModel { Name = "Marantaceae" });
                families.Add(new PlantFamilyModel { Name = "Bromeliaceae" });
                families.Add(new PlantFamilyModel { Name = "Marantaceae" });
                families.Add(new PlantFamilyModel { Name = "Melastomataceae" });
                families.Add(new PlantFamilyModel { Name = "Araliaceae" });
                families.Add(new PlantFamilyModel { Name = "Moraceae" });
                families.Add(new PlantFamilyModel { Name = "Apocynaceae" });
                families.Add(new PlantFamilyModel { Name = "Euphorbiaceae" });
                families.Add(new PlantFamilyModel { Name = "Malvaceae" });
                families.Add(new PlantFamilyModel { Name = "Polypodiaceae" });
                families.Add(new PlantFamilyModel { Name = "Strelitziaceae" });
                families.Add(new PlantFamilyModel { Name = "Crasssulaceae" });
                families.Add(new PlantFamilyModel { Name = "Agavaceae" });
                families.Add(new PlantFamilyModel { Name = "Nephrolepidaceae" });
                families.Add(new PlantFamilyModel { Name = "Palmae" });
                families.Add(new PlantFamilyModel { Name = "Pteridaceae" });
                families.Add(new PlantFamilyModel { Name = "Asclepiadaceae" });
                families.Add(new PlantFamilyModel { Name = "Amaryllidaceae" });
                families.Add(new PlantFamilyModel { Name = "Dryopteridaceae" });
                families.Add(new PlantFamilyModel { Name = "Cactaceae" });
                families.Add(new PlantFamilyModel { Name = "Orchidaceae" });
                families.Add(new PlantFamilyModel { Name = "Bignoniaceae" });
                families.Add(new PlantFamilyModel { Name = "Sinopteridaceae" });
                families.Add(new PlantFamilyModel { Name = "Gesneriaceae" });
                families.Add(new PlantFamilyModel { Name = "Nyctaginaceae" });
                families.Add(new PlantFamilyModel { Name = "Davalliaceae" });
                families.Add(new PlantFamilyModel { Name = "Zingiberaceae" });
                await connection.InsertAllAsync(families);
            }
        }

        public async Task SavePlantsAsync(IEnumerable<ApiPlantInfoResponseModel> plants)
        {
            await Initialize();
            //await connection.DeleteAllAsync<ApiPlantInfoResponseModel>();
            await connection.InsertAllAsync(plants);

        }
        public async Task SaveCustomPlantAsync(PersonalPlantsModel plant)
        {
            await Initialize(); //todo de initializat doar tabela de plante personale
            await connection.InsertAsync(plant);
        }
        public async Task<IEnumerable<PersonalPlantsModel>>GetPersonalPlants()
        {
            await Initialize();
            return await connection.Table<PersonalPlantsModel>().ToListAsync();
        }
        public async Task DeletePersonalPlant(PersonalPlantsModel plant)
        {
            await connection.DeleteAsync(plant); //todo de adaugat primary key
        }
        public async Task<List<PlantFamilyModel>> GetFamilies()
        {
            await Initialize();
            return await connection.Table<PlantFamilyModel>().ToListAsync();

        }
    }
}
