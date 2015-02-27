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
using System.IO;
using System.Text.RegularExpressions;
#endregion

namespace SageFrame.Localization
{
    public class LocalizationHelper
    {
        /// <summary>
        /// Replace the backslash
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ReplaceBackSlash(string filepath)
        {
            if (filepath != null)
            {
                filepath = filepath.Replace("\\", "/");
            }
            return filepath;
        }

        public static string GetDefaultFileName(string filepath)
        {
            string fileName = Path.GetFileName(filepath);
            string ext = Path.GetExtension(filepath);
            string defaultFileName = Regex.IsMatch(fileName, @".[a-z]{2}-[A-Z]{2}" + ext + "|" + ext + "|." + @"[a-z]{2}-[A-Z]{1}[a-z]{3}-[A-Z]{2}" + ext) ? Regex.Replace(fileName, @".[a-z]{2}-[A-Z]{2}" + ext + "|" + ext + "|." + @"[a-z]{2}-[A-Z]{1}[a-z]{3}-[A-Z]{2}" + ext, "") + ext : fileName;
            return defaultFileName;

        }
        public static string GetDefaultFilePath(string filepath)
        {
            string fileName = Path.GetFileName(filepath);
            filepath = filepath.Replace(fileName, "");
            string ext = Path.GetExtension(filepath);
            string defaultFileName = Regex.IsMatch(fileName, @".[a-z]{2}-[A-Z]{2}" + ext + "|" + ext + "|." + @"[a-z]{2}-[A-Z]{1}[a-z]{3}-[A-Z]{2}" + ext) ? Regex.Replace(fileName, @".[a-z]{2}-[A-Z]{2}" + ext + "|" + ext + "|." + @"[a-z]{2}-[A-Z]{1}[a-z]{3}-[A-Z]{2}" + ext, "") + ext : fileName;
            return Path.Combine(filepath, defaultFileName);

        }
        public static bool IsDefaultFile(string filepath)
        {
            bool status = false;
            string fileName = Path.GetFileName(filepath);
            string newfilepath = filepath.Replace(fileName, "");
            string ext = Path.GetExtension(filepath);
            string defaultFileName = Regex.IsMatch(fileName, @".[a-z]{2}-[A-Z]{2}" + ext + "|" + ext + "|." + @"[a-z]{2}-[A-Z]{1}[a-z]{3}-[A-Z]{2}" + ext) ? Regex.Replace(fileName, @".[a-z]{2}-[A-Z]{2}" + ext + "|" + ext + "|." + @"[a-z]{2}-[A-Z]{1}[a-z]{3}-[A-Z]{2}" + ext, "") + ext : fileName;
            if(filepath==Path.Combine(newfilepath, defaultFileName))
            {
                status = true;
            }
            return status;
        }
    }
}
