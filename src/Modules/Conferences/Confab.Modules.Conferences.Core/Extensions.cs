﻿using Confab.Modules.Conferences.Core.DAL;
using Confab.Modules.Conferences.Core.DAL.Repositories;
using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;
using Confab.Modules.Conferences.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Modules.Conferences.Api")]
namespace Confab.Modules.Conferences.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddPostgres<ConferencesDbContext>();

            services.AddSingleton<IHostDeletionPolicy, HostDeletionPolicy>();
            services.AddScoped<IHostService, HostService>();
            services.AddScoped<IHostRepository, HostRepository>();

            services.AddSingleton<IConferenceDeletionPolicy, ConferenceDeletionPolicy>();
            services.AddScoped<IConferenceService, ConferenceService>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();

            return services;
        }
    }
}