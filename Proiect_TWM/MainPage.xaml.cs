using Microsoft.Extensions.Configuration;
using Proiect_TWM.Configuration;
using Proiect_TWM.Configuration.ApiHelper;
using Proiect_TWM.Services.DataService;

namespace Proiect_TWM;

public partial class MainPage : ContentPage
{
	int count = 0;
	private IEnvironmentConfiguration _environmentConfiguration;
	private IDataService _dataService;

	public MainPage()
	{
		_environmentConfiguration = new EnvironmentConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build());
		var key = _environmentConfiguration.GetKeys("Keys","Count");

//		26.04.2023
		ApiHelper.InitializeClient();
        //InitializeComponent();
	}

    //Buna ziua
    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
    public async Task LoadPlants()
	{
		var plants = await _dataService.GetAllPlantsAsync();
	}
	//comment de test
	//Commit 2 de test
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		await LoadPlants();
	}

	// hello
}

