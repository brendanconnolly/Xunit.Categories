using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
	public class ExploratoryDiscoverer : ITraitDiscoverer
	{
		internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ExploratoryDiscoverer);

		public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
		{
			var workItemId = traitAttribute.GetNamedArgument<string>("WorkItemIdId");


			yield return new KeyValuePair<string, string>("Category", "Exploratory");

			if (!string.IsNullOrWhiteSpace(workItemId))
				yield return new KeyValuePair<string, string>("Exploratory", workItemId);

		}
	}
}