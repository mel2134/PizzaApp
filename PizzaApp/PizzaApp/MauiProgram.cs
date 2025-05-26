using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Pages;
using Services;
using ViewModels;

namespace PizzaApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<HomePage>();
		AddPizzaServices(builder.Services);
		return builder.Build();
	}
	private static IServiceCollection AddPizzaServices(IServiceCollection services)
	{
		services.AddSingleton<PizzaService>();
		services.AddSingleton<HomePage>().AddSingleton<HomeViewModel>();
		services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
		services.AddTransientWithShellRoute<AllPizzasPage,AllPizzasViewModel>(nameof(AllPizzasPage));
		services.AddTransientWithShellRoute<DetailsPage,DetailsViewModel>(nameof(DetailsPage));
		//services.AddTransientWithShellRoute<CartPage,CartViewModel>(nameof(CartPage));
		services.AddSingleton<CartViewModel>();
		services.AddTransient<CartPage>();
		return services;
	}
}
