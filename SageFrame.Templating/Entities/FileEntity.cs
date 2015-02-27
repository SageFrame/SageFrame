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
    public class FileEntity
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public bool IsFolder { get; set; }
        public long Size { get; set; }
        public string CreatedDate { get; set; }

        public FileEntity() { }
        public FileEntity(string _FileName, string _FilePath, string _FileExtension, bool _IsFolder, long _Size,string _CreatedDate)
        {
            this.FileName = _FileName;
            this.FilePath = _FilePath;
            this.FileExtension = _FileExtension;
            this.IsFolder = _IsFolder;
            this.Size = _Size;
            this.CreatedDate = _CreatedDate;
        }
    }
}
