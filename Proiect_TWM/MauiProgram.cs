using Microsoft.Extensions.Logging;
using Proiect_TWM.Configuration;
using Proiect_TWM.Data;
using Proiect_TWM.Services.DataService;
using CommunityToolkit.Maui;
using Proiect_TWM.Model.ApiResponse;
using Microsoft.Maui.LifecycleEvents;

namespace Proiect_TWM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Nunito-Regular.ttf","Nunito-Regular");
				fonts.AddFont("Nunito-SemiBold.ttf","Nunito-Semibold");
				fonts.AddFont("Nunito-Bold.ttf","Nunito-Bold");
				fonts.AddFont("Lora-Regular.ttf","Lora-Regular");
				fonts.AddFont("Lora-SemiBold.ttf","Lora-SemiBold");
				fonts.AddFont("Lora-Bold.ttf","Lora-Bold");
            });
		
#if DEBUG
        builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IEnvironmentConfiguration,EnvironmentConfiguration>();
		builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>();
		builder.Services.AddTransient<IDataService,DataService>();
		builder.Services.AddTransient<IApiPlantInfoResponseModel, ApiPlantInfoResponseModel>();
		return builder.Build();
	}
}
