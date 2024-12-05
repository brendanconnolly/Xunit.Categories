using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
	public class ArchitectureTestDiscoverer : ITraitDiscoverer
	{
		internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ArchitectureTestDiscoverer);

		public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
		{
            yield return new KeyValuePair<string, string>("Category", "ArchitectureTest");
        }
	}
}