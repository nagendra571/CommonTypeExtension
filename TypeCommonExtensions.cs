﻿namespace Pcctg.CRD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class TypeCommonExtensions
    {
        public static bool IsNumeric(this string str)
        {
            double retValue;
            return double.TryParse(str, out retValue);
        }

        public static bool IsNumeric(this object str)
        {
            double retValue;
            return double.TryParse(str.ToString(), out retValue);
        }

        public static string DefaultText(this string str, string text)
        {
            return str.Trim() == "" ? text : str;
        }

        public static char ToChar(this string str)
        {
            char retValue;
            char.TryParse(str, out retValue);
            return retValue;
        }

        public static string ToStringOrNull(this object val, bool returnNullIfEmpty = false)
        {
            if (val == DBNull.Value || val == null)
                return null;

            if (returnNullIfEmpty && val.ToString() == string.Empty) return null;

            return val.ToString();
        }

        public static char ToChar(this object str)
        {
            if (str == DBNull.Value)
            {
                return ' ';
            }
            else
            {
                char retValue;
                char.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static DateTime? ToDateOrNull(this object date)
        {
            return date.ToDateTime() == DateTime.MinValue ? null : (DateTime?)date;
        }

        public static DateTime ToDateOrMin(this object date)
        {
            if (date == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return date.ToDateTime() == DateTime.MinValue ? DateTime.MinValue : (DateTime)date;
            }
        }

        public static int ToInt(this string str)
        {
            int retValue;
            int.TryParse(str, out retValue);
            return retValue;
        }

        public static byte ToByte(this string str)
        {
            byte retValue;
            byte.TryParse(str, out retValue);
            return retValue;
        }

        public static int ToInt(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                int retValue;
                int.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static Int16 ToInt16(this string str)
        {
            Int16 retValue;
            Int16.TryParse(str, out retValue);
            return retValue;
        }

        public static Int16 ToInt16(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                Int16 retValue;
                Int16.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static byte ToByte(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                byte retValue;
                byte.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static DateTime ToDateTime(this string str)
        {
            DateTime retValue;
            DateTime.TryParse(str, out retValue);
            return retValue;
        }

        public static DateTime ToDateTime(this object str)
        {
            if (str == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                DateTime retValue;
                DateTime.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }


        public static string ToDayToWord(this object str)
        {
            string DayinWord = string.Empty;
            if (str == DBNull.Value)
            {
                return DayinWord;
            }
            else
            {
                int Day = str.ToInt();
                switch (Day)
                {
                    case 1: DayinWord = "First";
                        break;
                    case 2: DayinWord = "Second";
                        break;
                    case 3: DayinWord = "Third";
                        break;
                    case 4: DayinWord = "Fourth";
                        break;
                    case 5: DayinWord = "Fifth";
                        break;
                    case 6: DayinWord = "Sixth";
                        break;
                    case 7: DayinWord = "Seventh";
                        break;
                    case 8: DayinWord = "Eighth";
                        break;
                    case 9: DayinWord = "Ninth";
                        break;
                    case 10: DayinWord = "Tenth";
                        break;
                    case 11: DayinWord = "Eleventh";
                        break;
                    case 12: DayinWord = "Twelfth ";
                        break;
                    case 13: DayinWord = "Thirteenth";
                        break;
                    case 14: DayinWord = "Fourteenth";
                        break;
                    case 15: DayinWord = "Fifteenth";
                        break;
                    case 16: DayinWord = "Sixteenth";
                        break;
                    case 17: DayinWord = "Seventeenth";
                        break;
                    case 18: DayinWord = "Eighteenth";
                        break;
                    case 19: DayinWord = "Nineteenth";
                        break;
                    case 20: DayinWord = "Twentieth";
                        break;
                    case 21: DayinWord = "Twenty First";
                        break;
                    case 22: DayinWord = "Twenty Second";
                        break;
                    case 23: DayinWord = "Twenty Third";
                        break;
                    case 24: DayinWord = "Twenty Fourth";
                        break;
                    case 25: DayinWord = "Twenty Fifth";
                        break;
                    case 26: DayinWord = "Twenty Sixth";
                        break;
                    case 27: DayinWord = "Twenty Seventh";
                        break;
                    case 28: DayinWord = "Twenty Eighth";
                        break;
                    case 29: DayinWord = "Twenty Ninth";
                        break;
                    case 30: DayinWord = "Thirty";
                        break;
                    case 31: DayinWord = "Thirty First";
                        break;


                }
                return DayinWord;
            }
        }

        public static DateTime? NullOrToDateTime(this object str)
        {
            try
            {
                if (str == DBNull.Value || str == null)
                {
                    return null;
                }
                else
                {
                    DateTime retValue;
                    DateTime.TryParse(str.ToString(), out retValue);
                    if (retValue == DateTime.MinValue)
                    {
                        return null;
                    }
                    return retValue;
                }
            }
            catch (Exception e)
            {
                LoggerMgr.App.Error("Error in NullOrToDateTime" + e);
                return null;
            }
        }

        public static double ToDouble(this object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return 0.0;
            }
            else
            {
                double retValue;
                double.TryParse(obj.ToString(), out retValue);
                return retValue;
            }
        }

        public static float ToSingle(this object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return 0.0f;
            float retValue;
            float.TryParse(obj.ToString(), out retValue);
            return retValue;
        }

        public static decimal ToDecimal(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                decimal retValue;
                decimal.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static long ToLong(this object str)
        {
            if (str == DBNull.Value || str == null)
            {
                return 0;
            }
            else
            {
                long retValue;
                long.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static DateTime IsDateTime(this string str)
        {
            DateTime retValue;
            DateTime.TryParse(str, out retValue);
            return retValue;
        }

        public static bool IsEmpty(this string str)
        {
            return str.Trim() == string.Empty;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return str.Trim() == string.Empty || str == null;
        }

        public static object ToObject(this int? val)
        {
            if (val == null)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToObject(this int val)
        {
            if (val == 0)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToObject(this Int16 val)
        {
            if (val == 0)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToDbObject(this string val)
        {
            if (val == null)
                return DBNull.Value;
            else
                return val;
        }

        public static object ToDbObject(this object val)
        {
            if (val == null)
                return DBNull.Value;
            else
                return val;
        }

        //public static string ToStr(this object val, bool returnEmptyIfDBNull = false)
        public static string ToStr(this object val, bool returnEmptyIfDBNull = true)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return string.Empty;
            else
            {
                try
                {
                    return val.ToString().Trim();
                }
                catch (Exception e)
                {
                    LoggerMgr.Web.Error("Error occurred in ToStr " + e);
                    return val.ToString();
                }
            }
        }

        public static string TrimSpace(this object val)
        {
            return val.ToStr(true).Trim().Replace(" ", "").Replace('/', '_').Replace(':', '_');
        }

        public static string TrimSpaceAndColon(this object val)
        {
            return val.ToStr(true).Trim().Replace(" ", "").Replace('/', '_').Replace(':', '_');
        }

        public static string ToACHNoFormat(this object val, bool returnEmptyIfDBNull = false)
        {
            if (val == DBNull.Value)
            {
                return returnEmptyIfDBNull ? string.Empty : null;
            }
            if (val == null)
            {
                return string.Empty;
            }
            else
            {
                string value = val.ToString().Length > 4 ? val.ToString().Substring(val.ToString().Length - 4, 4) : val.ToString();
                return val.ToString() == "" ? "" : value.PadLeft(17, 'X');
            }
        }

        public static string ToAmount(this double val)
        {
            if (val >= 0)
            {
                return "$" + String.Format("{0:#,##0.00}", val);
            }
            else
            {
                return "-$" + String.Format("{0:#,##0.00}", (-val));
            }
        }

        public static string ToPositiveAmount(this double val)
        {
            if (val >= 0)
            {
                return "$" + String.Format("{0:#,##0.00}", val);
            }
            else
            {
                return "$" + String.Format("{0:#,##0.00}", (-val));
            }
        }

        public static string ToPhoneNumber(this object val, bool returnEmptyIfDBNull = false, string defaultValue = null)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return defaultValue.ToStr(true).Trim() != string.Empty ? defaultValue.ToStr(true).Trim() : "N/A";
            else if (val.ToDouble() == 0)
                return defaultValue.ToStr(true).Trim() != string.Empty ? defaultValue.ToStr(true).Trim() : "N/A";
            else
                return (val = String.Format("{0: 000-000-0000}", val.ToDouble())).ToString();
        }

        public static string ToPhoneNumberWithBraces(this object val, bool returnEmptyIfDBNull = false, string defaultValue = null)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return defaultValue.ToStr(true).Trim() != string.Empty ? defaultValue.ToStr(true).Trim() : "N/A";
            else if (val.ToDouble() == 0)
                return defaultValue.ToStr(true).Trim() != string.Empty ? defaultValue.ToStr(true).Trim() : "N/A";
            else
                return (val = String.Format("{0: (000) 000-0000}", val.ToDouble())).ToString();
        }

        public static string ToPhoneNumberWithNoSpl(this object val)
        {
            if (val == DBNull.Value)
                return "";
            if (val == null)
                return "";
            else
            {
                string nospl = val.ToStr(true).Trim();
                nospl = nospl.Replace("(", "");
                nospl = nospl.Replace(")", "");
                nospl = nospl.Replace("-", "");
                nospl = nospl.Replace(" ", "");
                return nospl;
            }

        }

        public static string ToTransactionNumber(this object val, bool returnEmptyIfDBNull = false)
        {
            if (val == DBNull.Value)
            {
                return returnEmptyIfDBNull ? string.Empty : null;
            }

            if (val == null)
            {
                return string.Empty;
            }
            else
            {
                if (val.ToString().Length > 14)
                {
                    string value = val.ToString().Substring(0, 14) + "-" + val.ToString().Substring(val.ToString().Length - 3, 3);
                    return value;
                }
                else
                {
                    return val.ToString();
                }
            }
        }

        /// <summary>
        /// To convert empty string to null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string EmptyToNull(this object val)
        {
            if (val == null)
                return null;
            else if (val.ToString() == string.Empty)
                return null;
            else
                return val.ToString();
        }

        /// <summary>
        /// To convert empty string to DBNull.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string EmptyToDBNull(this object val)
        {
            if (val == null)
                return "NULL";
            else if (val.ToString() == string.Empty)
                return "NULL";
            else
                return val.ToString();
        }

        /// <summary>
        /// To convert 0 to null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ZeroToNull(this object val)
        {
            if (val.ToString() == "0")
                return null;
            else
                return val.ToString();
        }

        public static bool ToBoolean(this object val)
        {
            if (val == DBNull.Value || val == null)
                return false;
            else if (val.ToString().ToLower() == "false" || val.ToString() == "0")
                return false;
            else
                return true;
        }

        public static char ToChar(this bool val)
        {
            if (val)

                //return '1';
                return 'Y';
            else

                //return '0';
                return 'N';
        }

        /// <summary>
        /// To split the given string with split value.
        /// Use of FlexSplit: If the given index exceeds the split array then it will return the empty value.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="splitValue"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string FlexSplit(object val, char splitValue, Int16 index)
        {
            if (val == null)
                return string.Empty;
            if (index <= val.ToString().Split(splitValue).Length - 1)
                return val.ToString().Split(splitValue)[index];
            else
                return string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="val"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string FlexSubString(this object val, Int16 startIndex, Int16 length)
        {
            if (val == null)
                return string.Empty;
            if (val.ToString().Length >= startIndex + length)
                return val.ToString().Substring(startIndex, length);
            else
                return string.Empty;
        }

        public static System.Collections.IDictionary ToDictionary(this object obj)
        {
            System.Collections.Generic.Dictionary<string, object> objDescr = new System.Collections.Generic.Dictionary<string, object>();

            foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(obj))
            {
                objDescr.Add(descriptor.Name, descriptor.GetValue(obj));
            }
            return objDescr;
        }

        public static DateTime GetWeekStartDate(this DateTime obj)
        {
            return obj.AddDays(-(int)obj.DayOfWeek);
        }

        public static DateTime GetWeekEndDate(this DateTime obj)
        {
            return obj.GetWeekStartDate().AddDays(6);
        }

        public static string ToQualifiedFileName(this string fileName)
        {
            Regex regex = new Regex(@"[:""\/*?<>|]+");
            string qualifiedFileName = regex.Replace(fileName, "");
            return qualifiedFileName;
        }

        // Not completed - Need to place business id length and date format in configuration
        public static string ToBusinessID(this object obj)
        {
            //return obj.ToStr().PadLeft(7, '0');
            return obj.ToStr();
        }

        public static string ToClientID(this object obj)
        {
            return obj.ToStr().PadLeft(9, '0');
        }

        public static string ToFilingNumber(this object obj)
        {
            return obj.ToStr().PadLeft(10, '0');
        }

        public static string ToBusinessFilingNumber(this object obj)
        {
            return obj.ToStr().PadLeft(6, '0');
        }

        public static string ToAppDate(this DateTime obj)
        {
            return string.Format("{0:MM/dd/yyyy}", obj);
        }
        public static string ToLapseDate(this object obj)
        {
            if (obj != null && obj != "")
            {
                if (obj.ToStr().Contains("9999"))
                {
                    obj = "N/A";
                }

                return obj.ToStr();
            }
            else return obj.ToStr();
        }
        public static string ToSqlstr(this string str)
        {
            if (str == null)
                return "NULL";
            else
                return str.Replace("'", "''");
        }

        public static T IfIsNullOrEmpty<T>(this object obj, T ifTrue)
        {
            return obj == null ? ifTrue : (obj.ToString() == "" ? ifTrue : (T)Convert.ChangeType(obj, typeof(T)));
        }

        public static string ToAgentID(this object obj)
        {
            return obj.ToStr().PadLeft(9, '0');
        }

        public static string AppendSharedPath(this String val)
        {
            if (val.ToStr().StartsWith("\\"))
            {
                return SharedPath + val.ToStr();
            }
            else
                return val;
        }

        private static string SharedPath { get; set; }

        static TypeCommonExtensions()
        {
            SharedPath = ConfigurationManager.AppSettings["FileLocation"].ToStr();
        }

        public static int? ToNullableInt(this object str)
        {
            if (str == DBNull.Value || str == null || str.ToInt() == 0)
            {
                return null;
            }
            else
            {
                int retValue;
                int.TryParse(str.ToString(), out retValue);
                return retValue;
            }
        }

        public static int GetEnumValue(this Enum enumObj)
        {
            return Convert.ChangeType(enumObj, enumObj.GetTypeCode()).ToInt();
        }

        //For UCC
        public static string UnMask(this object val, bool returnEmptyIfDBNull = false)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return string.Empty;
            else
                return val.ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "");
        }

        public static string MaskTIN(this object val, bool returnEmptyIfDBNull = false)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return string.Empty;
            else
                return val.ToString().Length == 9 ? val.ToString().Insert(2, "-") : val.ToString();
        }

        public static string MaskSSN(this object val, bool returnEmptyIfDBNull = false)
        {
            if (val == DBNull.Value)
                return returnEmptyIfDBNull ? string.Empty : null;
            if (val == null)
                return string.Empty;
            else
                return val.ToString().Length == 9 ? val.ToString().Insert(3, "-").Insert(6, "-") : val.ToString();
        }

        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }


        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                table.Rows.Add(values);
            }
            return table;
        }

        public static string UppercaseFirst(this object val)
        {
            char[] a = val.ToStr().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// Sort one collection based on keys defined in another
        /// </summary>
        /// <returns>Items sorted</returns>
        public static IEnumerable<TResult> SortBy<TResult, TKey>(
            this IEnumerable<TResult> itemsToSort,
            IEnumerable<TKey> sortKeys,
            Func<TResult, TKey> matchFunc)
        {
            return sortKeys.Join(itemsToSort,
                key => key,
                matchFunc,
                (key, iitem) => iitem);
        }
    }
}