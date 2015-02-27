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


namespace SageFrame.Modules
{
    public class ModuleController
    {
        public int[] AddModules(ModuleInfo objList, bool isAdmin, int PackageID, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.AddModules(objList, isAdmin, PackageID, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddPortalModules(int? PortalID, int? ModuleID, bool IsActive, DateTime AddedOn, string AddedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.AddPortalModules(PortalID, ModuleID, IsActive, AddedOn, AddedBy);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int GetPermissionByCodeAndKey(string PermissionCode, string PermissionKey)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.GetPermissionByCodeAndKey(PermissionCode, PermissionKey);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  int[] AddModulePermission(int? ModuleDefID, int? PermissionID, int? PortalID, int? PortalModuleID, bool AllowAccess, string Username, bool IsActive, DateTime AddedOn, string AddedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.AddModulePermission(ModuleDefID, PermissionID, PortalID, PortalModuleID, AllowAccess, Username, IsActive, AddedOn, AddedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  int AddModuleCoontrols(int? ModuleDefID, string ControlKey, string ControlTitle, string ControlSrc, string IconFile, int ControlType, int DisplayOrder, string HelpUrl, bool SupportsPartialRendering, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.AddModuleCoontrols(ModuleDefID, ControlKey, ControlTitle, ControlSrc, IconFile, ControlType, DisplayOrder, HelpUrl, SupportsPartialRendering, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  void UpdateExtension(ModuleInfo objInfo)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                objProvider.UpdateExtension(objInfo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  void DeletePackagesByModuleID(int PortalID, int ModuleID)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                objProvider.DeletePackagesByModuleID(PortalID, ModuleID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  List<ModuleInfo> GetAllExistingModule()
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.GetAllExistingModule();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public  ModuleEntities ModuleControlsGetByModuleControlID(int ModuleControlID)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.ModuleControlsGetByModuleControlID(ModuleControlID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  void UpdateModuleCoontrols(int ModuleControlID, string ControlKey, string ControlTitle, string ControlSrc, string IconFile, int ControlType, int DisplayOrder, string HelpUrl, bool SupportsPartialRendering, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                objProvider.UpdateModuleCoontrols(ModuleControlID, ControlKey, ControlTitle, ControlSrc, IconFile, ControlType, DisplayOrder, HelpUrl, SupportsPartialRendering, IsActive, IsModified, UpdatedOn, PortalID, UpdatedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  int CheckUnquieModuleControlsControlType(int ModuleControlID, int ModuleDefID, int ControlType, int PortalID, bool isEdit)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.CheckUnquieModuleControlsControlType(ModuleControlID, ModuleDefID, ControlType, PortalID, isEdit);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  void ModuleControlsDeleteByModuleControlID(int ModuleControlID, string DeletedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                objProvider.ModuleControlsDeleteByModuleControlID(ModuleControlID, DeletedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  void UpdateModuleDefinitions(int ModuleDefID, string FriendlyName, int DefaultCacheTime, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                objProvider.UpdateModuleDefinitions(ModuleDefID, FriendlyName, DefaultCacheTime, IsActive, IsModified, UpdatedOn, PortalID, UpdatedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  ModuleInfo GetModuleInformationByModuleID(int ModuleID)
        {
            try
            {
                ModuleProvider objProvider = new ModuleProvider();
                return objProvider.GetModuleInformationByModuleID(ModuleID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
