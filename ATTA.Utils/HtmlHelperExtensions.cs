using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Templates;

namespace ATTA.Utils
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RichTextFor<T>(this HtmlHelper<T> helper, string propertyName) where T : IPublishedContent
        {
            var model = helper.ViewData.Model;
            var richText = model.GetPropertyValue<string>(propertyName);
            var withLinks = TemplateUtilities.ParseInternalLinks(richText);
            var noPara = umbraco.library.RemoveFirstParagraphTag(withLinks);
            return MvcHtmlString.Create(noPara);
        }

        public static bool IsEditing(this HtmlHelper helper)
        {
            return HttpContext.Current.Request.QueryString["dtgePreview"] == "1";
        }
    }
}
