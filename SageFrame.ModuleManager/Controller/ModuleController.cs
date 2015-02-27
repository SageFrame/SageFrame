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
using SageFrame.ModuleManager.DataProvider;
#endregion

namespace SageFrame.ModuleManager.Controller
{
    public class ModuleController
    {
        public static string AddUserModule(UserModuleInfo usermodule)
        {
            try
            {
                ModuleDataProvider mod = new ModuleDataProvider();
                return(mod.AddUserModule(usermodule));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<UserModuleInfo> GetPageModules(int PageID, int PortalID,bool IsHandheld)
        {
            try
            {
                return (ModuleDataProvider.GetPageModules(PageID, PortalID,IsHandheld));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void DeleteUserModule(int UserModuleID, int PortalID, string DeletedBy)
        {
            try
            {
                ModuleDataProvider.DeleteUserModule(UserModuleID, PortalID, DeletedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void UpdatePageModule(List<PageModuleInfo> lstPageModules)
        {

            try
            {
                ModuleDataProvider.UpdatePageModule(lstPageModules);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<UserModuleInfo> GetPageUserModules(bool IsAdmin)
        {
            try
            {
                return (ModuleDataProvider.GetPageUserModules(IsAdmin));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static UserModuleInfo GetUserModuleDetails(int UserModuleID, int PortalID)
        {
            try
            {
                return (ModuleDataProvider.GetUserModuleDetails(UserModuleID, PortalID));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void UpdateUserModule(UserModuleInfo module)
        {
            try
            {
                ModuleDataProvider.UpdateUserModule(module);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static bool PublishPage(int pageId,bool isPublish)
        {
            return ModuleDataProvider.PublishPage(pageId,isPublish);
        }
    }
}
