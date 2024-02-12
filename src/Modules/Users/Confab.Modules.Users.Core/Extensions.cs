﻿using Confab.Modules.Users.Core.DAL;
using Confab.Modules.Users.Core.DAL.Repositories;
using Confab.Modules.Users.Core.Entities;
using Confab.Modules.Users.Core.Repositories;
using Confab.Modules.Users.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Modules.Users.Api")]
namespace Confab.Modules.Users.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services
            .AddScoped<IUserRepository, UserRepository>()
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddTransient<IIdentityService, IdentityService>();

            services.AddPostgres<UsersDbContext>();

            return services;
        }

        //{
        //    services.AddPostgres<UsersDbContext>();

        //    services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        //    services.AddScoped<IUserRepository, UserRepository>();
        //    services.AddTransient<IIdentityService, IdentityService>();

        //    return services;
        //}
    }
}