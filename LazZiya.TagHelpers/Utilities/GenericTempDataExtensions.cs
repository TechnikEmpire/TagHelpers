using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;


namespace LazZiya.TagHelpers.Utilities
{
    /// <summary>
    /// Generic extension to TempData for adding complex object and fix serialization problem
    /// </summary>
    /// <![CDATA[https://stackoverflow.com/a/35042391/5519026]]>
    public static class GenericTempDataExtensions
    {
        /// <summary>
        /// Add object to temp data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }

        /// <summary>
        /// Read object from temp data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);

            var obj = JsonSerializer.Deserialize<T>((string)o);
            return o == null ? null : obj;
        }
    }
}
