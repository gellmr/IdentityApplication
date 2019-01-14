using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace gellmvc.Extensions
{
  public static class HtmlHelperExtensions
  {
    // https://stackoverflow.com/questions/29808573/getting-the-values-from-a-nested-complex-object-that-is-passed-to-a-partial-view/29809907

    // https://www.foreach.be/blog/create-a-custom-html-helper-in-asp-net-mvc-using-razor

    public static MvcHtmlString PartialFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string partialViewName)
    {
      string name = ExpressionHelper.GetExpressionText(expression);
      object model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;
      var viewData = new ViewDataDictionary(helper.ViewData)
      {
        TemplateInfo = new System.Web.Mvc.TemplateInfo
        {
          HtmlFieldPrefix = string.IsNullOrEmpty(helper.ViewData.TemplateInfo.HtmlFieldPrefix) ?
            name : $"{helper.ViewData.TemplateInfo.HtmlFieldPrefix}.{name}"
        }
      };
      return helper.Partial(partialViewName, model, viewData);
    }

  }
}