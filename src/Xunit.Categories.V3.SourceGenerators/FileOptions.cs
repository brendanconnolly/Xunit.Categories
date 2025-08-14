using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace Xunit.Categories.V3.SourceGenerators
{
    [ExcludeFromCodeCoverage]
    internal sealed class FileOptions
    {
        public ImmutableArray<AdditionalText> CategoryFiles { get; set; }
    }
}
