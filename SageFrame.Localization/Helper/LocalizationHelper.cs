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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

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
