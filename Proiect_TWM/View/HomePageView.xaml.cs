using Proiect_TWM.Configuration.ApiHelper;
using Proiect_TWM.Data;
using Proiect_TWM.Services.DataService;
using Proiect_TWM.Services.RecipeService;

namespace Proiect_TWM.View;

public partial class HomePageView : ContentPage
{
    private IDataService _dataService;
    private IDatabaseRepository _databaseRepository;
	public HomePageView()
	{
        ApiHelper.InitializeClient();
        _databaseRepository = new DatabaseRepository();
        _dataService = new DataService();
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new UserHomePage());
    }
    public async Task LoadPlants()
    {
        await _dataService.SaveAllPlantsAsync(_databaseRepository);


    }
    //comment de test
    //Commit 2 de test
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        ApiHelper.InitializeClient();
        await LoadPlants();
    }
}