using Xunit.Categories.Generator;
using Xunit;
using FluentAssertions;

namespace Xunit.Categories.Generator.Tests;

public class CurrentAssemblyTemplateProviderTests
{
    public readonly string ExpectedAttributeTemplate = """
         using System;
         using Xunit.Sdk;
         
         namespace Xunit.Categories
         {
             [TraitDiscoverer({{ categoryname }}Discoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
             [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
             public class {{ categoryname }}Attribute:Attribute, ITraitAttribute
             {
                 public {{ categoryname }}Attribute()
                 {
                     
                 }
                 public {{ categoryname }}Attribute(string identifier)
                 {
                     Identifier = identifier;
                 }
         
                 public {{ categoryname }}Attribute(long identifier)
                 {
                     Identifier = identifier.ToString();
                 }
         
                 public string? Identifier { get; }
             }
         }
         """;

    public readonly string ExpectedDiscovererTemplate = """
            using System.Collections.Generic;
            using Xunit.Abstractions;
            using Xunit.Sdk;
            
            namespace Xunit.Categories
            {
                public class {{ categoryname }}Discoverer:ITraitDiscoverer
                {
                    internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof({{ categoryname }}Discoverer);
                
                    public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
                    {
                        var identifier = traitAttribute.GetNamedArgument<string>("Identifier");
                
                        if (!string.IsNullOrWhiteSpace(identifier))
                            yield return new KeyValuePair<string, string>("{{ categoryname }}", identifier);
                    }
                }
            }
            """;

    public readonly string ExpectedTraitTestTemplate = """
           using FluentAssertions;
           using Xunit;
           using Xunit.Categories;
           
           namespace Xunit.Categories.Test
           {
               public class {{ categoryname }}TraitTests
               {
                   [Fact]
                   public void FactTest()
                   {
                       var testMethod = typeof({{ categoryname }}TraitTests).GetMethod(nameof(FactTest));
                       testMethod.Should().BeDecoratedWith<FactAttribute>();
                   }
                   
                   [Fact]
                   [{{ categoryname }}]
                   public void {{ categoryname }}Test()
                   {
                       var testMethod = typeof({{ categoryname }}TraitTests).GetMethod(nameof({{ categoryname }}Test));
                       testMethod.Should()
                       .BeDecoratedWith<FactAttribute>()
                           .And.BeDecoratedWith<{{ categoryname }}Attribute>();
                   }
           
                   [Fact]
                   [{{ categoryname }}("888")]
                   public void {{ categoryname }}WithIdentifierAsString()
                   {
                       var testMethod = typeof({{ categoryname }}TraitTests).GetMethod(nameof( {{ categoryname }}WithIdentifierAsString));
                       testMethod.Should()
                       .BeDecoratedWith<FactAttribute>()
                           .And.BeDecoratedWith<{{ categoryname }}Attribute>()
                           .Which.Identifier.Should().Be("888");
                   }
           
                   [Fact]
                   [{{ categoryname }}(888)]
                   public void {{ categoryname }}WithIdentifierAsInteger()
                   {
                       var testMethod = typeof({{ categoryname }}TraitTests).GetMethod(nameof( {{ categoryname }}WithIdentifierAsInteger));
                       testMethod.Should()
                       .BeDecoratedWith<FactAttribute>()
                           .And.BeDecoratedWith<{{ categoryname }}Attribute>()
                               .Which.Identifier.Should().Be("888");
                   }
                               
               }
           }
           """;
        
    [Fact]
    public void GetTemplateNamesShouldHaveRequiredTemplates()
    {
        var templateProvider = new CurrentAssemblyTemplateProvider();
        var templateNames = templateProvider.GetTemplateNames();
        templateNames.Should().HaveCount(3)
            .And.Contain(templateName => templateName.EndsWith("Attribute.liquid"))
            .And.Contain(templateName => templateName.EndsWith("Discoverer.liquid"))
            .And.Contain(templateName => templateName.EndsWith("TraitTest.liquid"));
        
    }

    [Fact]
    public void AttributeTemplateNameShouldReturnExpectedTemplateContents()
    {
        var templateProvider = new CurrentAssemblyTemplateProvider();
        var templateNames= templateProvider.GetTemplateNames();
        var templateName= templateNames.First(s => s.Contains("Attribute.liquid"));
        var template = templateProvider.GetTemplateContents(templateName);
        template.Should().BeEquivalentTo(ExpectedAttributeTemplate);
        
    }
    
    [Fact]
    public void DiscovererTemplateNameShouldReturnExpectedTemplateContents()
    {
        var templateProvider = new CurrentAssemblyTemplateProvider();
        var templateNames= templateProvider.GetTemplateNames();
        var templateName= templateNames.First(s => s.Contains("Discoverer.liquid"));
        var template = templateProvider.GetTemplateContents(templateName);
        template.Should().BeEquivalentTo(ExpectedDiscovererTemplate);

    }
    
    [Fact]
    public void TraitTestTemplateNameShouldReturnExpectedTemplateContents()
    {
        var templateProvider = new CurrentAssemblyTemplateProvider();
        var templateNames= templateProvider.GetTemplateNames();
        var templateName= templateNames.First(s => s.Contains("TraitTest.liquid"));
        var template = templateProvider.GetTemplateContents(templateName);
        template.Should().BeEquivalentTo(ExpectedTraitTestTemplate);

    }
    
    //handle template name that doesnt exist
}