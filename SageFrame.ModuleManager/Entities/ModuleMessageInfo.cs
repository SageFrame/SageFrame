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

namespace SageFrame.ModuleMessage
{
    public class ModuleMessageInfo
    {
        public int ModuleMessageID { get; set; }
        public int ModuleID { get; set; }
        public string Message { get; set; }
        public string Culture { get; set; }
        public bool IsActive { get; set; }
        public int MessageType { get; set; }
        public int MessageMode { get; set; }
        public bool DisableAll { get; set; }
        public string FriendlyName { get; set; }
        public int MessagePosition { get; set; }

        public ModuleMessageInfo() { }

        public ModuleMessageInfo(int _ModuleID, string _Message, string _Culture, bool _IsActive, int _MessageType, int _MessageMode,bool _DisableAll)
        {
            this.ModuleID = _ModuleID;
            this.Message = _Message;
            this.Culture = _Culture;
            this.IsActive = _IsActive;
            this.MessageType = _MessageType;
            this.MessageMode = _MessageMode;
            this.DisableAll = _DisableAll;
        }
    }
}
