﻿using System;

namespace blqw.MIS
{
    /// <summary>
    /// 表示可以用于对外提供接口的方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ApiAttribute : Attribute, IApiAttribute
    {
        /// <summary>
        /// 初始化接口特性
        /// </summary>
        public ApiAttribute() { }

        /// <summary>
        /// 使用指定设置字符串初始化接口特性
        /// </summary>
        /// <param name="settingString">接口设置</param>
        public ApiAttribute(string settingString)
            => SettingString = settingString;

        /// <summary>
        /// 初始化针对特定容器的接口特性
        /// </summary>
        /// <param name="container">指定容器</param>
        /// <param name="settingString">接口设置</param>
        public ApiAttribute(string container, string settingString)
            : this(settingString)
            => Container = container;

        /// <summary>
        /// 容器ID
        /// </summary>
        public string Container { get; }

        /// <summary>
        /// 设置字符串
        /// </summary>
        public string SettingString { get; }
    }
}
