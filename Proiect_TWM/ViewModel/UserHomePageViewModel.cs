using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Services.DataService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proiect_TWM.ViewModel
{
    public class UserHomePageViewModel : INotifyPropertyChanged
    {
        public IDataService dataService;
        public IDatabaseRepository repository;
        public event PropertyChangedEventHandler PropertyChanged;
        public static ObservableCollection<PersonalPlantsModel> userPlants = new ObservableCollection<PersonalPlantsModel>();
        public PersonalPlantsModel personalPlant;
        public PersonalPlantsModel PersonalPlant
        {
            get
            {
                return personalPlant;
            }
            set
            {
                if(personalPlant != value)
                {
                    personalPlant = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name { get; set; }

        public UserHomePageViewModel()
        {
            dataService = new DataService();
            repository = new DatabaseRepository();
            userPlants = Task.Run(GetUserPlantsAsync).Result;
        }
        public ObservableCollection<PersonalPlantsModel> UserPlants
        {
            get
            {
                return userPlants;
            }
            set
            {
                userPlants = value;
                OnPropertyChanged();

            }
        }
        public async Task<ObservableCollection<PersonalPlantsModel>> GetUserPlantsAsync()
        {
            var plants = await dataService.GetUserPlants(repository);
            return new ObservableCollection<PersonalPlantsModel>(plants);
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand DeleteCommand => new Command<PersonalPlantsModel>(async (PersonalPlantsModel plant) =>
        {
             await dataService.DeletePersonalPlant(repository,plant);
             userPlants = Task.Run(GetUserPlantsAsync).Result;
             UserPlants = userPlants;

        });
        public async Task UpdateAddedPlants()
        {
            dataService = new DataService();
            repository = new DatabaseRepository();
            var plants = new ObservableCollection<PersonalPlantsModel>(await dataService.GetUserPlants(repository));
            userPlants = plants;
            UserPlants = userPlants;
        } 

    }
}
