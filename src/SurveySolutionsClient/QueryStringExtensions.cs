using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveySolutionsClient
{
    // https://stackoverflow.com/a/6848707/72174
    internal static class ExtensionMethods
    {
        public static string GetQueryString(this object obj)
        {
            return String.Join("&", GetProperties(obj));
        }

        private static IEnumerable<string> GetProperties(object obj)
        {
            foreach (var p in obj.GetType().GetProperties())
            {
                var pValue = p.GetValue(obj, null);
                if (pValue != null)
                {
                    var array = pValue as int[];

                    if (array != null)
                    {
                        foreach (var i in array)
                        {
                            yield return p.Name + "=" + i;
                        }
                    }
                    else
                    {
                        yield return  p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
                    }
                }

            }
        }
    }
}