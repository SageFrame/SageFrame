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
using System.Data;

#endregion


namespace SageFrame.Core.ListManagement
{
    public class ListManagementController
    {


        public List<ListManagementInfo> GetListEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListEntriesByNameParentKeyAndPortalID(ListName, ParentKey, PortalID, Culture);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ListManagementInfo> GetListCopyEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListCopyEntriesByNameParentKeyAndPortalID(ListName, ParentKey, PortalID, Culture);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // var listLevel = dbList.sp_GetListEntrybyNameValueAndEntryID(selectedListName, "", int.Parse(ddlParentEntry.SelectedValue.ToString()), GetCurrentCultureName);
        public List<ListManagementInfo> GetListEntriesByNameValueAndEntryID(string ListName, string Value, int EntryID, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListEntriesByNameValueAndEntryID(ListName, Value, EntryID, Culture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ListManagementInfo GetListEntryDetails(string ListName, string Value, int EntryID, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListEntryDetails(ListName, Value, EntryID, Culture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewList(ListInfo objList)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.AddNewList(objList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void UpdateListEntry(int entryId, string value, string text, string currencyCode, string displayLocale, string Description, bool isActive, string createdBy, string CurrentCultureName)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                objProvider.UpdateListEntry(entryId, value, text, currencyCode, displayLocale, Description, isActive, createdBy, CurrentCultureName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteListEntry(int EntryId, bool DeleteChild, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.DeleteListEntry(EntryId, DeleteChild, Culture);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void SortList(int EntryId, bool MoveUp, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                objProvider.SortList(EntryId, MoveUp, Culture);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<ListManagementInfo> GetEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetEntriesByNameParentKeyAndPortalID(ListName, ParentKey, PortalID, Culture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ListManagementInfo> GetListEntrybyNameAndID(string ListName, int EntryID, string Culture)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListEntrybyNameAndID(ListName, EntryID, Culture);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FeedbackFormAdd(string _FormTitle, string _FormInformation, string _Name, string _PermanentCountry, string _PermanentState,
                  string _PermanentCity, string _PermanentZipCode, string _PermanentPostCode, string _PermanentAddress, string _TemporaryCountry,
                  string _TemporaryState, string _TemporaryCity, string _TemporaryZipCode, string _TemporaryPostalCode,
                  string _TemporaryAddress, string _Email1, string _Email2, string _Phone1, string _Phone2, string _Mobile,
                  string _Company, string _Website, string _Message, string _Attachment, bool status, DateTime date, int PortalID, string username)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                objProvider.FeedbackFormAdd(_FormTitle, _FormInformation, _Name, _PermanentCountry, _PermanentState,
                  _PermanentCity, _PermanentZipCode, _PermanentPostCode, _PermanentAddress, _TemporaryCountry,
                  _TemporaryState, _TemporaryCity, _TemporaryZipCode, _TemporaryPostalCode,
                  _TemporaryAddress, _Email1, _Email2, _Phone1, _Phone2, _Mobile,
                  _Company, _Website, _Message, _Attachment, status, date, PortalID, username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable FeedbackItemGet(int PortalID, string CultureName)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.FeedbackItemGet(PortalID, CultureName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetFeedbackSettingValueList(int PortalID)
        {
            ListManagementProvider objProvider = new ListManagementProvider();
            return objProvider.GetFeedbackSettingValueList(PortalID);
        }
        public List<ListInfo> GetDefaultList(string CultureName, int PortalID)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetDefaultList(CultureName, PortalID);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<ListInfo> GetListByPortalID(string CultureName, int PortalID)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListByPortalID(CultureName, PortalID);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ListInfo> GetListInfo(string listName, string parentId, int portalID, string cultureName)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListInfo(listName, parentId, portalID, cultureName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet GetListInfoInDataSet(string listName, string parentId, int portalID, string cultureName)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListInfoInDataSet(listName, parentId, portalID, cultureName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<ListManagementInfo> GetListEntryByParentID(int entryId, string cultureName)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListEntryByParentID(entryId, cultureName);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ListInfo> GetListInfo(string listName, string culture, int parentId)
        {
            try
            {
                ListManagementProvider objProvider = new ListManagementProvider();
                return objProvider.GetListInfo(listName, culture, parentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
