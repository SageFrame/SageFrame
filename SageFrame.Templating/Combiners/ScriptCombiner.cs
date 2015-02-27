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
	public class ScriptCombiner : HtmlContainerControl
	{

		private string _handlerPath;
		private string _blockedHandlerPath;
		private Dictionary<string, string> _scripts = new Dictionary<string, string>();

		public ScriptCombiner()
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
				string combinedScriptsSource = GetCombinedScriptsSource();
				string combinedScriptsElement =
					string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", combinedScriptsSource);

				writer.Write(combinedScriptsElement);
				writer.WriteLine();
			}
			else
			{
				this.DataBind();
				base.Render(writer);
			}
		}

		protected string GetCombinedScriptsSource()
		{
			List<string> scriptPaths = GetScriptPaths();

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

		protected List<string> GetScriptPaths()
		{
			List<string> scriptPaths = new List<string>();

			this.DataBind();	//evaluate ResolveUrl() if it's being used in the script tags

			string xml = string.Format("<scripts>{0}</scripts>", this.InnerText);

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);

			XmlNodeList scripts = doc.GetElementsByTagName("script");
			foreach (XmlNode script in scripts)
			{
				if (script.Attributes["src"] != null)
				{
					string scriptPath = script.Attributes["src"].Value;
					scriptPaths.Add(scriptPath);
				}
			}

			return scriptPaths;
		}

	}
}
