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
