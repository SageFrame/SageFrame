#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

#endregion


/// <summary>
/// Summary description for ImageFile
/// </summary>
public class ImageFile
{
        public string ThumbImageFileName { get; set; }
        public string FileName { get; set; }
        public string Size { get; set; }
        public string CreatedDate { get; set; }
}
