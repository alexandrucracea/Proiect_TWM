using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Model.ApiResponse;
using Proiect_TWM.Services.DataService;
using Proiect_TWM.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Proiect_TWM.ViewModel
{
    public class AddPlantsFromDbViewModel : INotifyPropertyChanged
    {
        public IEnumerable<ApiPlantInfoResponseModel> plants;
        public PersonalPlantsModel PlantInfo { get; set; }
        public ApiPlantInfoResponseModel plant { get; set; }
        public IDataService dataService { get; set; }
        public IDatabaseRepository databaseRepository { get; set; }
        public string LatinName { get; set; }
        public string searchText;
        public AddPlantsFromDbViewModel()
        {
            dataService = new DataService();
            databaseRepository = new DatabaseRepository();
            plants = Task.Run(ConvertDBResponse).Result;
            PlantInfo = new PersonalPlantsModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<ApiPlantInfoResponseModel> Plants
        {
            get
            {
                if(SearchText is null || SearchText=="")
                {
                    return Enumerable.Empty<ApiPlantInfoResponseModel>();
                }
                return plants;
            }
            set
            {
                if (plants != value)
                {
                    plants = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set 
                { 
                    searchText = value; 
                    OnPropertyChanged();
                    if(searchText != null) { 
                    Plants = plants.Where(x => x.LatinName.ToLower().StartsWith(SearchText.ToLower())).Take(15);
                    }
                }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async Task<IEnumerable<ApiPlantInfoResponseModel>> ConvertDBResponse()
        {
            var plants  = await dataService.GetAllPlantsAsync();
            IEnumerable<ApiPlantInfoResponseModel> plantsToReturn = plants.Plants;
            return plantsToReturn;
        }
        public void FindPlant(String plantName)
        {
            
            var info = plants.FirstOrDefault(x => x.LatinName.ToLower().Equals(plantName.ToLower()));
            var index = plants.TakeWhile(x => x.LatinName.ToLower().Equals(plantName.ToLower())).Count();
            PlantInfo.Name = info.LatinName;
            PlantInfo.Id = index;
            PlantInfo.Description = info.Description;
            PlantInfo.Climat = info.Climat;
            PlantInfo.Family = info.Family;
            PlantInfo.Img = info.Img;
            
        }
    }
}
