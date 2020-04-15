using System;
using System.Collections.Generic;
using System.Text;

namespace yrjw.ORM.Chimp.Result
{
    /// <summary>
    /// 返回结果模型
    /// </summary>
    public class ResultModel<T> : IResultModel<T>
    {
        public bool Success { get; private set; }

        public string Msg { get; private set; }

        public int Code { get; private set; }

        public T Data { get; private set; }

        public ResultModel<T> ToSuccess(T data = default, string msg = "success")
        {
            Success = true;
            Msg = msg;
            Code = 0;
            Data = data;
            return this;
        }

        public ResultModel<T> ToFailed(string msg = "failed", int code = -1)
        {
            Success = false;
            Msg = msg;
            Code = code;
            return this;
        }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public static IResultModel Success<T>(T data = default(T))
        {
            return new ResultModel<T>().ToSuccess(data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static IResultModel Success()
        {
            return Success<string>();
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="error">错误信息</param>
        /// <param name="code">错误编码</param>
        /// <returns></returns>
        public static IResultModel Failed<T>(string error = null, int code = -1)
        {
            return new ResultModel<T>().ToFailed(error ?? "failed", code);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="error">错误信息</param>
        /// <param name="code">错误编码</param>
        /// <returns></returns>
        public static IResultModel Failed(string error = null, int code = -1)
        {
            return Failed<string>(error, code);
        }

        /// <summary>
        /// 根据布尔值返回结果
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public static IResultModel Result<T>(bool success)
        {
            return success ? Success<T>() : Failed<T>();
        }

        /// <summary>
        /// 根据布尔值返回结果
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public static IResultModel Result(bool success)
        {
            return success ? Success() : Failed();
        }

        /// <summary>
        /// 数据已存在
        /// </summary>
        /// <returns></returns>
        public static IResultModel HasExists => Failed("数据已存在");

        /// <summary>
        /// 数据不存在
        /// </summary>
        public static IResultModel NotExists => Failed("数据不存在");
    }
}
