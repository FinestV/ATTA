using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace ATTA.Utils
{
    public static class StringExtensions
    {
        public static MvcHtmlString RemoveFirstParagraphTag(this IHtmlString field)
        {
            return MvcHtmlString.Create(umbraco.library.RemoveFirstParagraphTag(field.ToString()));
        }
        public static MvcHtmlString InjectITags(this IHtmlString field)
        {
            return field.ToString().InjectITags();
        }
        public static MvcHtmlString InjectITags(this MvcHtmlString field)
        {
            return field.ToString().InjectITags();
        }
        public static MvcHtmlString InjectITags(this string field)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(field);

            foreach (var node in doc.DocumentNode.SafeSelectNodes("//p | //h2"))
            {
                node.InnerHtml = "<i>" + node.InnerHtml.Replace("<br>", "</i><br><i>") + "</i>";
            }
            return MvcHtmlString.Create(doc.DocumentNode.OuterHtml);
        }
        private static HtmlNodeCollection SafeSelectNodes(this HtmlNode node, string selector)
        {
            return node.SelectNodes(selector) ?? new HtmlNodeCollection(node);
        }
        public static MvcHtmlString SetSliderImage(this MvcHtmlString field, string imgClass = "img-responsive", string wrapperClass = "da-img")
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(field.ToString());

            foreach (var node in doc.DocumentNode.SafeSelectNodes("//img"))
            {
                node.SetAttributeValue("class", imgClass);
                node.ParentNode.SetAttributeValue("class", wrapperClass);
            }
            return MvcHtmlString.Create(doc.DocumentNode.OuterHtml);
        }

        public static MvcHtmlString WrapHeaders(this IHtmlString field)
        {
            return field.ToString().WrapHeaders();
        }
        public static MvcHtmlString WrapHeaders(this MvcHtmlString field)
        {
            return field.ToString().WrapHeaders();
        }
        public static MvcHtmlString WrapHeaders(this string field)
        {
            //check for <h2> with no <div class="headline"> look around
            var startHeading = new Regex("(?<!<div class=\"headline\">\\s*)<h2", RegexOptions.Singleline);
            field = startHeading.Replace(field, "<div class=\"headline\"><h2");

            //check for </h2> with no </div> look ahead
            var endHeading = new Regex("</h2>(?!\\s*</div>)", RegexOptions.Singleline);
            field = endHeading.Replace(field, "</h2></div>");

            return MvcHtmlString.Create(field);
        }
    }
}
