﻿using System;
using System.Collections.Generic;

namespace blqw.MIS.Services
{
    /// <summary>
    /// API设置解释器
    /// </summary>
    public interface IApiSettingParser : IService
    {
        /// <summary>
        /// 解析设置
        /// </summary>
        /// <param name="settings"> 待解析的字符串 </param>
        /// <returns></returns>
        ParseResult Parse(IEnumerable<string> settings);
    }

    /// <summary>
    /// 解析结果
    /// </summary>
    public struct ParseResult
    {
        /// <summary>
        /// 初始化结果
        /// </summary>
        /// <param name="value">解析得到的设置</param>
        public ParseResult(IDictionary<string, object> settings)
        {
            Settings = settings;
            Succeed = true;
            Error = null;
        }

        /// <summary>
        /// 初始化解析异常
        /// </summary>
        /// <param name="error">解析中的异常</param>
        public ParseResult(Exception error)
        {
            Settings = null;
            Succeed = false;
            Error = error;
        }
        /// <summary>
        /// 解析结果
        /// </summary>
        public IDictionary<string, object> Settings { get; }
        /// <summary>
        /// 是否解析成功
        /// </summary>
        public bool Succeed { get; }
        /// <summary>
        /// 解析中的异常信息
        /// </summary>
        public Exception Error { get; }
    }
}
