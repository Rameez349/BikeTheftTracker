using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Extensions
{
    public static class ObjectToQuerystringMapper
    {
        public static string MapObjectToQueryString<T>(this T dataObject)
        {
            var properties = from p in dataObject.GetType().GetProperties()
                             where p.GetValue(dataObject, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(dataObject, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}
