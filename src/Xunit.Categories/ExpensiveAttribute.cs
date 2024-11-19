using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ExpensiveDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExpensiveAttribute : Attribute, ITraitAttribute
    {
    }
}