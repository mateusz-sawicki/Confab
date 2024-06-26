﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Shared.Infrastructure.Modules
{
    internal class ModuleInfoProvider
    {
        public List<ModuleInfo> Modules { get; } = [];
    }

    internal record ModuleInfo(string Name, string Path, IEnumerable<string> Policies)
    {
    }
}
