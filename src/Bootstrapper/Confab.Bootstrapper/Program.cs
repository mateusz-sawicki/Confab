using Confab.Modules.Conferences.Api;
using Confab.Shared.Infrastructure;

namespace Confab.Bootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddInfrastucture();
            builder.Services.AddConferences();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseInfrastructure();

            app.Run();
        }
    }
}
