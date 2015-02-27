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

#endregion


namespace SageFrame.ProfileManagement
{
    public class ProfileManagementController
    {
        public List<ProfileManagementInfo> GetPropertyTypeList()
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetPropertyTypeList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProfileManagementInfo> GetProfileList(int PortalID)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetProfileList(PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddProfile(string Name, int PropertyTypeID, string DataType, bool IsRequired, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.AddProfile(Name, PropertyTypeID, DataType, IsRequired, IsActive, AddedOn, PortalID, AddedBy);
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
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.AddProfileValue(ProfileID, Name, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateProfile(int ProfileID, string Name, int PropertyTypeID, string DataType, bool IsRequired, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                objProvider.UpdateProfile(ProfileID, Name, PropertyTypeID, DataType, IsRequired, IsActive, IsModified, UpdatedOn, PortalID, UpdatedBy);
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
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                objProvider.DeleteProfileValueByProfileID(ProfileID, PortalID, UserName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteProfileByProfileID(int DeleteID, string UserName)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                objProvider.DeleteProfileByProfileID(DeleteID, UserName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ProfileManagementInfo GetProfileByProfileID(int EditID)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetProfileByProfileID(EditID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProfileManagementInfo> GetActiveProfileValueByProfileID(int ProfileID, int PortalID)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetActiveProfileValueByProfileID(ProfileID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateProfileDisplayOrderAndIsActiveOnly(int ProfileID, int DisplayOrder, bool IsActive, DateTime UpdatedOn, int PortalID, string Username)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                objProvider.UpdateProfileDisplayOrderAndIsActiveOnly(ProfileID, DisplayOrder, IsActive, UpdatedOn, PortalID, Username);
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
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetActiveProfileList(PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProfileManagementInfo> GetListEntrybyNameAndID(string ListName, int EntryID, string Culture)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetListEntrybyNameAndID(ListName, EntryID, Culture);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<ProfileManagementInfo> GetUserProfileActiveListByUsername(string Username, int PortalID)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetUserProfileActiveListByUsername(Username, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProfileManagementInfo> GetListEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetListEntriesByNameParentKeyAndPortalID(ListName, ParentKey, PortalID, Culture);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProfileManagementInfo> GetProfileImageFolders(string EditUserName, int ProfileID, int PortalID)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.GetProfileImageFolders(EditUserName, ProfileID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddUserProfile(string Username, int ProfileID, string Value, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                ProfileManagementProvider objProvider = new ProfileManagementProvider();
                return objProvider.AddUserProfile(Username, ProfileID, Value, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
