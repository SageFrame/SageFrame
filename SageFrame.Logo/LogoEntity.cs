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

namespace SageFrame.Logo
{
   public class LogoEntity
    {
       public LogoEntity()
       {
       }
       private string _logoText;
       private string _logoPath;

       public string LogoText
       {
           get { return this._logoText; }
           set { this._logoText = value; }
       }
       public string LogoPath
       {
           get { return this._logoPath; }
           set { this._logoPath = value; }
       }
       public string Slogan { get; set; }
       public string url { get; set; }
    }
}
