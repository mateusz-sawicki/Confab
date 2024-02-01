using Confab.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Confab.Modules.Speakers.Core;

namespace Confab.Modules.Speakers.Api
{
    public class SpeakersModule : IModule
    {
        public const string BasePath = "speakers-module";
        public string Name => "Speakers";

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