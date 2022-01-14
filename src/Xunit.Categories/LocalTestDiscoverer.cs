using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
	public class LocalTestDiscoverer : ITraitDiscoverer
	{
		internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(LocalTestDiscoverer);

		public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
		{
			var id = traitAttribute.GetNamedArgument<string>("Id");


			yield return new KeyValuePair<string, string>("Category", "LocalTest");

			if (!string.IsNullOrWhiteSpace(id))
				yield return new KeyValuePair<string, string>("LocalTest", id);

		}
	}
}