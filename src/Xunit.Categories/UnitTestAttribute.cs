using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(UnitTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UnitTestAttribute : Attribute, ITraitAttribute
    {
        public UnitTestAttribute()
        {
        }

        public UnitTestAttribute(string name)
        {
            Identifier = name;
        }

        public UnitTestAttribute(long id)
        {
            Identifier = id.ToString();
        }

        public string Identifier { get; private set; }
    }
}