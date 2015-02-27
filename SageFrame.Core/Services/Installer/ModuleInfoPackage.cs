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
    public class ModuleInfoPackage : ModuleInfo
    {
        List<ModuleElement> _moduleElements = new List<ModuleElement>();
        List<string> _fileNames = new List<string>();


       public  List<ModuleElement> ModuleElements { get { return _moduleElements; }}
       public List<string> FileNames { get { return _fileNames; } }


    }

