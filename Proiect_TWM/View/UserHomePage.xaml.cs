using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.StyleSheets;
using static System.Net.Mime.MediaTypeNames;

namespace Proiect_TWM.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage()
	{
        InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void AddPlants(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserAddPlantsGeneralPageView());
    }
}