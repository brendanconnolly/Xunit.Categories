using Scriban;
using Xunit.Categories.Generator.interfaces;

namespace Xunit.Categories.Generator;

public class TemplateRenderer(ITemplateProvider templateProvider):ITemplateRenderer
{
    private ITemplateProvider _templateProvider = templateProvider;


    public string RenderTemplate(string templateName, object templateParams)
    {
        var templateContent= _templateProvider.GetTemplateContents(templateName);
        var scribanTemplate =  Template.Parse(templateContent);
        return scribanTemplate.Render(templateParams);
    }
}