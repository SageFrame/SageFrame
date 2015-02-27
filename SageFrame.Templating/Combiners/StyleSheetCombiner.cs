using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Reflection;
using System.Text;
using System.Web.UI;

namespace CssJscriptOptimizer.Controls
{
	public class StyleSheetCombiner : HtmlContainerControl
	{

		private string _handlerPath;
		private string _blockedHandlerPath;
		private Dictionary<string, string> _scripts = new Dictionary<string, string>();

		public StyleSheetCombiner()
		{
			if (OptimizerConfig.Enable)
			{
				Page page = this.Context.Handler as Page;
				if (page != null)
				{
					_handlerPath = string.Format("{0}?keys=", page.ResolveUrl(OptimizerConfig.FullHandlerPath));
				}
				else
				{
					_handlerPath = string.Format("{0}?keys=", OptimizerConfig.FullHandlerPath);
				}

				_blockedHandlerPath = _handlerPath + "-1";
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (OptimizerConfig.Enable)
			{
				string combinedSheetsSource = GetCombinedSheetsSource();

				if (string.IsNullOrEmpty(combinedSheetsSource))
				{
					//nothing to write
					return;
				}

				string combinedSheetsElement =
					string.Format("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\"></link>", combinedSheetsSource);

				writer.Write(combinedSheetsElement);
				writer.WriteLine();
			}
			else
			{
				this.DataBind();
				base.Render(writer);
			}
		}

		protected string GetCombinedSheetsSource()
		{
			List<string> scriptPaths = GetSheetPaths();

			if (scriptPaths.Count == 0)
			{
				return string.Empty;
			}

			StringBuilder objStrBuilder = new StringBuilder();
			objStrBuilder.Append(_handlerPath);

			foreach (string sPath in scriptPaths)
			{
				ScriptElement element = null;

				string fullElementPath = ResolveUrl(sPath);
				if (!fullElementPath.Contains(HttpRuntime.AppDomainAppVirtualPath))
				{//make sure to get full path with application root
					fullElementPath = HttpRuntime.AppDomainAppVirtualPath + fullElementPath;
				}

				element = OptimizerConfig.GetScriptByPath(fullElementPath);

				if (element != null)
				{
					objStrBuilder.Append(element.Key + ".");
				}

			}

			string strPath = objStrBuilder.ToString();

			if (strPath.EndsWith("."))
			{//remove last unnecessary "."
				strPath = strPath.Substring(0, strPath.LastIndexOf("."));
			}

			return strPath;
		}

		protected List<string> GetSheetPaths()
		{
			List<string> sheetPaths = new List<string>();

			this.DataBind(); //evaluate ResolveUrl() if it's being used in the link tags

			string xml = string.Format("<scripts>{0}</scripts>", this.InnerText);

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);

			XmlNodeList scripts = doc.GetElementsByTagName("link");
			foreach (XmlNode script in scripts)
			{
				if (script.Attributes["href"] != null)
				{
					string sheetPath = script.Attributes["href"].Value;
					sheetPaths.Add(sheetPath);
				}
			}

			return sheetPaths;
		}

	}
}
