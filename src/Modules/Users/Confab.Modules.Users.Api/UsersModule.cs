using Confab.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Confab.Modules.Users.Core;

namespace Confab.Modules.Users.Api
{
    public class UsersModule : IModule
    {
        public const string BasePath = "users-module";
        public string Name => "Users";

        public string Path => BasePath;

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {

        }
    }
}