using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace JsCssReferenceVersionAutoPrefixer
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Enables auto prefixing all js/css file refences within cshtml files using a predefined versioning function.
        /// Output would be like .jss?v={versionNumber}
        /// </summary>
        /// <param name="services"></param>
        /// <param name="generateVersionFunc">(Optional) Version generator function</param>
        public static void AddJsCssVersionAutoPrefixer(this IServiceCollection services,
            Func<string> generateVersionFunc = null)
        {
            VersionTagHelperComponent.VersionFunc = generateVersionFunc
                ?? VersionTagHelperComponent.GetVersionViaAssemblyLastWriteTime;
            services.AddTransient<ITagHelperComponent, VersionTagHelperComponent>();
        }
    }
}