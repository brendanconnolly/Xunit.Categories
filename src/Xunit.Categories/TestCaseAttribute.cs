using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    /// <summary>
    /// For annotating tests that relate to a specific Test Case
    /// </summary>
    [TraitDiscoverer(TestCaseDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseAttribute : Attribute, ITraitAttribute
    {
        public string TestCaseId { get; private set; }

        public TestCaseAttribute(string testCaseId)
        {
            TestCaseId = testCaseId;
        }

        public TestCaseAttribute(long testCaseId)
        {
            TestCaseId = testCaseId.ToString();
        }

        public TestCaseAttribute()
        {
        }
    }
}