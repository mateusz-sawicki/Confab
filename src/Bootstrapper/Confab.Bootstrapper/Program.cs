using Confab.Modules.Conferences.Api;
using Confab.Shared.Infrastructure;

namespace Confab.Bootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var assemblies = ModuleLoader.LoadAssemblies();
            var modules = ModuleLoader.LoadModules(assemblies);
            // Add services to the container.

            builder.Services.AddInfrastucture();
            foreach (var module in modules)
            {
                module.Register(builder.Services);
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseInfrastructure();
            foreach (var module in modules)
            {
                module.Use(app);
            }
            app.Logger.LogInformation($"Modules: {string.Join(", ", modules.Select(x => x.Name))}");

            app.MapControllers();
            app.MapGet("/", context => context.Response.WriteAsync("Confab API!"));

            app.Run();
        }
    }
}
