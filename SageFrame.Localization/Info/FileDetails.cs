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

namespace SageFrame.Localization
{
    public class FileDetails
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FolderInfo { get; set; }
        public bool IsExists { get; set; }
        public FileDetails() { }
        public FileDetails(string filename, string filepath)
        {
            this.FileName = filename;
            this.FilePath = filepath;
        }
        public FileDetails(string filename, string filepath,string folderinfo)
        {
            this.FileName = filename;
            this.FilePath = filepath;
            this.FolderInfo = folderinfo;
        }
    }
}
