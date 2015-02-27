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

namespace SageFrame.ModuleMessage
{
    public class ModuleMessageController
    {
        public static List<ModuleMessageInfo> GetAllModules()
        {
            return (ModuleMessageDataProvider.GetAllModules());
        }
        public static void AddModuleMessage(ModuleMessageInfo objModuleMessage)
        {
            try
            {
                ModuleMessageDataProvider.AddModuleMessage(objModuleMessage);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static ModuleMessageInfo GetModuleMessage(int ModuleID, string Culture)
        {
            try
            {
                return (ModuleMessageDataProvider.GetModuleMessage(ModuleID, Culture));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static ModuleMessageInfo GetModuleMessageByUserModuleID(int UserModuleID, string Culture)
        {
            try
            {
                return (ModuleMessageDataProvider.GetModuleMessageByUserModuleID(UserModuleID, Culture));
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public static void UpdateMessageStatus(int ModuleID, bool IsActive)
        {
            try
            {
                ModuleMessageDataProvider.UpdateMessageStatus(ModuleID, IsActive);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
