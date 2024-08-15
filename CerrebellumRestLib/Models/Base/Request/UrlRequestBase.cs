using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Net;
using System.Reflection;

namespace CerebellumRestLib.Models.Base.Request
{
    public abstract class UrlRequestBase
    {
        public Dictionary<string, string> GetUrlParams()
        {
            var requestParams = new Dictionary<string, string>();

            foreach (var propertyInfo in GetType().GetProperties())
            {
                var descriptions = propertyInfo
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .OfType<DescriptionAttribute>()
                    .ToList();

                if (!descriptions.Any())
                    continue;

                var value = propertyInfo.GetValue(this, null);

                if (value == null)
                    continue;

                var valueString = string.Empty;
                if (value is Array array)
                {
                    foreach (var item in array)
                    {
                        if (item!=null && item is Enum enumValue)
                        {
                            valueString += GetEnumDescription(enumValue) +",";
                        }
                        else
                        {
                            valueString += item.ToString() + ",";
                        }
                    }
                    valueString = valueString.TrimEnd(',');
                }
                else
                {
                    valueString = value.GetType() == typeof(bool) ?
                                            value.ToString().ToLower() :
                                            value.ToString();
                }    

                if (!string.IsNullOrWhiteSpace(valueString))
                    requestParams.Add($"{descriptions.First().Description}", $"{WebUtility.UrlEncode(valueString)}");
            }

            return requestParams;
        }

        private string GetEnumDescription(Enum enumerationValue)
        {
            Type type = enumerationValue.GetType();

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
    }
}
