using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;

namespace JsCssReferenceVersionAutoPrefixer
{
    [HtmlTargetElement("script"), HtmlTargetElement("link")]
    public class VersionTagHelperComponentTagHelper : TagHelperComponentTagHelper
    {
        public VersionTagHelperComponentTagHelper(ITagHelperComponentManager manager, ILoggerFactory loggerFactory) :
            base(manager, loggerFactory)
        {
        }
    }

}