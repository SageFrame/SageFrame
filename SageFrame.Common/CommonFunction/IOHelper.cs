#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
#endregion

namespace SageFrame.Common
{
    public class IOHelper
    {
        public static bool DeleteDirectory(string target_dir)
        {
            bool result = false;

            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);

            return result;
        }
        public static bool DeleteDirectoryFiles(string target_dir, string ext_todelete)
        {
            bool result = false;

            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);
            string[] ext_arr_todelete = ext_todelete.Split(','); 
            foreach (string file in files)
            {
                foreach (string deleteFile in ext_arr_todelete)
                {
                    if (deleteFile.Contains(Path.GetExtension(file)))
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }
                }
            }

            return result;
        }
    }
}
