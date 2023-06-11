
using Proiect_TWM.ViewModel;
using System.ComponentModel;

namespace Proiect_TWM.View;

public partial class AddPlantsFromDbView : ContentPage
{
	AddPlantsFromDbViewModel viewModel;
	public AddPlantsFromDbView()
	{
		InitializeComponent();
		viewModel = new AddPlantsFromDbViewModel();
        BindingContext = viewModel;
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {

    }
}