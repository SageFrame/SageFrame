using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.UI;
using System.Web;

namespace SageFrame.Common
{
    public class TemplateValidation
    {


        public static bool GetTemplateValidation()
        {
            
            Type type = Type.GetType("SageFrame.Core.SetLayout");
            if (type == null)
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                path += @"bin\SageFrame.layout.dll";
                Assembly assembly = Assembly.LoadFile(path);
                type = assembly.GetType("SageFrame.Core.SetLayout");
            }
            var method = type.GetMethod("BuildLayoutMessage", BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Validate()
        {
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, typeof(Page), "globalVariables", " var ValidTemplate='" + GetTemplateValidation().ToString() + "';", true);
        }
    }
}
