using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    /// <summary>
    /// For tests that have a exploratory purpose like trying out an unknown API. Not neccessarily relating to your own code.
    /// </summary>
    /// <example>trying out LINQ for the first time, writing a piece of code to understand IEnumerable.Take and Skip.</example>
    [TraitDiscoverer(ExploratoryDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExploratoryAttribute : Attribute, ITraitAttribute
    {
        public ExploratoryAttribute(string workItemId)
        {
            WorkItemId = workItemId;
        }

        public ExploratoryAttribute(long workItemId)
        {
            WorkItemId = workItemId.ToString();
        }

        public ExploratoryAttribute()
        {
        }

        public string WorkItemId { get; private set; }
    }
}