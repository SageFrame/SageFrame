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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using System.Web.UI.HtmlControls;

namespace SageFrame.Controls
{
    public partial class sectionheadcontrol : BaseAdministrationUserControl
    {
        //protected System.Web.UI.WebControls.Label lblTitle;

        //protected System.Web.UI.WebControls.ImageButton imgIcon;

        //protected System.Web.UI.WebControls.Panel pnlRule;

        private bool _includeRule = false;

        private bool _isExpanded = true;



        private string _javaScript = "__sfe_SectionMaxMin";

        private string _maxImageUrl = string.Empty;

        private string _minImageUrl = string.Empty;

        private string _resourceKey;

        private string _section;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// CssClass determines the Css Class used for the Title Text
        /// </summary>
        /// <value>A string representing the name of the css class</value>
        /// <remarks>
        /// </remarks>
        /// <history>
        ///     [alok]    03/30/2010    created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string CssClass
        {
            get
            {
                return lblTitle.CssClass;
            }
            set
            {
                lblTitle.CssClass = value;
            }
        }

        public bool IncludeRule
        {
            get
            {
                return _includeRule;
            }
            set
            {
                _includeRule = value;
            }
        }

        public bool IsExpanded
        {
            get
            {
                //if (_isExpanded != null)
                //{
                //    return _isExpanded;
                //}
                //else if (ViewState["IsExpanded"] != null)
                //{
                //    bool temp = bool.Parse(ViewState["IsExpanded"].ToString());
                //    return temp;
                //}
                //else
                //{
                return _isExpanded;
                //}

            }
            set
            {
                _isExpanded = value;
            }
        }

        public string JavaScript
        {
            get
            {
                return _javaScript;
            }
            set
            {
                _javaScript = value;
            }
        }

        public string MaxImageUrl
        {
            get
            {
                return GetTemplateImageUrl("plus.png",false); 
            }
            set
            {
                _maxImageUrl = value;
            }
        }

        public string MinImageUrl
        {
            get
            {
                return GetTemplateImageUrl("minus.png", false);
            }
            set
            {
                _minImageUrl = value;
            }
        }

        public string ResourceKey
        {
            get
            {
                return _resourceKey;
            }
            set
            {
                _resourceKey = value;
            }
        }

        public string Section
        {
            get
            {
                return _section;
            }
            set
            {
                _section = value;
            }
        }

        public string Text
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Assign resource key to label for localization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        ///    [alok]    03/30/2010    created
        /// </history>
        /// -----------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //HtmlControl ctl = ((HtmlControl)(this.Parent.FindControl(Section)));
                    //if (!(ctl == null))
                    //{
                        
                    //}

                    // set the resourcekey attribute to the label
                    if ((ResourceKey != ""))
                    {
                        //lblTitle.Attributes["resourcekey"] = ResourceKey;
                        lblTitle.Text = Text;
                    }
                }
               
            }
            catch (Exception exc)
            {
                // Module failed to load
                ProcessException(exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Renders the SectionHeadControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        ///     [alok]    03/30/2010    created        
        /// </history>
        /// -----------------------------------------------------------------------------
        protected void Page_PreRender(object sender, System.EventArgs e)
        {
           
        }

       
    }
}