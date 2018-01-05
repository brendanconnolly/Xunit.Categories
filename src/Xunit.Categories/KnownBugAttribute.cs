using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
	/// <summary>
	/// For failing tests relating to known bugs that should not fail a build
	/// </summary>
	[TraitDiscoverer(KnownBugDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class KnownBugAttribute:Attribute,ITraitAttribute
	{
		public KnownBugAttribute(string id)
		{
			this.Id = id;
		}

		public KnownBugAttribute(long id)
		{
			this.Id = id.ToString();
		}

		public KnownBugAttribute()
		{

		}

		public string Id { get; private set; }
	}
}