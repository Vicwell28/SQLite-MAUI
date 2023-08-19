using Microsoft.Extensions.Logging;
using SQLite_MAUI.Models;
using SQLite_MAUI.Repositories;
using SQLite_MAUI.Repositories.Todo;
using SQLite_MAUI.Views;

namespace SQLite_MAUI;

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
		//builder.Services.AddSingleton<BaseRepository<Customer>>();
		//builder.Services.AddSingleton<BaseRepository<Order>>();
		//builder.Services.AddSingleton<BaseRepository<Passport>>();

		//builder.Services.AddSingleton<TodoItemDatabase>();
		//builder.Services.AddTransient<TodoItemPage>();

		return builder.Build();
	}
}
