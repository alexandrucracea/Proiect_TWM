using Proiect_TWM.View;

namespace Proiect_TWM;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new NavigationPage(new HomePageView());
		//var background = Application.Current.Resources["BACKGROUND"] as Color;
		//var text = Application.Current.Resources["TEXT"] as Color;
		//var mainColor = Application.Current.Resources["MAIN"] as Color;
		//var lightAccent	= Application.Current.Resources["LIGHT-ACCENT"] as Color;
		//var darkAccent = Application.Current.Resources["DARK-ACCENT"] as Color;

    }
}
