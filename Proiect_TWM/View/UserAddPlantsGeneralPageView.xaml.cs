namespace Proiect_TWM.View;

public partial class UserAddPlantsGeneralPageView : ContentPage
{
	public UserAddPlantsGeneralPageView()
	{
		InitializeComponent();
	}

    private async void AddPlantsCustom(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddPlantrsCustomView(new ViewModel.AddPlantCustomViewModel()));
        Navigation.RemovePage(this);
    }
    private async void AddPlantsFromDb(object sender, EventArgs e)
    {
        addPlantsDb.IsVisible = false;
        addPlantCuston.IsVisible = false;
        await progressBar.ProgressTo(1.0, 4000, Easing.Linear);
        AddPlantsFromDbView addPlantsFromDbView = new AddPlantsFromDbView();
        await Navigation.PushAsync(addPlantsFromDbView);
        Navigation.RemovePage(this);
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
       
    }
}