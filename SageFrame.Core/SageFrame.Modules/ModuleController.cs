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

namespace SageFrame.Modules
{
    public class ModuleController
    {
        public static int[] AddModules(ModuleInfo objList, bool isAdmin, int PackageID, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                return ModuleProvider.AddModules(objList, isAdmin, PackageID, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static int AddPortalModules(int? PortalID, int? ModuleID, bool IsActive, DateTime AddedOn, string AddedBy)
        {
            try
            {
                return ModuleProvider.AddPortalModules(PortalID, ModuleID, IsActive, AddedOn, AddedBy);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static int GetPermissionByCodeAndKey(string PermissionCode, string PermissionKey)
        {
            try
            {
                return ModuleProvider.GetPermissionByCodeAndKey(PermissionCode, PermissionKey);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static int[] AddModulePermission(int? ModuleDefID, int? PermissionID, int? PortalID, int? PortalModuleID, bool AllowAccess, string Username, bool IsActive, DateTime AddedOn, string AddedBy)
        {
            try
            {
                return ModuleProvider.AddModulePermission(ModuleDefID, PermissionID, PortalID, PortalModuleID, AllowAccess, Username, IsActive, AddedOn, AddedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static int AddModuleCoontrols(int? ModuleDefID, string ControlKey, string ControlTitle, string ControlSrc, string IconFile, int ControlType, int DisplayOrder, string HelpUrl, bool SupportsPartialRendering, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                return ModuleProvider.AddModuleCoontrols( ModuleDefID,  ControlKey,  ControlTitle,  ControlSrc,  IconFile,  ControlType,  DisplayOrder,  HelpUrl,  SupportsPartialRendering,  IsActive,  AddedOn,  PortalID, AddedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdateExtension(ModuleInfo objInfo)
        {
            try
            {
                ModuleProvider.UpdateExtension(objInfo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void DeletePackagesByModuleID(int PortalID, int ModuleID)
        {
            try
            {
                ModuleProvider.DeletePackagesByModuleID(PortalID, ModuleID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<ModuleInfo> GetAllExistingModule()
        {
            try
            {
              return  ModuleProvider.GetAllExistingModule();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static ModuleEntities ModuleControlsGetByModuleControlID(int ModuleControlID)
        {
            try
            {
                return ModuleProvider.ModuleControlsGetByModuleControlID(ModuleControlID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdateModuleCoontrols(int ModuleControlID, string ControlKey, string ControlTitle, string ControlSrc, string IconFile, int ControlType, int DisplayOrder, string HelpUrl, bool SupportsPartialRendering, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                ModuleProvider.UpdateModuleCoontrols(ModuleControlID, ControlKey, ControlTitle, ControlSrc, IconFile, ControlType, DisplayOrder, HelpUrl, SupportsPartialRendering, IsActive, IsModified, UpdatedOn, PortalID, UpdatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static int CheckUnquieModuleControlsControlType(int ModuleControlID, int ModuleDefID, int ControlType, int PortalID, bool isEdit)
        {
            try
            {
                return ModuleProvider.CheckUnquieModuleControlsControlType(ModuleControlID, ModuleDefID, ControlType, PortalID, isEdit);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void ModuleControlsDeleteByModuleControlID(int ModuleControlID, string DeletedBy)
        {
            try
            {
                ModuleProvider.ModuleControlsDeleteByModuleControlID(ModuleControlID, DeletedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdateModuleDefinitions(int ModuleDefID, string FriendlyName, int DefaultCacheTime, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                 ModuleProvider.UpdateModuleDefinitions( ModuleDefID,  FriendlyName,  DefaultCacheTime, IsActive,IsModified,UpdatedOn,PortalID,UpdatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static ModuleInfo GetModuleInformationByModuleID(int ModuleID)
        {
            try
            {
                return ModuleProvider.GetModuleInformationByModuleID(ModuleID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
