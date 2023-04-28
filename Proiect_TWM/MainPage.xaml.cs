using Microsoft.Extensions.Configuration;
using Proiect_TWM.Configuration;
using Proiect_TWM.Configuration.ApiHelper;
using Proiect_TWM.Services.RecipeService;

namespace Proiect_TWM;

public partial class MainPage : ContentPage
{
	int count = 0;
	private IEnvironmentConfiguration _environmentConfiguration;

	public MainPage()
	{
		_environmentConfiguration = new EnvironmentConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build());
		var key = _environmentConfiguration.GetKeys("Keys","Count");
		//InitializeComponent();

//		26.04.2023
		ApiHelper.InitializeClient();
	}

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
		var plants = await PlantProcessor.LoadPlants();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		//await LoadPlants();
	}
}

