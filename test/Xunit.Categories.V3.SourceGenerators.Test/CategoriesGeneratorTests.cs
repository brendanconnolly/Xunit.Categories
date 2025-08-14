using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Threading.Tasks;
using Xunit.v3;

namespace Xunit.Categories.V3.SourceGenerators.Test
{
    public class CategoriesGeneratorTests
    {
        [Fact(Skip = "The v2 test works, but this one doesn't when they are exactly the same. There must be some problem with the combination of xunit.v3 and the Microsoft.CodeAnalysis.CSharp.SourceGenerators.Testing package.")]
        public async Task Test()
        {
            string generatedAttributeCode = @"using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.Categories.V3
{
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

        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            List<KeyValuePair<string, string>> traits = new()
            {
                new KeyValuePair<string, string>(""Category"", ""ArchitectureTest"")
            };

            if (!string.IsNullOrWhiteSpace(Identifier))
                traits.Add(new KeyValuePair<string, string>(""ArchitectureTest"", Identifier!));

            return traits;
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
                        typeof(ITraitAttribute).Assembly.Location
                    },
                    GeneratedSources =
                    {
                        (typeof(CategoriesGenerator), "ArchitectureTestAttribute.cs", SourceText.From(generatedAttributeCode, Encoding.UTF8, SourceHashAlgorithm.Sha1))
                    },
                },
            }.RunAsync(TestContext.Current.CancellationToken);
        }
    }
}