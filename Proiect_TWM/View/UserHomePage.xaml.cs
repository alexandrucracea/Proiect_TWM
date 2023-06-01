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
}