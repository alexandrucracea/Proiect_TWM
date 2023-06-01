using Microsoft.Extensions.Logging;
using Proiect_TWM.Configuration;
using Proiect_TWM.Data;
using Proiect_TWM.Services.DataService;

namespace Proiect_TWM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IEnvironmentConfiguration,EnvironmentConfiguration>();
		builder.Services.AddTransient<IDatabaseRepository, DatabaseRepository>();
		builder.Services.AddTransient<IDataService,DataService>();
		return builder.Build();
	}
}
