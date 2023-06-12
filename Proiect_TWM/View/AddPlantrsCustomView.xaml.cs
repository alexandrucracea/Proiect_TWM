using CommunityToolkit.Maui.Behaviors;
using Proiect_TWM.Data;
using Proiect_TWM.Model;
using Proiect_TWM.Services.DataService;
using Proiect_TWM.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Proiect_TWM.View;

public partial class AddPlantrsCustomView : ContentPage, INotifyPropertyChanged
{
    public IDatabaseRepository databaseRepository { get; set; } = new DatabaseRepository();
    public IDataService dataService { get; set; } = new DataService();
    public List<PlantFamilyModel> families;
    //public event PropertyChangedEventHandler PropertyChanged;
    public AddPlantrsCustomView(AddPlantCustomViewModel viewModel)
	{
        InitializeComponent();
        pickerFamily.ItemsSource = Families; //de vazut cum sa apelam si incarcarea
        Validate();
        BindingContext = viewModel;
    }

    private void Validate()
    {
        var validStyle = new Style(typeof(Entry));
        validStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.White
        });
        var invalidStyle = new Style(typeof(Entry));
        invalidStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Red
        });
        var textValidationBehavior = new TextValidationBehavior
        {
            InvalidStyle = invalidStyle,
            ValidStyle = validStyle,
            Flags = ValidationFlags.ValidateOnValueChanged,
            MinimumLength = 1,
            MaximumLength = 10
        };

        entryName.Behaviors.Add(textValidationBehavior);
    }

    private async void GoBackAsync(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    public List<PlantFamilyModel> Families
    {
        get
        {
            return families;
        }
        set
        {
            if(families != value)
            {
                families = value;
                OnPropertyChanged();
            }
        }
    }
    private async void pickerFamily_Loaded(object sender, EventArgs e)
    {
        Families = await dataService.GetAllFamilies(databaseRepository);
        pickerFamily.ItemsSource = Families;
    }
}