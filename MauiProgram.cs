using EmployeeM.Services.Employeeservices;
using Microsoft.Extensions.Logging;

namespace EmployeeM
{
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"EmployeeDB.db3");
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IEmployeeRepository,EmployeeService> (p=>ActivatorUtilities.CreateInstance<EmployeeService>(p, dbPath));
            return builder.Build();
        }

       
    }
}
