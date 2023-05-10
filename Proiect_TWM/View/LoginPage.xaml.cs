using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.StyleSheets;
using static System.Net.Mime.MediaTypeNames;

namespace Proiect_TWM.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
		InitializeComponent();

		using (var reader = new StringReader("^contentpage{background-color: red; text - align: center;}"))
		{
			this.Resources.Add(StyleSheet.FromReader(reader));
		}
	}
}