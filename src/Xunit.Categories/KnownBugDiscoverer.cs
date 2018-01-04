using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
	public class KnownBugDiscoverer : ITraitDiscoverer
	{
		internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(KnownBugDiscoverer);

		public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
		{
			var bugId = traitAttribute.GetNamedArgument<string>("Id");


			yield return new KeyValuePair<string, string>("Category", "KnownBug");

			if (!string.IsNullOrWhiteSpace(bugId))
				yield return new KeyValuePair<string, string>("KnownBug", bugId);

		}
	}
}