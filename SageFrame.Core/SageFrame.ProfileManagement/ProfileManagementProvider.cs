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
using SageFrame.Web.Utilities;
using System.Data.SqlClient;

#endregion


namespace SageFrame.ProfileManagement
{
    public class ProfileManagementProvider
    {

        public List<ProfileManagementInfo> GetPropertyTypeList()
        {
            string sp = "sp_PropertyTypeList";
            SQLHandler sageSql = new SQLHandler();
            try
            {
                return sageSql.ExecuteAsList<ProfileManagementInfo>(sp);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public List<ProfileManagementInfo> GetProfileList(int PortalID)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_ProfileList]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      

        public int AddProfile(string Name, int PropertyTypeID, string DataType, bool IsRequired, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                string sp = "[dbo].[sp_ProfileAdd]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

                ParamCollInput.Add(new KeyValuePair<string, object>("@Name", Name));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PropertyTypeID", PropertyTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DataType", DataType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsRequired", IsRequired));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));

                int PID = SQLH.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@ProfileID");
                return PID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddProfileValue(int? ProfileID, string Name, bool IsActive, DateTime? AddedOn, int? PortalID, string AddedBy)
        {
            try
            {
                string sp = "[dbo].[sp_ProfileAdd]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Name", Name));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));

                int PVID = SQLH.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@ProfileValueID");
                return PVID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void DeleteProfileValueByProfileID(int ProfileID, int PortalID, string UserName)
        {
            try
            {
                string sp = "[dbo].[sp_ProfileValueDeleteByProfileID]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedBy", UserName));
                SQLH.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void DeleteProfileByProfileID(int DeleteID,  string UserName)
        {
            try
            {
                string sp = "[dbo].[sp_ProfileDeleteByProfileID]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", DeleteID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedBy", UserName));
               
                SQLH.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public ProfileManagementInfo GetProfileByProfileID(int EditID)
        {
            SqlDataReader reader = null;
            try
            {
                string sp = "[dbo].[sp_ProfileGetByProfileID]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", EditID));

                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                ProfileManagementInfo objList = new ProfileManagementInfo();

                while (reader.Read())
                {

                    objList.ProfileID = int.Parse(reader["ProfileID"].ToString());
                    objList.Name = reader["Name"].ToString();
                    objList.PropertyTypeID = int.Parse(reader["PropertyTypeID"].ToString());
                    objList.DataType = reader["DataType"].ToString();
                    objList.IsRequired = bool.Parse(reader["IsRequired"].ToString());
                    objList.DisplayOrder = int.Parse(reader["DisplayOrder"].ToString());
                    objList.IsActive = bool.Parse(reader["IsActive"].ToString());
                    objList.IsDeleted = bool.Parse(reader["IsDeleted"].ToString());
                    objList.IsDeleted = bool.Parse(reader["IsModified"].ToString());
                    objList.UpdatedOn = DateTime.Parse(reader["UpdatedOn"].ToString());
                    objList.PortalID = int.Parse(reader["PortalID"].ToString());
                    objList.UpdatedBy = reader["UpdatedBy"].ToString();

                }
                return objList;


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        public void UpdateProfile(int ProfileID, string Name, int PropertyTypeID, string DataType, bool IsRequired, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                string sp = "[dbo].[sp_ProfileUpdate]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Name", Name));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PropertyTypeID", PropertyTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DataType", DataType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsRequired", IsRequired));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsModified", IsModified));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));

                SQLH.ExecuteNonQuery(sp, ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
            

        public List<ProfileManagementInfo> GetActiveProfileValueByProfileID(int ProfileID ,int PortalID)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_ProfileValueGetActiveByProfileID]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void UpdateProfileDisplayOrderAndIsActiveOnly(int ProfileID, int DisplayOrder, bool IsActive, DateTime UpdatedOn, int PortalID, string Username)
        {
            try
            {
                string sp = "[dbo].[sp_ProfileUpdateDisplayOrderAndIsActiveOnly]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder", DisplayOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", Username));

                SQLH.ExecuteNonQuery(sp, ParamCollInput);
       
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public List<ProfileManagementInfo> GetActiveProfileList(int PortalID)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_ProfileListActive]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ProfileManagementInfo> GetListEntrybyNameAndID(string ListName,int EntryID, string Culture )
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ListName", ListName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@EntryID", EntryID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Culture", Culture));
                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_GetListEntrybyNameAndID]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ProfileManagementInfo> GetUserProfileActiveListByUsername(string Username, int PortalID)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_UserProfileActiveListByUsername]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ProfileManagementInfo> GetListEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ListName", ListName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ParentKey", ParentKey));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Culture", Culture));

                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_GetListEntriesByNameParentKeyAndPortalID]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ProfileManagementInfo> GetProfileImageFolders(string EditUserName, int ProfileID, int PortalID)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@EditUserName", EditUserName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return SQLH.ExecuteAsList<ProfileManagementInfo>("[dbo].[sp_ProfileImageFoldersGet]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int AddUserProfile(string Username, int ProfileID, string Value, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                string sp = "[dbo].[sp_UserProfileAdd]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ProfileID", ProfileID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Value", Value));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));

                int PVID = SQLH.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@UserProfileID");
                return PVID;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
