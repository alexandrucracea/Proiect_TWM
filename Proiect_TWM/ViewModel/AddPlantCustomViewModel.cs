using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Services;
using Proiect_TWM.Services.DataService;
using System.Windows.Input;

namespace Proiect_TWM.ViewModel
{
    public class AddPlantCustomViewModel
    {
        private IDatabaseRepository _repository = new DatabaseRepository();
        private IDataService _service = new DataService();
        public string Name { get; set; }
        public PlantFamilyModel SelectedFamily { get; set; }
        public string Description { get; set; }
        public ICommand SavePersonalPlant { get; private set; }
        public bool nameIsValid;
        public bool NameIsValid
        {
            get
            {
                return nameIsValid;
            }
            set
            {
                nameIsValid = ValidationService.validateName(Name);
            }
        }
        public AddPlantCustomViewModel()
        {
           SavePersonalPlant = new Command(
               async () => {
                   
                   await _service.InsertCustomPlant(_repository,new PersonalPlantsModel
               {
                   Name = Name,
                   Img = "no image",
                   Family = SelectedFamily.Name.ToString(),
                   Description=Description,
                   Climat="indoors"
                        }); 
                   }
               ); 
        }
 
    }
}
