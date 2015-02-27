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
using System.Reflection;

namespace SageFrame.Web.Utils
{

   
    public class Null
    {

        // define application encoded null values 
        public static short NullShort
        {
            get { return -1; }
        }
        public static int NullInteger
        {
            get { return -1; }
        }
        public static float NullSingle
        {
            get { return float.MinValue; }
        }
        public static double NullDouble
        {
            get { return double.MinValue; }
        }
        public static decimal NullDecimal
        {
            get { return decimal.MinValue; }
        }
        public static System.DateTime NullDate
        {
            get { return System.DateTime.MinValue; }
        }
        public static string NullString
        {
            get { return ""; }
        }
        public static bool NullBoolean
        {
            get { return false; }
        }
        public static Guid NullGuid
        {
            get { return Guid.Empty; }
        }

        // sets a field to an application encoded null value ( used in BLL layer )
        public static object SetNull(object objValue, object objField)
        {
            object functionReturnValue = null;
            if (System.Convert.IsDBNull(objValue))
            {
                if (objField is short)
                {
                    functionReturnValue = NullShort;
                }
                else if (objField is int)
                {
                    functionReturnValue = NullInteger;
                }
                else if (objField is float)
                {
                    functionReturnValue = NullSingle;
                }
                else if (objField is double)
                {
                    functionReturnValue = NullDouble;
                }
                else if (objField is decimal)
                {
                    functionReturnValue = NullDecimal;
                }
                else if (objField is System.DateTime)
                {
                    functionReturnValue = NullDate;
                }
                else if (objField is string)
                {
                    functionReturnValue = NullString;
                }
                else if (objField is bool)
                {
                    functionReturnValue = NullBoolean;
                }
                else if (objField is Guid)
                {
                    functionReturnValue = NullGuid;
                }
                else
                {
                    // complex object
                    functionReturnValue = null;
                }
            }
            else
            {
                // return value
                functionReturnValue = objValue;
            }
            return functionReturnValue;
        }

        // sets a field to an application encoded null value ( used in BLL layer )
        public static object SetNull(PropertyInfo objPropertyInfo)
        {
            object functionReturnValue = null;
            switch (objPropertyInfo.PropertyType.ToString())
            {
                case "System.Int16":
                    functionReturnValue = NullShort;
                    break;
                case "System.Int32":
                case "System.Int64":
                    functionReturnValue = NullInteger;
                    break;
                case "System.Single":
                    functionReturnValue = NullSingle;
                    break;
                case "System.Double":
                    functionReturnValue = NullDouble;
                    break;
                case "System.Decimal":
                    functionReturnValue = NullDecimal;
                    break;
                case "System.DateTime":
                    functionReturnValue = NullDate;
                    break;
                case "System.String":
                case "System.Char":
                    functionReturnValue = NullString;
                    break;
                case "System.Boolean":
                    functionReturnValue = NullBoolean;
                    break;
                case "System.Guid":
                    functionReturnValue = NullGuid;
                    break;
                default:
                    // Enumerations default to the first entry
                    Type pType = objPropertyInfo.PropertyType;
                    if (pType.BaseType.Equals(typeof(System.Enum)))
                    {
                        System.Array objEnumValues = System.Enum.GetValues(pType);
                        Array.Sort(objEnumValues);
                        functionReturnValue = System.Enum.ToObject(pType, objEnumValues.GetValue(0));
                    }
                    else
                    {
                        // complex object
                        functionReturnValue = null;
                    }

                    break;
            }
            return functionReturnValue;
        }

        // convert an application encoded null value to a database null value ( used in DAL )
        public static object GetNull(object objField, object objDBNull)
        {
            object functionReturnValue = null;
            functionReturnValue = objField;
            if (objField == null)
            {
                functionReturnValue = objDBNull;
            }
            else if (objField is short)
            {
                if (Convert.ToInt16(objField) == NullShort)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is int)
            {
                if (Convert.ToInt32(objField) == NullInteger)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is float)
            {
                if (Convert.ToSingle(objField) == NullSingle)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is double)
            {
                if (Convert.ToDouble(objField) == NullDouble)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is decimal)
            {
                if (Convert.ToDecimal(objField) == NullDecimal)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is System.DateTime)
            {
                // compare the Date part of the DateTime with the DatePart of the NullDate ( this avoids subtle time differences )
                if (Convert.ToDateTime(objField).Date == NullDate.Date)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is string)
            {
                if (objField == null)
                {
                    functionReturnValue = objDBNull;
                }
                else
                {
                    if (objField.ToString() ==string.Empty )
                    {
                        functionReturnValue = objDBNull;
                    }
                }
            }
            else if (objField is bool)
            {
                if (Convert.ToBoolean(objField) == NullBoolean)
                {
                    functionReturnValue = objDBNull;
                }
            }
            else if (objField is Guid)
            {
                if (((System.Guid)objField).Equals(NullGuid))
                {
                    functionReturnValue = objDBNull;
                }
            }
            return functionReturnValue;
        }

        // checks if a field contains an application encoded null value
        public static bool IsNull(object objField)
        {
            bool functionReturnValue = false;
            if ((objField != null))
            {
                if (objField is int)
                {
                    functionReturnValue = objField.Equals(NullInteger);
                }
                else if (objField is float)
                {
                    functionReturnValue = objField.Equals(NullSingle);
                }
                else if (objField is double)
                {
                    functionReturnValue = objField.Equals(NullDouble);
                }
                else if (objField is decimal)
                {
                    functionReturnValue = objField.Equals(NullDecimal);
                }
                else if (objField is System.DateTime)
                {
                    DateTime objDate = (DateTime)objField;
                    functionReturnValue = objDate.Date.Equals(NullDate.Date);
                }
                else if (objField is string)
                {
                    functionReturnValue = objField.Equals(NullString);
                }
                else if (objField is bool)
                {
                    functionReturnValue = objField.Equals(NullBoolean);
                }
                else if (objField is Guid)
                {
                    functionReturnValue = objField.Equals(NullGuid);
                }
                else
                {
                    // complex object
                    functionReturnValue = false;
                }
            }
            else
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

    }
}

