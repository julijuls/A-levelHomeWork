using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PlatDiplom.Helpers
{
    public static class PagingHelpers
    {

        public static MvcHtmlString PageLinks(this HtmlHelper html,
           PlatDiplom.Models.Pagination.PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int totalCountPages = pageInfo.TotalPages;
            int pageNumber = pageInfo.PageNumber;
            if (totalCountPages > 5)
            {
                for (int i = 1; i <= totalCountPages; i++)
                {
                    if (i == 1 || (i >= pageNumber - 2 && i <= pageNumber + 2) || i == totalCountPages)
                    {
                        if (i == pageNumber - 2 && i > 2)
                        {
                            TagBuilder tag1 = new TagBuilder("a");
                            tag1.InnerHtml = "...";
                            tag1.AddCssClass("btn btn-default");
                            result.Append(tag1.ToString());
                        }

                        TagBuilder tag = new TagBuilder("a");
                        tag.MergeAttribute("href", pageUrl(i));
                        tag.InnerHtml = i.ToString();
                        // если текущая страница, то выделяем ее,
                        // например, добавляя класс
                        if (i == pageNumber)
                        {
                            tag.AddCssClass("selected");
                            tag.AddCssClass("btn-primary");
                        }
                        tag.AddCssClass("btn btn-default");

                        result.Append(tag.ToString());
                        if (i == pageNumber + 2 && i < totalCountPages - 1)
                        {
                            TagBuilder tag2 = new TagBuilder("a");
                            tag2.InnerHtml = "...";
                            tag2.AddCssClass("btn btn-default");
                            result.Append(tag2.ToString());
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i <= totalCountPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    // если текущая страница, то выделяем ее,
                    // например, добавляя класс
                    if (i == pageNumber)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    result.Append(tag.ToString());
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}