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
		public static HtmlString GetDisplayNameFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
			Expression<Func<TModel, TProperty>> expression) where TModel : class
		{
			var metaData = GetMetaData(helper, expression);
			var labelText = GetLabelText(expression, metaData);
			return new HtmlString(labelText);
		}

	

		public static HtmlString MakeInputTextGroup<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression) where TModel : class
		{
			var metaData = GetMetaData(helper, expression);
			var labelText = GetLabelText(expression, metaData);

			var parentDiv = MakeFormGroupDiv();

			parentDiv.InnerHtml += MakeLabel(labelText).ToString(); 

			var input = helper.TextBox(metaData.PropertyName, metaData.Model, new { @class = "form-control" }).ToString();
			parentDiv.InnerHtml += input;

			var alertDiv = new TagBuilder("div");
			alertDiv.AddCssClass("help-block");
			alertDiv.AddCssClass("help-block-error");
			alertDiv.InnerHtml += helper.ValidationMessage(metaData.PropertyName);

			parentDiv.InnerHtml += alertDiv.ToString();
			return new HtmlString(parentDiv.ToString());

		}

		private static TagBuilder MakeLabel(string labelText)
		{
			var label = new TagBuilder("label");
			label.SetInnerText(labelText);
			return label;
		}

		private static TagBuilder MakeFormGroupDiv()
		{
			var parentDiv = new TagBuilder("div");
			parentDiv.AddCssClass("form-group");
			return parentDiv;
		}

		private static ModelMetadata GetMetaData<TModel, TProperty>(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression) where TModel : class
		{
			return ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);
		}
		private static string GetLabelText<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ModelMetadata metaData) where TModel : class
		{
			return metaData.DisplayName ??
						 (metaData.PropertyName ?? ExpressionHelper.GetExpressionText(expression));
		}
	}
}