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
   public class CompositeModule
    {

    private Int32 _compositemoduleid;
    private string _name;
    private string _packagetype;
    private string _friendlyName;
    private string _description;
    private string _version;
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

    #region "Public Properties"


    public List<Component> Components { get; set; }
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

    public Int32 Compositemoduleid
    {
        get { return _compositemoduleid; }
        set { _compositemoduleid = value; }
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

    #endregion

    public CompositeModule()
    {
        Components = new List<Component>(); 
        //
        // TODO: Add constructor logic here
        //
    }
    }

