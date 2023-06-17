using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Services.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proiect_TWM.ViewModel
{
    public class DisplayPlantDetailsFromDbViewModel
    {
        public string Name{ get; set; }
        public string Img { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public string Climat { get; set; }
        public IDataService dataService { get; set; }
        public IDatabaseRepository databaseRepository { get; set; }
        public DisplayPlantDetailsFromDbViewModel(PersonalPlantsModel plant)
        {
            Name = plant.Name;
            Img = plant.Img;
            Family = plant.Family;
            Description = plant.Description;
            Climat = plant.Climat;
            dataService = new DataService();
            databaseRepository = new DatabaseRepository();

        }
    }
    
}
