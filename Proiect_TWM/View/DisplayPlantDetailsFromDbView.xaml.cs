using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Services.DataService;
using Proiect_TWM.ViewModel;

namespace Proiect_TWM.View;

public partial class DisplayPlantDetailsFromDbView : ContentPage
{
    public PersonalPlantsModel PersonalPlantModel { get; set; }
    public IDataService DataService { get; set; }
    public IDatabaseRepository DatabaseRepository { get; set; }
    public DisplayPlantDetailsFromDbViewModel viewModel { get; set; }
    public DisplayPlantDetailsFromDbView()
	{
		InitializeComponent();
		
	}
	public DisplayPlantDetailsFromDbView(PersonalPlantsModel plantsModel)
	{
		InitializeComponent();
		PersonalPlantModel = plantsModel;
		viewModel = new DisplayPlantDetailsFromDbViewModel(plantsModel);
		BindingContext = viewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        DataService = new DataService();
        DatabaseRepository = new DatabaseRepository();
        await DataService.InsertCustomPlant(DatabaseRepository, PersonalPlantModel);
		await Navigation.PopAsync();
		//todo de adaugat sectiune de favorite
	}
}