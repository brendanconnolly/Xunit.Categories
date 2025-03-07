using System.Reflection;
using System.Text;
using Xunit.Categories.Generator.interfaces;

namespace Xunit.Categories.Generator;

public class CurrentAssemblyTemplateProvider: ITemplateProvider
{
    private readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    public string[] GetTemplateNames()
    {
        var assemblyName = _assembly.GetName().Name;
        Console.WriteLine($"Template assembly: {assemblyName}");
        var names = _assembly.GetManifestResourceNames();
        Console.WriteLine($"Found {names.Length} templates");
        Console.WriteLine($"Assembly name: {names}");
        return names;
    }

    public string GetTemplateContents(string templateName)
    {
        var stream = _assembly.GetManifestResourceStream(templateName);
        using var streamReader = new StreamReader(stream!, Encoding.UTF8);
        var result = streamReader.ReadToEnd();
        return result.Trim();
    }
}