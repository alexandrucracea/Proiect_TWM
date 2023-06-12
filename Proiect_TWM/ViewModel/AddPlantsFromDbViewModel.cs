using Proiect_TWM.Data;
using Proiect_TWM.Model.ApiResponse;
using Proiect_TWM.Services.DataService;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Proiect_TWM.ViewModel
{
    public class AddPlantsFromDbViewModel : INotifyPropertyChanged
    {
        public IEnumerable<ApiPlantInfoResponseModel> plants;
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
    }
}
