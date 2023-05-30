namespace Proiect_TWM.View;

public partial class HomePageView : ContentPage
{
	public HomePageView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LoginPage());

		//TODO de schimbat pagina catre care mergem
    }
}