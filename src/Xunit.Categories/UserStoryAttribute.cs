using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(UserStoryDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UserStoryAttribute:Attribute, ITraitAttribute
    {
        public UserStoryAttribute()
        {
            
        }
        public UserStoryAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public UserStoryAttribute(long identifier)
        {
            Identifier = identifier.ToString();
        }

        public string? Identifier { get; }
    }
}