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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Web.Hosting;
using RegisterModule;
using System.IO;
using System.Xml;
using SageFrame.Web;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.ComponentModel;
using System.Web.Compilation.XmlSerializer;
using SageFrame.Utilities;
public partial class Modules_Upgrade_SageframeUpgrade :  BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblErrorMsg.Text = "";
    }

    public void WriteToLog(string txt)
    {
        string path = HostingEnvironment.ApplicationPhysicalPath + "log.txt";

        object obj = new object();
        lock (obj)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(txt);
                sw.Dispose();

            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
         
        if (this.fuUpgrade.HasFile && this.fuUpgrade.FileName.ToLower().EndsWith(".zip"))
        {
            string fileName = this.fuUpgrade.FileName;

            string tempFolder = HostingEnvironment.ApplicationPhysicalPath + "Upload\\UploadedFiles";
            string savePath = tempFolder + "\\" + fileName;
            
            if (!Directory.Exists(tempFolder))
                    Directory.CreateDirectory(tempFolder);
            
            this.fuUpgrade.SaveAs(savePath);

            if (!IsValidVersion(savePath))
            {
                this.lblErrorMsg.Text = "Your site is already Upgraded with this Version!! Try Another version";
            }
            else
            {                
                Server.Transfer(ResolveUrl("~/Modules/Upgrade/upgrade.aspx?zip=" + fileName));
            }
        }
        else
        {
            this.lblErrorMsg.Text = "Please select Zip File";
        }
    }

    public static bool IsNewVersion(string configFilePath)
    {
            bool flag=false;
            XmlDocument doc = new XmlDocument();           
               
            doc.Load(configFilePath);

            XmlNode versionNode = doc.SelectSingleNode("/CONFIG/SAGEFRAME");
            string installerVersion = versionNode.Attributes["VERSION"].Value;
            string prevVersion = Config.GetSetting("SageFrameVersion");

            if (Convert.ToDecimal(installerVersion)>=Convert.ToDecimal(prevVersion))
            {
               flag=true;
            }

          return flag;
    }

    public static bool IsValidVersion(string filePath)
    {
        bool IsValid=false;
        string outputFolder = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"Modules\Upgrade\UploadedFiles");
        string extractPath = string.Empty;
        bool isConfigFileFound=ZipUtil.UnZipConfigFile(filePath, outputFolder, ref extractPath, "", true,"config.xml");

        if (isConfigFileFound)
        {
            IsValid = IsNewVersion(extractPath + @"\SystemFiles\config.xml");
        }
      
        return IsValid;
    }
   
    
    #region Script Loader

    public static void BackupDatabase(String databaseName, String destinationPath, SqlConnection connection)
    {
        Backup sqlBackup = new Backup();

        sqlBackup.Action = BackupActionType.Database;
        sqlBackup.BackupSetDescription = "ArchiveDataBase:" +
                                         DateTime.Now.ToShortDateString();
        sqlBackup.BackupSetName = "Archive";

        sqlBackup.Database = databaseName;

        BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);       

        ServerConnection serverConn = new ServerConnection(connection);
        Server sqlServer = new Server(serverConn);

      //Database db = sqlServer.Databases[databaseName];

        sqlBackup.Initialize = true;
        sqlBackup.Checksum = true;
        sqlBackup.ContinueAfterError = true;
        sqlBackup.Devices.Add(deviceItem);
        sqlBackup.Incremental = false;

        sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
        sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

        sqlBackup.FormatMedia = false;

        sqlBackup.SqlBackup(sqlServer);
    }

    public void RunSqlScript(string connectionString1, string actualpath, int Counter)
    {
        lock (this)
        {
            try
            {
                switch (Counter)
                {
                    case 0:
                        string[] ScriptFiles = System.IO.Directory.GetFiles(actualpath);
                        ArrayList arrColl = new ArrayList();
                        foreach (string scriptFile in ScriptFiles)
                        {
                            arrColl.Add(scriptFile);
                        }
                        Session["_SageScriptFile"] = arrColl;
                        break;
                    default:
                        ArrayList arrC = (ArrayList)Session["_SageScriptFile"];
                        string strFile = arrC[0].ToString();
                        RunGivenSQLScript(strFile, connectionString1);

                        if (arrC.Count != 0)
                        {
                            arrC.RemoveAt(0);
                        }
                        Session["_SageScriptFile"] = arrC;
                        break;
                }

            }
            catch (Exception ex)
            {
                string sss = ex.Message;
            }
        }
    }

    private void RunGivenSQLScript(string scriptFile, string conn)
    {
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.Text;
        StreamReader reader = null;
        reader = new StreamReader(scriptFile);
        string script = reader.ReadToEnd();
        try
        {
            ExecuteLongSql(sqlcon, script);

        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            reader.Close();
            sqlcon.Close();
        }

    }

    public void ExecuteLongSql(SqlConnection connection, string Script)
    {
        string sql = "";
        sql = Script;
        Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        string[] lines = regex.Split(sql);
        SqlTransaction transaction = connection.BeginTransaction();
        using (SqlCommand cmd = connection.CreateCommand())
        {
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            foreach (string line in lines)
            {

                if (line.Length > 0)
                {
                    cmd.CommandText = line;
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        transaction.Commit();
    }

    #endregion
}
