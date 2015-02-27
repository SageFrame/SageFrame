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
