using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(UserStoryDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UserStortAttribute:Attribute, ITraitAttribute
    {
        public UserStortAttribute()
        {

        }

        public UserStortAttribute(string name)
        {
            this.Identifier = name;
        }

        public UserStortAttribute(long id)
        {
            this.Identifier = id.ToString();
        }

        public string Identifier { get; private set; }

    }
}