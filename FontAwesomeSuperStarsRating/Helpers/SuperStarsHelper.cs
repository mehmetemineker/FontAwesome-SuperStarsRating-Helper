using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FontAwesomeSuperStarsRating.Helpers
{
    public static class SuperStarsHelper
    {
        public static MvcHtmlString SuperStars(this HtmlHelper htmlHelper, int count, double point, string @class, bool isRating = false, bool isRequired = false)
        {
            if (isRating) @class += " rating ";

            string htmlResult = "<div class='super-stars-container'><span class='super-stars " + @class + "'>";

            if (isRating) htmlResult += "<input type='hidden' name='Rating' " + (isRequired ? "required" : "") + " />";

            //<i class='fa fa-star' aria-hidden='true'></i>
            //<i class='fa fa-star-o' aria-hidden='true'></i>
            //<i class='fa fa-star-half-o' aria-hidden='true'></i>

            int ceilingPoint = (int)Math.Round(point, MidpointRounding.AwayFromZero);

            for (int sc = 1; sc <= count; sc++)
            {
                if (sc <= point)
                {
                    htmlResult += "<i data-index='" + sc + "' class='fa fa-star' aria-hidden='true'></i>";
                }
                else if (ceilingPoint > point && sc <= ceilingPoint)
                {
                    htmlResult += "<i data-index='" + sc + "' class='fa fa-star-half-o' aria-hidden='true'></i>";
                }
                else
                {
                    htmlResult += "<i data-index='" + sc + "' class='fa fa-star-o' aria-hidden='true'></i>";
                }
            }

            htmlResult += "</span></div>";

            return new MvcHtmlString(htmlResult);
        }

        public static MvcHtmlString SuperStars(this HtmlHelper htmlHelper, int count, double point)
        {
            return SuperStars(htmlHelper, count, point, "default");
        }

        public static MvcHtmlString SuperStars(this HtmlHelper htmlHelper, double point)
        {
            return SuperStars(htmlHelper, 5, point);
        }

        public static MvcHtmlString SuperStars(this HtmlHelper htmlHelper, int count, bool isRating)
        {
            return SuperStars(htmlHelper, count, 0, "default", true);
        }

        public static MvcHtmlString SuperStars(this HtmlHelper htmlHelper, int count, bool isRating, bool isRequired)
        {
            return SuperStars(htmlHelper, count, 0, "default", true, isRequired);
        }
    }
}