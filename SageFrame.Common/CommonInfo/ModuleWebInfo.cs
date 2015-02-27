#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Text;

#endregion

[Serializable]
public class ModuleWebInfo
{

    public int ModuleID { get; set; }
    public string ModuleName { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string Description { get; set; }
    public string Version { get; set; }
    public string DownloadUrl { get; set; }

}