using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace yrjw.CommonToolsCore.Helper
{
    /// <summary>
    /// JSON序列化和反序列化
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 将实体类序列化为JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        static public string SerializeJSON<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 反序列化JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        static public T DeserializeJSON<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
