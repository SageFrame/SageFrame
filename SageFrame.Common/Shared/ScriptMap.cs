/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SageFrame.Common.Shared
{
    public static class ScriptMap
    {
        /// <summary>
        /// Core SageFrame Scripts
        /// </summary>
        public static KeyValuePair<string, string> CoreJsonKVP = new KeyValuePair<string, string>("SageJSON", "/js/json2.js");

        /// <summary>
        /// BreadCrumb Scripts
        /// </summary>
        public static KeyValuePair<string, string> BreadCrumbScript = new KeyValuePair<string, string>("BreadCrumbScript", "/js/BreadCrumb/BreadCrumb.js");
        /// <summary>
        /// Admin Menu Scripts
        /// </summary>
        public static KeyValuePair<string, string> MenuJQueryHoverIntent = new KeyValuePair<string, string>("JQueryHoverIntent", "/Modules/SageMenu/js/hoverIntent.js");
        public static KeyValuePair<string, string> MenuJQuerySuperFish = new KeyValuePair<string, string>("JQuerySuperFish", "/Modules/SageMenu/js/superfish.js");
        public static KeyValuePair<string, string> MenuSageAdminMenuScript = new KeyValuePair<string, string>("SageAdminMenuScript", "/js/Menu/AdminMenu.js");
        public static KeyValuePair<string, string> AdminMenuScript = new KeyValuePair<string, string>("AdminMenuScript", "/js/Menu/SageAdminMenu.js");
        /// <summary>
        /// Sage Menu Scripts
        /// </summary>
        public static KeyValuePair<string, string> SageMenuHoverIntent = new KeyValuePair<string, string>("JQueryHoverIntent", "js/hoverIntent.js");
        public static KeyValuePair<string, string> SageMenuSuperFish = new KeyValuePair<string, string>("JQuerySuperFish", "js/superfish.js");
        public static KeyValuePair<string, string> MenuSageMenuScript = new KeyValuePair<string, string>("SageMenuScript", "js/SageMenu.min.js");

         
           
        
        
    }
}
