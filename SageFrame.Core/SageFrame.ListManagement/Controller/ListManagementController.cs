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

namespace SageFrame.Core.ListManagement
{
    public class ListManagementController
    {


        public static List<ListManagementInfo> GetListEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {
                return ListManagementProvider.GetListEntriesByNameParentKeyAndPortalID(ListName, ParentKey, PortalID, Culture);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }
        // var listLevel = dbList.sp_GetListEntrybyNameValueAndEntryID(selectedListName, "", int.Parse(ddlParentEntry.SelectedValue.ToString()), GetCurrentCultureName);
        public static List<ListManagementInfo> GetListEntriesByNameValueAndEntryID(string ListName, string Value, int EntryID, string Culture)
        {
            try
            {
               return ListManagementProvider.GetListEntriesByNameValueAndEntryID(ListName, Value, EntryID, Culture);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static ListManagementInfo GetListEntryDetails(string ListName, string Value, int EntryID, string Culture)
        {
            try
            {
                return ListManagementProvider.GetListEntryDetails(ListName, Value, EntryID, Culture);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static int AddNewList(ListInfo objList)
        {
            try
            {
                return ListManagementProvider.AddNewList(objList);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static void UpdateListEntry(int entryId, string value, string text, string currencyCode, string displayLocale, string Description, bool isActive, string createdBy, string CurrentCultureName)
        {
            try
            {
                ListManagementProvider.UpdateListEntry(entryId, value, text, currencyCode, displayLocale, Description, isActive, createdBy, CurrentCultureName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void DeleteListEntry(int EntryId, bool DeleteChild, string Culture)
        {
            try
            {
                ListManagementProvider.DeleteListEntry(EntryId, DeleteChild, Culture);
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }
        public static void SortList(int EntryId, bool MoveUp, string Culture)
        {
            try
            {
                ListManagementProvider.SortList(EntryId, MoveUp, Culture);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public static List<ListManagementInfo> GetEntriesByNameParentKeyAndPortalID(string ListName, string ParentKey, int PortalID, string Culture)
        {
            try
            {
                return ListManagementProvider.GetEntriesByNameParentKeyAndPortalID(ListName, ParentKey, PortalID, Culture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<ListManagementInfo> GetListEntrybyNameAndID(string ListName, int EntryID, string Culture)
        {
            try
            {
                return ListManagementProvider.GetListEntrybyNameAndID(ListName, EntryID, Culture);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public static void FeedbackFormAdd(string _FormTitle, string _FormInformation, string _Name, string _PermanentCountry, string _PermanentState,
                  string _PermanentCity, string _PermanentZipCode, string _PermanentPostCode, string _PermanentAddress, string _TemporaryCountry,
                  string _TemporaryState, string _TemporaryCity, string _TemporaryZipCode, string _TemporaryPostalCode,
                  string _TemporaryAddress, string _Email1, string _Email2, string _Phone1, string _Phone2, string _Mobile,
                  string _Company, string _Website, string _Message, string _Attachment, bool status, DateTime date, int PortalID, string username)
        {
            try
            {
                ListManagementProvider.FeedbackFormAdd(_FormTitle, _FormInformation, _Name, _PermanentCountry, _PermanentState,
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

        public static DataTable FeedbackItemGet(int PortalID, string CultureName)
        {
            try
            {
                return ListManagementProvider.FeedbackItemGet(PortalID, CultureName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static string GetFeedbackSettingValueList(int PortalID)
        {
            return ListManagementProvider.GetFeedbackSettingValueList(PortalID);
        }
       
    }
}
