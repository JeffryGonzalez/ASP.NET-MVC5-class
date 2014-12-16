using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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

            var input = helper.TextBox(metaData.PropertyName, metaData.Model, new {@class="form-control"}).ToString();
            parentDiv.InnerHtml += input.ToString();

            return new HtmlString(parentDiv.ToString());

        }
    }
}