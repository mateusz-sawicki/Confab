namespace Confab.Bootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();
            app.MapGet("/", context => context.Response.WriteAsync("Confab API!"));

            app.Run();
        }
    }
}
