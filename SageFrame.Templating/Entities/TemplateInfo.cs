#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace SageFrame.Templating
{
    public class TemplateInfo
    {
        public string TemplateName { get; set; }
        public string Path { get; set; }
        public string ThumbImage { get; set; }
        public bool IsActive { get; set; }
        public PresetInfo DefaultPreset { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public bool IsDefault { get; set; }
        public int PortalID { get; set; }
        public bool IsApplied { get; set; }
        public TemplateInfo() { }
        public TemplateInfo(string _TemplateName)
        {
            this.TemplateName = _TemplateName;
        }
        public string TemplateSeoName
        {
            get { return (TemplateName.Replace(' ', '_')); }            
        }
        public TemplateInfo(string _TemplateName, string _Path, string _ThumbImage,bool _IsActive,bool _IsDefault)
        {
            this.TemplateName = _TemplateName;
            this.Path = _Path;
            this.ThumbImage = _ThumbImage;
            this.IsActive = _IsActive;
            this.IsDefault = _IsDefault;
        }
    }
}
