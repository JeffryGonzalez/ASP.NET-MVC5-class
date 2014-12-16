using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Starter.Code
{
    public static class CustomHtmlHelpers
    {
        public static HtmlString MakeInputGroup<TModel,TProperty> (this HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression) where TModel : class
        {
            var metaData = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);
            var labelText = metaData.DisplayName ??
                            (metaData.PropertyName ?? ExpressionHelper.GetExpressionText(expression));
            var parentDiv = new TagBuilder("div");
            parentDiv.AddCssClass("form-group");

            var label = new TagBuilder("label");
            label.SetInnerText(labelText);
            parentDiv.InnerHtml += label.ToString();
            return new HtmlString(parentDiv.ToString());

        }
    }
}