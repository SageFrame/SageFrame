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

namespace SageFrame.UserProfile
{
    public class UserProfileDataProvider
    {

        public static void AddUpdateProfile(UserProfileInfo objProfile)
        {
            try
            {
                string sp = "[dbo].[Usp_AddUpdateUserProfile]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

                
                ParamCollInput.Add(new KeyValuePair<string, object>("@image", objProfile.Image));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", objProfile.UserName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FirstName", objProfile.FirstName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@LastName", objProfile.LastName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FullName", objProfile.FullName));

                ParamCollInput.Add(new KeyValuePair<string, object>("@Location", objProfile.Location));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AboutYou", objProfile.AboutYou));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Email", objProfile.Email));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ResPhone", objProfile.ResPhone));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Mobile", objProfile.MobilePhone));

                ParamCollInput.Add(new KeyValuePair<string, object>("@Others", objProfile.Others));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", objProfile.AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", objProfile.AddedBy));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedOn", objProfile.UpdatedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", objProfile.PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", objProfile.UpdatedBy));
                

                SQLH.ExecuteNonQuery(sp, ParamCollInput);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static UserProfileInfo  GetProfile(string UserName,int PortalID)
        {
            string sp = "[dbo].[usp_GetUserProfile]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            try
            {
                return (sagesql.ExecuteAsObject<UserProfileInfo>(sp, ParamCollInput));


            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteProfilePic(string UserName, int PortalID)
        {
            try
            {
                string sp = "[dbo].[usp_UserProfilePicDelete]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", UserName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLH.ExecuteNonQuery(sp, ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
