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

namespace SageFrame.ModuleMessage
{
    public class ModuleMessageDataProvider
    {
        public static List<ModuleMessageInfo> GetAllModules()
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();              
                return SQLH.ExecuteAsList<ModuleMessageInfo>("[dbo].[usp_ModuleMessageGetModules]");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void AddModuleMessage(ModuleMessageInfo objModuleMessage)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID", objModuleMessage.ModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Message", objModuleMessage.Message));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Culture", objModuleMessage.Culture));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", objModuleMessage.IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageType", objModuleMessage.MessageType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageMode", objModuleMessage.MessageMode));
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessagePosition", objModuleMessage.MessagePosition));

                SQLH.ExecuteNonQuery("[dbo].[usp_ModuleMessageAdd]",ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static ModuleMessageInfo GetModuleMessage(int ModuleID,string Culture)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID", ModuleID));             
                ParamCollInput.Add(new KeyValuePair<string, object>("@Culture", Culture));

                return SQLH.ExecuteAsObject<ModuleMessageInfo>("[dbo].[usp_ModuleMessageGet]", ParamCollInput);
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
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Culture", Culture));

                return SQLH.ExecuteAsObject<ModuleMessageInfo>("[dbo].[usp_ModuleMessageGetByUserModuleID]", ParamCollInput);
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
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID",ModuleID));               
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive",IsActive));

                SQLH.ExecuteNonQuery("[dbo].[usp_ModuleMessageUpdateStatus]", ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
