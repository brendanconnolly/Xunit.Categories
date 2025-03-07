using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(TestCaseDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseAttribute:Attribute, ITraitAttribute
    {
        public TestCaseAttribute()
        {
            
        }
        public TestCaseAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public TestCaseAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}