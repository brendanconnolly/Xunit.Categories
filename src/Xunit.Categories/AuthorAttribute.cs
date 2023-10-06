using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(AuthorDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute, ITraitAttribute
    {
        public AuthorAttribute(string authorName)
        {
            AuthorName = authorName;
        }

        public string AuthorName { get; }
    }
}