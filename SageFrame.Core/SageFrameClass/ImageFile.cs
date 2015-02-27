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
