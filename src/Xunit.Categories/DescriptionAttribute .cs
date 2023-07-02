using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(DescriptionDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DescriptionAttribute : Attribute, ITraitAttribute
    {
        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }
}