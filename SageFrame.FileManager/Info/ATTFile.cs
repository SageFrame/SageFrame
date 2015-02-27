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

namespace SageFrame.FileManager
{
    public class ATTFile
    {
        public int FileId { get; set; }
        public int PortalId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public Guid UniqueId { get; set; }
        public Guid VersionGuid { get; set; }
        public string ContentType { get; set; }
        public string Folder { get; set; }
        public int FolderId { get; set; }
        public int StorageLocation { get; set; }
        public int IsActive { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
        public byte[] Content { get; set; }

        public ATTFile(string fileName, string folder, int folderID, string addedBy, string extension, int portalId, Guid uniqueId, Guid versionId, int size, string contentType, int isActive, int storageLocation)
        {
            this.FileName = fileName;
            this.Folder = folder;
            this.FolderId = folderID;
            this.AddedBy = addedBy;
            this.Extension = extension;
            this.PortalId = portalId;
            this.UniqueId = uniqueId;
            this.VersionGuid = versionId;
            this.Size = size;
            this.ContentType = contentType;
            this.IsActive = isActive;
            this.StorageLocation = storageLocation;

        }
        public ATTFile(string fileName, string folder, int size, string contentType)
        {
            this.FileName = fileName;
            this.Folder = folder;
            this.Size = size;
            this.ContentType = contentType;
        }

        public ATTFile() { }

    }
}
