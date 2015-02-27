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
using System.Web;
#endregion

namespace SageFrame.FileManager
{
    public class FileCacheInfo
    {
        public int FolderID { get; set; }
        public List<ATTFile> LSTFiles { get; set; }
        public FileCacheInfo() { }

    }
   
}
