
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sotsera.Blazor.Toaster.Core.Models;
using Blazor.FileReader;
namespace SmartLearning.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFileReaderService();
            
            services.AddToaster(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.HideTransitionDuration = 2000;
                
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            
            app.AddComponent<App>("app");
        }
    }
}
