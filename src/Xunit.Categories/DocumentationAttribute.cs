using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
	/// <summary>
	/// For annotating tests that have a mainly documentative purpose, as sometimes a piece of code says more than a 1000 words API Documentation.
	/// </summary>
	[TraitDiscoverer(DocumentationDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class DocumentationAttribute:Attribute,ITraitAttribute
	{
		public DocumentationAttribute(string workItemId)
		{
			this.WorkItemId = workItemId;
		}

		public DocumentationAttribute(long workItemId)
		{
			this.WorkItemId = workItemId.ToString();
		}

		public DocumentationAttribute()
		{

		}

		public string WorkItemId { get; private set; }
	}
}