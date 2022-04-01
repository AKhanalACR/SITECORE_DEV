using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Utils;

namespace ACR.Library.RLI.Search
{
	public class ResultItem
	{
		public ResultItem()
		{
		}

		//public ResultItem(QueryResult queryResult)
		//{
		//	//href
		//	//Href = queryResult.TargetUri.ToLower();
		//	//if(Href.Contains("/rli/"))
		//	//{
		//	//	Href = Href.Replace("/rli/", "/");
		//	//}

		//	////title
		//	//ResultField titleField = queryResult.Fields.Where(x => x.Name == CoveoFields.Title.CoveoFormattedFieldName).FirstOrDefault();
		//	//if(titleField != null && !string.IsNullOrEmpty(titleField.Value.ToString()))
		//	//{
		//	//	Name = titleField.Value.ToString();
		//	//}

		//	////description
		//	//ResultField descriptionField = queryResult.Fields.Where(x => x.Name == CoveoFields.Description.CoveoFormattedFieldName).FirstOrDefault();
		//	//if (descriptionField != null && !string.IsNullOrEmpty(descriptionField.Value.ToString()))
		//	//{
		//	//	Description = descriptionField.Value.ToString();
		//	//}
		//	//else
		//	//{
		//	//	ResultField bodyField =
		//	//		queryResult.Fields.Where(x => x.Name == CoveoFields.Body.CoveoFormattedFieldName).FirstOrDefault();
		//	//	if(bodyField != null)
		//	//	{
		//	//		Description = StringUtil.GetWholeShortenString(UtilStripHtml.GetRawText(bodyField.Value.ToString()), 200);
		//	//	}
		//	//	else
		//	//	{
		//	//		Description = "";
		//	//	}
		//	//}
		//}

		public string Name { get; set; }
		public string Href { get; set; }
		public string Description { get; set; }
	}
}
