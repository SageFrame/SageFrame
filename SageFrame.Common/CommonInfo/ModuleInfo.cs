#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Web;

#endregion


/// <summary>
/// Summary description for ModuleInfo
/// </summary>
[Serializable]
public class ModuleInfo
{
    private Int32 _moduleid;
    private string _name;
    private string _packagetype;
    private string _friendlyName;
    private string _description;
    private string _version;
    private string _businesscontrollerclass;
    private string _foldername;
    private string _modulename;
    private string _compatibleversions;
    private string _ManifestFile = string.Empty;
    private string _tempFolderPath = string.Empty;
    private string _installedFolderPath = string.Empty;
    private string _owner = string.Empty;
    private string _organization = string.Empty;
    private string _url = string.Empty;
    private string _email = string.Empty;
    private string _releaseNotes = string.Empty;
    private string _license = string.Empty;
    public int ModuleDefID { get; set; }

    public bool IsPortable { get; set; }
    public bool IsSearchable { get; set; }
    public bool IsUpgradable { get; set; }
    public string PackageName { get; set; }
    public string PackageDescription { get; set; }
    public int PortalID { get; set; }
    public string Username { get; set; }

    public int ModuleDefPermissionID { get; set; }
    public int PortalModulePermissionID { get; set; }

    public List<ModuleInfo> ChildModules { get; set; }

    private bool _isPremium;
    private int _supportedFeatures;
    private string _dependencies = string.Empty;
    private string _permissions = string.Empty;



    public string dependencies
    {
        get { return _dependencies; }
        set { _dependencies = value; }
    }
    public string permissions
    {
        get { return _permissions; }
        set { _permissions = value; }
    }
    public int supportedFeatures
    {
        get { return _supportedFeatures; }
        set { _supportedFeatures = value; }
    }

    public bool isPremium
    {
        get { return _isPremium; }
        set { _isPremium = value; }
    }


    public string ManifestFile
    {
        get { return _ManifestFile; }
        set { _ManifestFile = value; }
    }

    public string TempFolderPath
    {
        get { return _tempFolderPath; }
        set { _tempFolderPath = value; }
    }

    public string InstalledFolderPath
    {
        get { return _installedFolderPath; }
        set { _installedFolderPath = value; }
    }

    public Int32 ModuleID
    {
        get { return _moduleid; }
        set { _moduleid = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string FriendlyName
    {
        get { return _friendlyName; }
        set { _friendlyName = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string Version
    {
        get { return _version; }
        set { _version = value; }
    }
    public string BusinessControllerClass
    {
        get { return _businesscontrollerclass; }
        set { _businesscontrollerclass = value; }
    }
    public string FolderName
    {
        get { return _foldername; }
        set { _foldername = value; }
    }
    public string ModuleName
    {
        get { return _modulename; }
        set { _modulename = value; }
    }
    public string CompatibleVersions
    {
        get { return _compatibleversions; }
        set { _compatibleversions = value; }
    }
    public string PackageType
    {
        get { return _packagetype; }
        set { _packagetype = value; }
    }
    public string Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }
    public string Organization
    {
        get { return _organization; }
        set { _organization = value; }
    }
    public string URL
    {
        get { return _url; }
        set { _url = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string ReleaseNotes
    {
        get { return _releaseNotes; }
        set { _releaseNotes = value; }
    }
    public string License
    {
        get { return _license; }
        set { _license = value; }
    }



    public ModuleInfo()
    {
        ChildModules = new List<ModuleInfo>();
        //
        // TODO: Add constructor logic here
        //
    }
}
