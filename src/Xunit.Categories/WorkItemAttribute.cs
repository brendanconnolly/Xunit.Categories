using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
	/// <summary>
	/// For annotating tests that relate to a specific work item, not neccessarily a bug.
	/// </summary>
	[TraitDiscoverer(WorkItemDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class WorkItemAttribute:Attribute,ITraitAttribute
	{
		public WorkItemAttribute(string workItemId)
		{
			this.WorkItemId = workItemId;
		}

		public WorkItemAttribute(long workItemId)
		{
			this.WorkItemId = workItemId.ToString();
		}

		public WorkItemAttribute()
		{

		}

		public string WorkItemId { get; private set; }
	}
}