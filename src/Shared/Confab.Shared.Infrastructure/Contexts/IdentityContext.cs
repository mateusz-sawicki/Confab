﻿using Confab.Shared.Abstractions.Contexts;
using System.Security.Claims;

namespace Confab.Shared.Infrastructure.Contexts
{
    internal partial class Context
    {
        internal class IdentityContext : IIdentityContext
        {
            public Dictionary<string, IEnumerable<string>> Claims { get; }
            public Guid Id { get; }
            public string Role { get; }
            public bool IsAuthenticated { get; }

            public IdentityContext(ClaimsPrincipal principal)
            {
                IsAuthenticated = principal.Identity?.IsAuthenticated is true;
                Id = IsAuthenticated ? Guid.Parse(principal.Identity.Name) : Guid.Empty;
                Role = principal.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                Claims = principal.Claims?.GroupBy(x => x.Type)
                    .ToDictionary(x => x.Key, x => x.Select(c => c.Value.ToString()));
            }
        }
    }
}
