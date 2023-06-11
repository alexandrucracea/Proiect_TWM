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
        await Navigation.PushAsync(new AddPlantsFromDbView());
        Navigation.RemovePage(this);
    }


}