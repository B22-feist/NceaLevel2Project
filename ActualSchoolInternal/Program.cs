using Avalonia;
using ActualSchoolInternal.Models.Database.Database.Data;
using Avalonia.ReactiveUI;

namespace ActualSchoolInternal;

internal static class Program
{
	
	// Initialization code. Don't use any Avalonia, third-party APIs or any
	// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
	// yet and stuff might break.
	[STAThread]
	public static async Task Main(string[] args)
	{
		GetData test = new();
		Task<bool> loadDb = GetData.LoadDb();
		bool loadSuccess = await loadDb;
		Console.WriteLine(loadSuccess ? "Successfully loaded" : "Failed to load");
		BuildAvaloniaApp()
			.StartWithClassicDesktopLifetime(args);
	}

	// Avalonia configuration, don't remove; also used by visual designer.
	private static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace()
			.UseReactiveUI();
}