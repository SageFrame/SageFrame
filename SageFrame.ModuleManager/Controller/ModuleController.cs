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
using SageFrame.ModuleManager.DataProvider;

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
    }
}
