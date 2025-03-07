namespace Xunit.Categories.Generator.interfaces;

public interface ITemplateProvider
{
    string[] GetTemplateNames();
    
    string GetTemplateContents(string templateName);
}