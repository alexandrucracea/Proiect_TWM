using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.StyleSheets;
using Proiect_TWM.Model;
using Proiect_TWM.ViewModel;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Proiect_TWM.View;

public partial class UserHomePage : ContentPage
{
    UserHomePageViewModel viewModel;
    public UserHomePage()
	{
        InitializeComponent();
        viewModel = new UserHomePageViewModel();
        BindingContext = viewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void AddPlants(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserAddPlantsGeneralPageView());
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        await viewModel.UpdateAddedPlants();
    }

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        collectionView.BackgroundColor = new Color(251, 250, 239);
    }
}