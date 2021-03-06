﻿using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(IntegrationTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class IntegrationTestAttribute:Attribute, ITraitAttribute
    {

    }
}