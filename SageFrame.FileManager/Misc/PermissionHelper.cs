using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SageFrame.Web.Utilities;
using System.Data.SqlClient;

namespace SageFrame.FileManager
{
    public class PermissionHelper
    {
        public static List<Roles> GetAllRoles(int portalID,bool isAll,string userName)
        {
            List<Roles> lstRoles = new List<Roles>();
            string StoredProcedureName = "sp_PortalRoleList";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAll", isAll));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", userName));

            SqlDataReader SQLReader;
            try
            {
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
                while (SQLReader.Read())
                {
                    Roles obj = new Roles();
                    obj.RoleID = new Guid(SQLReader["RoleID"].ToString());
                    obj.RoleName = SQLReader["RoleName"].ToString();
                    lstRoles.Add(obj);

                }
            }
            catch
            {
            }
            return lstRoles;
        }
    }
}
