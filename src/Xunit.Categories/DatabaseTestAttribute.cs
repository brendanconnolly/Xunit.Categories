﻿using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(DatabaseTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DatabaseTestAttribute:Attribute, ITraitAttribute
    {

    }
}