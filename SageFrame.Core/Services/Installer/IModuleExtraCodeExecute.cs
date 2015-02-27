using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SageFrame.Core.Services
{
   public interface IModuleExtraCodeExecute
    {
       void ExecuteOnInstallation(XmlDocument doc, string tempFolderPath);

       void ExecuteOnUnInstallation(XmlDocument doc);
    }   
}
