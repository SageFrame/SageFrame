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
using System.Web;

namespace SageFrame.Web
{
    public static class SystemSetting
    {
        public static string glbDefaultPane = "ContentPane";
        public static string glbImageFileTypes = "jpg,jpeg,jpe,gif,bmp,png,swf";
        public static string SageFrameDBName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"].ToString();
        public static string SageFrameConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SageFrameConnectionString"].ToString();
        //providerName="System.Data.SqlClient"
        //public static string SageFrameProviderName = System.Configuration.ConfigurationManager.GetSection("providerName").ToString();
        public static string Register = "Register";
        public static string Login = "Login";
        public static string Logout = "Logout";
        public static string Administration = "Administration";
        public static string AnonymousUsername = "anonymous user";
        public static string REGISTER_USER_ROLENAME = "Registered User";
        public static string ANONYMOUS_ROLEID = string.Empty;
        public static string DataBaseOwner = GetDataBaseOwner();
        public static string ObjectQualifer = GetObjectQualifer();
        public static string[] SYSTEM_ROLES = { "registered user", "anonymous user", "site admin", "super user" };
        public static string[] SYSTEM_USERS = { "anonymoususer", "siteadmin", "Admin" };
        public static string[] SYSTEM_SUPER_ROLES = { "site admin", "super user" };
        public static string[] SUPER_ROLE = {"super user" };
        public static string  SITEADMIN = "site admin";
        public static string[] SYSTEM_APPLICATION_ROLES = { "super user" };
        public static string[] SYSTEM_USER_NOTALLOW_HTMLCOMMENT = { "anonymoususer" };
        public static string[] SYSTEM_ROLES_ALLOW_HTMLCOMMENT = { "registered user", "site admin", "super user" };
        public static int[] SYSTEM_MESSAGE_TEMPLATES = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
        public static Int32 ACCOUNT_ACTIVATION_EMAIL = 1;
        public static Int32 PASSWORD_CHANGE_REQUEST_EMAIL = 2;
        public static Int32 ACTIVATION_SUCCESSFUL_EMAIL = 3;
        public static Int32 PASSWORD_RECOVERED_SUCCESSFUL_EMAIL = 4;
        public static Int32 USER_REGISTRATION_HELP = 5;
        public static Int32 USER_RESISTER_SUCESSFUL_INFORMATION_NONE = 6;
        public static Int32 USER_RESISTER_SUCESSFUL_INFORMATION_PRIVATE = 7;
        public static Int32 USER_RESISTER_SUCESSFUL_INFORMATION_VERIFIED = 8;
        public static Int32 USER_RESISTER_SUCESSFUL_INFORMATION_PUBLIC = 9;
        public static Int32 ACTIVATION_SUCCESSFUL_INFORMATION = 10;
        public static Int32 ACTIVATION_FAIL_INFORMATION = 11;
        public static Int32 PASSWORD_FORGET_HELP = 12;
        public static Int32 PASSWORD_RECOVERED_SUCESSFUL_INFORMATION = 13;
        public static Int32 PASSWORD_RECOVERD_FAIL_INFORMATION = 14;
        public static Int32 PASSWORD_FORGET_USERNAME_PASSWORD_MATCH = 15;
        public static Int32 PASSWORD_RECOVERED_HELP = 16;
        public static Int32 ORDER_PLACED = 17;
        public static Int32 ORDER_STATUS_CHANGED = 18;
        public static Int32 SHARED_WISHED_LIST = 19;
        public static Int32 REFER_A_FRIEND_EMAIL = 20;
        public static string glbConfigFolder = "\\Config\\";
        public static string glbVersionConfigFolder = "\\Config\\VersionConfig\\";
        public static string glbConnStringConfigFolder = "\\Config\\ConnStringConfig\\";
        public static string[] INCOMPRESSIBLE_EXTENSIONS = { ".gif", ".jpg", ".png", ".axd", ".asmx", ".css", ".js", "Fconnector.aspx", ".html", ".htm", "connector.aspx?", "fckstyles.xml" };
        public static string[] ALLOWED_EXTENSIONS = { ".gif", ".jpg", ".png" };

        public static string GetDataBaseOwner()
        {
            string _databaseOwner = System.Configuration.ConfigurationManager.AppSettings["databaseOwner"].ToString();
            if (_databaseOwner != "" && _databaseOwner.EndsWith(".") == false)
            {
                _databaseOwner += ".";
            }
            return _databaseOwner;
        }

        public static string GetObjectQualifer()
        {
            string _objectQualifier = System.Configuration.ConfigurationManager.AppSettings["objectQualifier"].ToString();
            if ((_objectQualifier != "") && (_objectQualifier.EndsWith("_") == false))
            {
                _objectQualifier += "_";
            }
            return _objectQualifier;
        }        
    }
}
