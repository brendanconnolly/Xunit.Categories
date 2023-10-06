using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(SnapshotTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SnapshotTestAttribute : Attribute, ITraitAttribute
    {
    }
}