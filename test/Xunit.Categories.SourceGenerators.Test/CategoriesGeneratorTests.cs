using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories.SourceGenerators.Test
{
    public class CategoriesGeneratorTests
    {
        [Fact]
        public async Task Test()
        {
            string generatedAttributeCode = @"using System;
using Xunit.Sdk;

namespace Xunit.Categories
{
    [TraitDiscoverer(ArchitectureTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ArchitectureTestAttribute : Attribute, ITraitAttribute
    {
        public ArchitectureTestAttribute()
        {            
        }

        public ArchitectureTestAttribute(long identifier) : this(identifier.ToString())
        {
        }

        public ArchitectureTestAttribute(string identifier)
        {
            Identifier = identifier;
        }

        public string? Identifier { get; }
    }
}";
            string generatedDiscovererCode = @"using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Categories
{
    public class ArchitectureTestDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + ""."" + nameof(ArchitectureTestDiscoverer);
    
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var identifier = traitAttribute.GetNamedArgument<string>(""Identifier"");
    
            yield return new KeyValuePair<string, string>(""Category"", ""ArchitectureTest"");
    
            if (!string.IsNullOrWhiteSpace(identifier))
                yield return new KeyValuePair<string, string>(""ArchitectureTest"", identifier);
        }
    }
}";

            await new CSharpSourceGeneratorTest<CategoriesGenerator, DefaultVerifier>()
            {
                TestState =
                {
                    AdditionalFiles =
                    {
                        ("Xunit.Categories.txt", "ArchitectureTest"),
                    },
                    AdditionalReferences = {
                        typeof(DiscovererUtil).Assembly.Location,
                        typeof(ITraitAttribute).Assembly.Location,
                        typeof(IAttributeInfo).Assembly.Location
                    },
                    GeneratedSources =
                    {
                        (typeof(CategoriesGenerator), "ArchitectureTestAttribute.cs", SourceText.From(generatedAttributeCode, Encoding.UTF8, SourceHashAlgorithm.Sha1)),
                        (typeof(CategoriesGenerator), "ArchitectureTestDiscoverer.cs", SourceText.From(generatedDiscovererCode, Encoding.UTF8, SourceHashAlgorithm.Sha1))
                    },
                },
            }.RunAsync();
        }
    }
}