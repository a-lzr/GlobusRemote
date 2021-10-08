using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GlobusRemote.Services
{
    public static class ViewHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                // добавляем текст в li
                li.InnerHtml.Append(item);
                // добавляем li в ul
                ul.InnerHtml.AppendHtml(li);
            }
            ul.Attributes.Add("class", "itemsList");
            var writer = new System.IO.StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }

        public static HtmlString NoEncodeActionLink(
            this IHtmlHelper htmlHelper, string text, string title, string action, string controller,
            object routeValues = null, object htmlAttributes = null)
        {
            //UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            //TagBuilder builder = new TagBuilder("a");
            //builder.InnerHtml = text;
            //builder.Attributes["title"] = title;
            //builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            //builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));

            return null; // new HtmlString(builder.ToString());
        }


        //// As the text the: "<span class='glyphicon glyphicon-plus'></span>" can be entered
        //public static MvcHtmlString NoEncodeActionLink(this HtmlHelper htmlHelper,
        //                                     string text, string title, string action,
        //                                     string controller,
        //                                     object routeValues = null,
        //                                     object htmlAttributes = null)
        //{
        //    UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

        //    TagBuilder builder = new TagBuilder("a");
        //    builder.InnerHtml = text;
        //    builder.Attributes["title"] = title;
        //    builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
        //    builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));

        //    return MvcHtmlString.Create(builder.ToString());
        //}
    }
}
