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
using SageFrame.Pages;
using SageFrame.PagePermission;
using System.Data.SqlClient;
using SageFrame.Web.Utilities;
using System.Data;
using SageFrame.Common;
#endregion

namespace SageFrame.Pages
{
    public class PageController
    {
        public List<PageEntity> GetMenuFront(int PortalID, bool isAdmin)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PageEntity> lstPages = objProvider.GetMenuFront(PortalID, isAdmin);
                IEnumerable<PageEntity> lstParent = new List<PageEntity>();
                List<PageEntity> pageList = new List<PageEntity>();
                lstParent = isAdmin ? from pg in lstPages where pg.Level == 1 select pg : from pg in lstPages where pg.Level == 0 select pg;
                foreach (PageEntity parent in lstParent)
                {
                    parent.PageName = parent.PageName.Replace(" ", "-");
                    pageList.Add(parent);
                    GetChildPages(ref pageList, parent, lstPages);
                }
                return pageList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GetChildPages(ref List<PageEntity> pageList, PageEntity parent, List<PageEntity> lstPages)
        {
            foreach (PageEntity obj in lstPages)
            {
                if (obj.ParentID == parent.PageID)
                {
                    obj.PageNameWithoughtPrefix = obj.PageName;
                    obj.Prefix = GetPrefix(obj.Level);
                    obj.PageName = obj.Prefix + obj.PageName.Replace(" ", "-");
                    pageList.Add(obj);
                    GetChildPages(ref pageList, obj, lstPages);
                }
            }
        }

        public string GetPrefix(int Level)
        {
            string prefix = "";
            for (int i = 0; i < Level; i++)
            {
                prefix += "----";
            }
            return prefix;
        }

        public void AddUpdatePages(PageEntity objPage)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.AddUpdatePages(objPage);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PageEntity> GetPages(int PortalID, bool isAdmin)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PageEntity> lstPages = objProvider.GetPages(PortalID, isAdmin);
                IEnumerable<PageEntity> lstParent = new List<PageEntity>();
                List<PageEntity> pageList = new List<PageEntity>();
                lstParent = (from pg in lstPages where pg.Level == 0 select pg);
                foreach (PageEntity parent in lstParent)
                {
                    pageList.Add(parent);
                    GetChildPages(ref pageList, parent, lstPages);
                }
                return pageList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddUpdatePagePermission(List<PagePermissionInfo> lstPPI, SqlTransaction tran, int pageID, int portalID, string addedBy, bool isAdmin)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.AddUpdatePagePermission(lstPPI, tran, pageID, portalID, addedBy, isAdmin);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddUpdateSelectedMenu(string SelectedMenu, SqlTransaction tran, int pageID, int ParentID, string Mode, string Caption, int PortalID, string UpdateLabel)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.AddUpdateSelectedMenu(SelectedMenu, tran, pageID, ParentID, Mode, Caption, PortalID, UpdateLabel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void MenuPageUpdate(string MenuIDs, SqlTransaction tran, int pageID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.MenuPageUpdate(MenuIDs, tran, pageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public PageEntity GetPageDetails(int pageID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                PageEntity objPE = objProvider.GetPageDetails(pageID);
                objPE.PortalID = objPE.PortalID == -1 ? 1 : objPE.PortalID;
                objPE.LstPagePermission = GetPagePermissionDetails(objPE);
                return objPE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PagePermissionInfo> GetPagePermissionDetails(PageEntity obj)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PagePermissionInfo> lst = objProvider.GetPagePermissionDetails(obj);
                return lst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PageEntity> GetChildPage(int parentID, bool? isActive, bool? isVisiable, bool? isRequiredPage, string userName, int portalID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PageEntity> lstPageEntry = objProvider.GetChildPage(parentID, isActive, isVisiable, isRequiredPage, userName, portalID);
                return lstPageEntry;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PageModuleInfo> GetPageModules(int pageID, int portalID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PageModuleInfo> objPageModuleLst = objProvider.GetPageModules(pageID, portalID);
                return objPageModuleLst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletePageModule(int moduleID, string deletedBY, int portalID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.DeletePageModule(moduleID, deletedBY, portalID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteChildPage(int pageID, string deletedBY, int portalID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.DeleteChildPage(pageID, deletedBY, portalID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void UpdatePageAsContextMenu(int pageID, bool? isVisiable, bool? isPublished, int portalID, string userName, string updateFor)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.UpdatePageAsContextMenu(pageID, isVisiable, isPublished, portalID, userName, updateFor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SortFrontEndMenu(int pageID, int parentID, string pageName, int BeforeID, int AfterID, int portalID, string userName)
        {

            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.SortFrontEndMenu(pageID, parentID, pageName, BeforeID, AfterID, portalID, userName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SortAdminPages(List<PageEntity> lstPages)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.SortAdminPages(lstPages);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public  List<PageEntity> GetPortalPages(int PortalID, string UserName, string prefix, bool IsActive, bool IsDeleted, object IsVisible, object IsRequiredPage)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PageEntity> objPageEntity = objProvider.GetPortalPages(PortalID, UserName, prefix, IsActive, IsDeleted, IsVisible, IsRequiredPage);
                return objPageEntity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PageEntity> GetActivePortalPages(int PortalID, string UserName, string prefix, bool IsActive, bool IsDeleted, object IsVisible, object IsRequiredPage)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<PageEntity> objPageEntityLst = objProvider.GetActivePortalPages(PortalID, UserName, prefix, IsActive, IsDeleted, IsVisible, IsRequiredPage);
                return objPageEntityLst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdSettingKeyValue(string PageName, int PortalID)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                objProvider.UpdSettingKeyValue(PageName, PortalID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SecurePageInfo> GetSecurePage(int portalID, string culture)
        {
            try
            {
                PageDataProvider objProvider = new PageDataProvider();
                List<SecurePageInfo> objSecureLst = objProvider.GetSecurePage(portalID, culture);
                return objSecureLst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
