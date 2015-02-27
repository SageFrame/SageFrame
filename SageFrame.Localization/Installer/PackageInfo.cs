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

[Serializable]
public class PackageInfo
{
    #region Properties
    public string PackageName { get; set; }
    public string PackageType { get; set; }
    public string FriendlyName { get; set; }
    public string Description { get; set; }
    public string ManifestFile { get; set; }
    public string Version { get; set; }
    public string OwnerName { get; set; }
    public string Organistaion { get; set; }
    public string URL { get; set; }
    public string Email { get; set; }
    private string _ReleaseNotes;
    public string ReleaseNotes { get { return (_ReleaseNotes); } set { _ReleaseNotes = value; } }
    private string _License;
    public string License { get { return (_License); } set { _License = value; } }
    private string _TempFolderPath;
    public string TempFolderPath { get { return (_TempFolderPath); } set { _TempFolderPath = value; } }
    private string _InstalledFolderPath;
    public string InstalledFolderPath { get { return (_InstalledFolderPath); } set { _InstalledFolderPath = value; } }
    public string FolderName { get; set; }
    #endregion
    public PackageInfo() { }

}

