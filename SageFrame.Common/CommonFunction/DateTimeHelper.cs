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
using System.Web;

/// <summary>
/// Summary description for DateTimeHelper
/// </summary>
/// 
namespace SageFrame.Web
{
    public static class DateTimeHelper
    {

        /*
         * ===================================================================================================
                Specifier 	    DateTimeFormatInfo property 	        Pattern value (for en-US culture)
                t 	            ShortTimePattern 	                    h:mm tt
                d 	            ShortDatePattern 	                    M/d/yyyy
                T 	            LongTimePattern 	                    h:mm:ss tt
                D 	            LongDatePattern 	                    dddd, MMMM dd, yyyy
                f 	            (combination of D and t) 	            dddd, MMMM dd, yyyy h:mm tt
                F 	            FullDateTimePattern 	                dddd, MMMM dd, yyyy h:mm:ss tt
                g 	            (combination of d and t) 	            M/d/yyyy h:mm tt
                G 	            (combination of d and T) 	            M/d/yyyy h:mm:ss tt
                m, M 	        MonthDayPattern 	                    MMMM dd
                y, Y 	        YearMonthPattern 	                    MMMM, yyyy
                r, R 	        RFC1123Pattern 	                        ddd, dd MMM yyyy HH':'mm':'ss 'GMT' (*)
                s 	            SortableDateTi­mePattern 	            yyyy'-'MM'-'dd'T'HH':'mm':'ss (*)
                u 	            UniversalSorta­bleDateTimePat­tern 	    yyyy'-'MM'-'dd HH':'mm':'ss'Z' (*)
                Where (*) = culture independent
             *=================================================================================================
         */
        public static string cultureIndependentPattern = "u";//Pattern value (for en-US culture) "yyyy'-'MM'-'dd HH':'mm':'ss'Z'"
        public static string UniversalSortableDateTimePattern = "u"; //Pattern value (for en-US culture) "yyyy'-'MM'-'dd HH':'mm':'ss'Z'"
        public static string SortableDateTimePattern = "s"; //Pattern value (for en-US culture) "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
        public static string RFC1123Pattern = "R";//Pattern value (for en-US culture) "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'" // r, R

        public static string GetCultureIndependentDateTime(string dateortime, string outputformat)
        {
            string ret = "";
            if (dateortime == "")
                return "";
            try
            {
                ret = System.Convert.ToDateTime(dateortime).ToString(outputformat);
            }
            catch
            {
            }
            return ret;
        }

        public static string ConvertToShortDate(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime dt = DateTime.Parse(str);
                str = dt.ToShortDateString();
            }
            return str;
        }

        public static string ConvertToLongDate(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime dt = DateTime.Parse(str);
                str = dt.ToLongDateString();
            }
            return str;
        }
    }
}
