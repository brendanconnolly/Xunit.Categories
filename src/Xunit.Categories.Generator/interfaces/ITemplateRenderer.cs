namespace Xunit.Categories.Generator.interfaces;

public interface ITemplateRenderer
{
    string RenderTemplate(string templateName, object templateParams);
}