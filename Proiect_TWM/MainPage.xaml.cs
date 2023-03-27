using Microsoft.Extensions.Configuration;
using Proiect_TWM.Configuration;

namespace Proiect_TWM;

public partial class MainPage : ContentPage
{
	int count = 0;
	private IEnvironmentConfiguration _environmentConfiguration;

	public MainPage()
	{
		_environmentConfiguration = new EnvironmentConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build());
		var key = _environmentConfiguration.GetKeys("Keys","Count");
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

