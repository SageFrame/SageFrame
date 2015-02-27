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
using SageFrame.Web.Utilities;
using System.Data;
using System.Data.SqlClient;
using SageFrame.Web;
using SageFrame.Core;
using System.Data.Common;

namespace SageFrame.FileManager
{
    public class FileMangerDataProvider
    {
        public static void AddFolder(Folder folder)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalId", folder.PortalId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ParentFolderID", folder.ParentID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderPath", folder.FolderPath));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@StorageLocation", folder.StorageLocation));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UniqueId", folder.UniqueId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@VersionGuid", folder.VersionGuid));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", folder.IsActive));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", folder.AddedBy));
            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerAddFolder", ParaMeterCollection);

        }

        public static void AddRootFolder(Folder folder)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalId", folder.PortalId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderPath", folder.FolderPath));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@StorageLocation", folder.StorageLocation));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UniqueId", folder.UniqueId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@VersionGuid", folder.VersionGuid));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", folder.IsActive));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", folder.AddedBy));
            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerAddRootFolder", ParaMeterCollection);
        }

        public static int AddFolderReturnFolderID(Folder folder)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalId", folder.PortalId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ParentFolderID", folder.ParentID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderPath", folder.FolderPath));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@StorageLocation", folder.StorageLocation));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UniqueId", folder.UniqueId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@VersionGuid", folder.VersionGuid));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", folder.IsActive));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", folder.AddedBy));
            SQLHandler sagesql = new SQLHandler();
            int FolderID = sagesql.ExecuteNonQueryAsGivenType<int>("[usp_FileManagerAddFolderRetFolderID]", ParaMeterCollection, "@FolderID");

            return FolderID;

        }

        public static void AddFile(ATTFile file)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalId", file.PortalId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UniqueId", file.UniqueId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@VersionGuid", file.VersionGuid));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileName", file.FileName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Extension", file.Extension));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Size", file.Size));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ContentType", file.ContentType));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Folder", file.Folder));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderId", file.FolderId));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", file.IsActive));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", file.AddedBy));
            if (file.StorageLocation == 2)
            {
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Content", file.Content));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("usp_FileManagerAddDatabaseFile", ParaMeterCollection);
            }
            else
            {
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("usp_FileManagerAddFile", ParaMeterCollection);

            }
        }

        public static List<Folder> GetFolders()
        {
            List<Folder> lstFolders = new List<Folder>();
            string StoredProcedureName = "usp_FileManagerGetFolders";
            SqlDataReader SQLReader;
            SQLHandler sagesql = new SQLHandler();
            try
            {
               
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName);
                while (SQLReader.Read())
                {
                    Folder obj = new Folder();
                    obj.FolderId = int.Parse(SQLReader["FolderId"].ToString());
                    obj.FolderPath = SQLReader["FolderPath"].ToString();
                    obj.StorageLocation = int.Parse(SQLReader["StorageLocation"].ToString());
                    lstFolders.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
             

            return lstFolders;
        }

        public static List<Folder> GetRootFolders()
        {
            List<Folder> lstFolders = new List<Folder>();
            string StoredProcedureName = "usp_FileManagerGetRootFolders";           
            try
            {
                SqlDataReader SQLReader;
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName);
                while (SQLReader.Read())
                {
                    Folder obj = new Folder();
                    obj.FolderId = int.Parse(SQLReader["FolderId"].ToString());
                    obj.FolderPath = SQLReader["FolderPath"].ToString();
                    obj.StorageLocation = int.Parse(SQLReader["StorageLocation"].ToString());
                    obj.IsEnabled = bool.Parse(SQLReader["IsActive"].ToString());
                    lstFolders.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
           
           
            return lstFolders;
        }

        public static List<Folder> GetActiveRootFolders()
        {
            List<Folder> lstFolders = new List<Folder>();
            string StoredProcedureName = "usp_FileManagerGetActiveRootFolders";          
            try
            {
                SqlDataReader SQLReader;
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName);
                while (SQLReader.Read())
                {
                    Folder obj = new Folder();
                    obj.FolderId = int.Parse(SQLReader["FolderId"].ToString());
                    obj.FolderPath = SQLReader["FolderPath"].ToString();
                    obj.StorageLocation = int.Parse(SQLReader["StorageLocation"].ToString());
                    obj.IsEnabled = bool.Parse(SQLReader["IsActive"].ToString());
                    lstFolders.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
           
            return lstFolders;
        }

        public static List<Folder> GetAllFolders()
        {
            List<Folder> lstFolders = new List<Folder>();
            string StoredProcedureName = "usp_FileManagerGetAllFolders";           
            try
            {
                SqlDataReader SQLReader;
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName);
                while (SQLReader.Read())
                {
                    Folder obj = new Folder();
                    obj.FolderId = int.Parse(SQLReader["FolderId"].ToString());
                    obj.FolderPath = SQLReader["FolderPath"].ToString();
                    obj.StorageLocation = int.Parse(SQLReader["StorageLocation"].ToString());
                    lstFolders.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }            

            return lstFolders;


        }

        public static List<ATTFile> GetFiles(int FolderID)
        {
            List<ATTFile> lstFiles = new List<ATTFile>();
            string StoredProcedureName = "usp_FileManagerGetFiles";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    ATTFile obj = new ATTFile();
                    obj.FileId = int.Parse(SQLReader["FileId"].ToString());
                    obj.FolderId = int.Parse(SQLReader["FolderId"].ToString());
                    obj.FileName = SQLReader["FileName"].ToString();
                    obj.Folder = SQLReader["Folder"].ToString();
                    obj.Extension = SQLReader["Extension"].ToString();
                    obj.Size = int.Parse(SQLReader["Size"].ToString());
                    obj.AddedOn = SQLReader["AddedOn"].ToString();
                    obj.Content = SQLReader["Content"] == DBNull.Value ? null : (byte[])SQLReader["Content"];
                    obj.StorageLocation = int.Parse(SQLReader["StorageLocation"].ToString());

                    lstFiles.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstFiles;
        }

        public static List<ATTFile> SearchFiles(string SearchQuery)
        {
            List<ATTFile> lstFiles = new List<ATTFile>();
            string StoredProcedureName = "usp_FileManagerSearchFiles";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@SearchQuery", SearchQuery));
            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    ATTFile obj = new ATTFile();
                    obj.FileId = int.Parse(SQLReader["FileId"].ToString());
                    obj.FileName = SQLReader["FileName"].ToString();
                    obj.Folder = SQLReader["Folder"].ToString();
                    obj.Extension = SQLReader["Extension"].ToString();
                    obj.Size = int.Parse(SQLReader["Size"].ToString());
                    obj.AddedOn = SQLReader["AddedOn"].ToString();
                    obj.Content = SQLReader["Content"] == DBNull.Value ? null : (byte[])SQLReader["Content"];
                    obj.StorageLocation = int.Parse(SQLReader["StorageLocation"].ToString());

                    lstFiles.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstFiles;
        }

        public static void DeleteFileFolder(int FolderID, int FileID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileID", FileID));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerDeleteFileFolder", ParaMeterCollection);
        }

        public static void DeleteRootFolder(int FolderID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerDeleteRootFolder", ParaMeterCollection);
        }

        public static void EnableRootFolder(int FolderID, bool IsEnabled)
        {
            string sp = "usp_FileManagerDisableRootFolder";
            if (IsEnabled)
                sp = "usp_FileManagerEnableRootFolder";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery(sp, ParaMeterCollection);
        }

        public static ATTFile GetFileDetails(int FileID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileID", FileID));

            SQLHandler sagesql = new SQLHandler();
            ATTFile obj = new ATTFile();
            obj = sagesql.ExecuteAsObject<ATTFile>("usp_FileManagerGetFileDetails", ParaMeterCollection);
            return obj;
        }

        public static void UpdateFile(int FileID, string fileName)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileID", FileID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileName", fileName));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerUpdateFile", ParaMeterCollection);


        }

        public static void CopyFile(int FileID, int FolderID, string Folder, Guid UniqueID, Guid VersionGuid)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileID", FileID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Folder", Folder));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UniqueID", UniqueID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@VersionGuid", VersionGuid));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerCopyFile", ParaMeterCollection);

        }

        public static void MoveFile(int FileID, int FolderID, string Folder, Guid UniqueID, Guid VersionGuid)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FileID", FileID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Folder", Folder));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UniqueID", UniqueID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@VersionGuid", VersionGuid));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerMoveFile", ParaMeterCollection);
        }

        public static void SetFolderPermission(int FolderID, string PermissionKey, int UserID, Guid RoleID, int IsActive, string AddedBy)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PermissionKey", PermissionKey));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserID", UserID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@RoleID", RoleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerSetFolderPermission", ParaMeterCollection);
        }

        public static void DeleteExistingPermissions(int FolderID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_FileManagerDeleteExistingPermissions", ParaMeterCollection);

        }

        public static List<FolderPermission> GetFolderPermissions(int FolderID)
        {
            List<FolderPermission> lstFolderPer = new List<FolderPermission>();
            string StoredProcedureName = "usp_FileManagerGetFolderPermission";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    FolderPermission obj = new FolderPermission();
                    obj.FolderID = int.Parse(SQLReader["FolderID"].ToString());
                    obj.UserID = int.Parse(SQLReader["UserID"].ToString());
                    obj.PermissionID = int.Parse(SQLReader["PermissionID"].ToString());
                    obj.PermissionKey = SQLReader["PermissionKey"].ToString();
                    obj.RoleID = new Guid(SQLReader["RoleID"].ToString());
                    obj.UserName = SQLReader["UserName"].ToString() ?? SQLReader["UserName"].ToString();

                    lstFolderPer.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstFolderPer;
        }

        public static List<FolderPermission> GetUserListForFolder(int FolderID)
        {
            List<FolderPermission> lstFolderPer = new List<FolderPermission>();
            string StoredProcedureName = "usp_FileManagerGetUsersWithPermissions";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    FolderPermission obj = new FolderPermission();
                    obj.UserID = int.Parse(SQLReader["UserID"].ToString());
                    obj.UserName = SQLReader["UserName"].ToString() ?? SQLReader["UserName"].ToString();

                    lstFolderPer.Add(obj);
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstFolderPer;
        }

        public static int GetUserID(string userName)
        {
            string StoredProcedureName = "usp_FileManagerGetUserID";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", userName));

            int UserID = 0;
            UserID = sagesql.ExecuteAsScalar<int>(StoredProcedureName, ParaMeterCollection);
            return UserID;
        }

        public static List<string> GetPermissionKeys(int FolderID, int UserID, int UserModuleID, string UserName)
        {
            List<string> lstPermissions = new List<string>();
            string StoredProcedureName = "usp_FileManagerGetFolderPermissionByUserID";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FolderID", FolderID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserID", UserID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", UserName));
            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    lstPermissions.Add(SQLReader["permissionkey"].ToString());
                }
                SQLReader.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstPermissions;
        }

        public static List<string> GetModulePermission(int UserModuleID, string UserName)
        {
            List<string> lstPermissions = new List<string>();
            string StoredProcedureName = "usp_FileManagerGetModulePermission";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", UserName));
            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    lstPermissions.Add(SQLReader["permissionkey"].ToString());
                }
                SQLReader.Dispose();
                
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstPermissions;
        }

        public static List<FileManagerSettingInfo> GetFileManagerSettings(int UserModuleID, int PortalID)
        {
            List<FileManagerSettingInfo> lstSettings = new List<FileManagerSettingInfo>();
            string StoredProcedureName = "usp_FileManagerSettingGetAll";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

            try
            {
                lstSettings = sagesql.ExecuteAsList<FileManagerSettingInfo>(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstSettings;
        }

        public static void AddUpdateSettings(List<FileManagerSettingInfo> lstSettings)
        {
            foreach (FileManagerSettingInfo obj in lstSettings)
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", obj.UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingKey", obj.SettingKey));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingValue", obj.SettingValue));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", obj.IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", obj.PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", obj.UpdatedBy));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", obj.AddedBy));

                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("usp_FileManagerSettingAddUpdate", ParaMeterCollection);
            }
        }
    }


}
