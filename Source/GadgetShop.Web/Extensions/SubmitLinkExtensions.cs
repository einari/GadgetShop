using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetShop.Web.Extensions
{
    // Based on : http://www.concurrentdevelopment.co.uk/blog/index.php/2011/02/asp-net-mvc-linkbutton-with-htmlhelper-extensions/
    public static class SubmitLinkExtensions
    {
        /// <summary>
        /// Returns an A tag with a nested SPAN used to submit a form, requires jquery.link-button.js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString SubmitLink(this HtmlHelper htmlHelper)
        {
            return htmlHelper.SubmitLink("submit");
        }

        /// <summary>
        /// Returns an A tag with a nested SPAN used to submit a form, requires jquery.link-button.js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText">The text for the link button</param>
        /// <returns></returns>
        public static MvcHtmlString SubmitLink(this HtmlHelper htmlHelper, string linkText)
        {
            return htmlHelper.SubmitLink(linkText, null);
        }

        /// <summary>
        /// Returns an A tag with a nested SPAN used to submit a form, requires jquery.link-button.js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText">The text for the link button</param>
        /// <param name="htmlAttributes">The html attributes to apply to the button</param>
        /// <returns></returns>
        public static MvcHtmlString SubmitLink(this HtmlHelper htmlHelper, string linkText, object htmlAttributes)
        {
            // init a tag builder
            TagBuilder tb = new TagBuilder("a");

            // get the attributes
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;

            // set the attributes
            tb.MergeAttributes<string, object>(attributes);

            // add the data attribute
            tb.MergeAttribute("data-link-button", "true");

            // add a nothing href
            tb.MergeAttribute("href", "#");

            // set the inner html
            tb.InnerHtml = linkText; // String.Format("<span>{0}</span>", linkText);

            // return self closing
            return new MvcHtmlString(tb.ToString());
        }
    }
}