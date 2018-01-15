using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{

    [TraitDiscoverer(SystemTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SystemTestAttribute : Attribute, ITraitAttribute
    {
        public SystemTestAttribute(string id)
        {
            this.Id = id;
        }

        public SystemTestAttribute(long id)
        {
            this.Id = id.ToString();
        }

        public SystemTestAttribute()
        {

        }

        public string Id { get; private set; }
    }
}
