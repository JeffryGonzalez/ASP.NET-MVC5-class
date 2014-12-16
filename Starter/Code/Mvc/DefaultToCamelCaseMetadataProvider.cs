using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Starter.Code.Mvc
{
	// Modified Some from http://blog.dotsmart.net/2011/03/28/generating-better-default-displaynames-from-models-in-asp-net-mvc-using-modelmetadataprovider/
	public class DefaultToCamelCaseMetadataProvider : System.Web.Mvc.DataAnnotationsModelMetadataProvider // DataAnnotationsModelMetadataProvider
	{
		readonly Regex _camelCaseRegex = new Regex(@"\B\p{Lu}\p{Ll}", RegexOptions.Compiled);


		protected override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, PropertyDescriptor propertyDescriptor)
		{
			var metadata = base.GetMetadataForProperty(modelAccessor, containerType, propertyDescriptor);

			if (metadata.DisplayName == null)
				metadata.DisplayName = GetNewDisplayNameAsCamelCase(metadata.GetDisplayName());

			return metadata;
		}


		private string GetNewDisplayNameAsCamelCase(string name)
		{
			name = _camelCaseRegex.Replace(name, " $0");
			if (name.EndsWith(" Id"))
				name = name.Substring(0, name.Length - 3);
			return name;
		}
	}
}