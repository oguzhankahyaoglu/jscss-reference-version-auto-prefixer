using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace JsCssReferenceVersionAutoPrefixer
{
    public class VersionTagHelperComponent : TagHelperComponent
    {
        public override int Order => int.MinValue;

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var versionStr = "?v=" + VERSION.Value;
            if (string.Equals(context.TagName, "script", StringComparison.OrdinalIgnoreCase))
            {
                var attr = output.Attributes["src"];
                var value = attr?.Value?.ToString();
                if (value?.Contains("?") == false)
                {
                    output.Attributes.SetAttribute("src", attr.Value + versionStr);
                }
            }

            if (string.Equals(context.TagName, "link", StringComparison.OrdinalIgnoreCase))
            {
                var attr = output.Attributes["href"];
                var value = attr?.Value?.ToString();
                if (value?.Contains("?") == false && value?.Contains("css") == true)
                {
                    output.Attributes.SetAttribute("href", attr.Value + versionStr);
                }
            }

            return Task.CompletedTask;
        }

        internal static Lazy<string> VERSION = new Lazy<string>(GetVersion);

        internal static string GetVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fileInfo = new System.IO.FileInfo(assembly.Location);
            var lastModified = fileInfo.LastWriteTime;
            return lastModified.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}