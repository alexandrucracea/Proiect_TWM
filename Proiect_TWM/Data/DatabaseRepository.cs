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
            if(connection is null)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, dbName);
                var flags = SQLite.SQLiteOpenFlags.ReadWrite
                    | SQLite.SQLiteOpenFlags.Create
                    | SQLite.SQLiteOpenFlags.SharedCache;
                connection = new SQLiteAsyncConnection(path, flags);
                await connection.CreateTableAsync<ApiPlantInfoResponseModel>();
            }
        }

        public async Task SavePlantsAsync(IEnumerable<ApiPlantInfoResponseModel> plants)
        {
            await Initialize();
            await connection.DeleteAllAsync<ApiPlantInfoResponseModel>();
            await connection.InsertAllAsync(plants);

        }
    }
}
