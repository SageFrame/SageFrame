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

namespace SageFrame.PortalSetting
{
    public class PortalController
    {
        public static List<PortalInfo> GetPortalList()
        {
            try
            {
                return PortalProvider.GetPortalList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static PortalInfo GetPortalByPortalID(int PortalID, string UserName)
        {
            try
            {
                return PortalProvider.GetPortalByPortalID(PortalID, UserName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void DeletePortal(int PortalID, string UserName)
        {
            try
            {
                PortalProvider.DeletePortal(PortalID, UserName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdatePortal(int PortalID, string PortalName, bool IsParent, string UserName)
        {
            try
            {
                PortalProvider.UpdatePortal(PortalID, PortalName, IsParent, UserName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<PortalInfo> GetPortalModulesByPortalID(int PortalID, string UserName)
        {
            try
            {
                return PortalProvider.GetPortalModulesByPortalID(PortalID, UserName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdatePortalModules(string ModuleIDs, string IsActives, int PortalID, string UpdatedBy)
        {
            try
            {
                PortalProvider.UpdatePortalModules(ModuleIDs, IsActives, PortalID, UpdatedBy);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
