
using Proiect_TWM.ViewModel;
using System.Windows.Input;

namespace Proiect_TWM.View;

public partial class AddPlantsFromDbView : ContentPage
{
	AddPlantsFromDbViewModel viewModel;
    ICommand command;
	public AddPlantsFromDbView()
	{
		InitializeComponent();
		viewModel = new AddPlantsFromDbViewModel();
        BindingContext = viewModel;
    }

    private async void buttonName_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        var text = button.Text;
        viewModel.FindPlant(text);
        await Navigation.PushAsync(new DisplayPlantDetailsFromDbView(viewModel.PlantInfo));
        Navigation.RemovePage(this);
    }
}