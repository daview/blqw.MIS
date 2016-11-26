﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace blqw.SIF.Descriptor
{
    /// <summary>
    /// 用于描述一个接口
    /// </summary>
    public sealed class ApiDescriptor
    {
        /// <summary>
        /// 初始化接口描述
        /// </summary>
        /// <param name="type"></param>
        /// <param name="method"></param>
        public ApiDescriptor(Type type, MethodInfo method)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (method == null) throw new ArgumentNullException(nameof(method));
            Type = type;
            Method = method;
            Parameters = new ReadOnlyCollection<ApiParameterDescriptor>(method.GetParameters().Select(it => new ApiParameterDescriptor(this, it)).ToList());
        }

        /// <summary>
        /// 接口方法
        /// </summary>
        public MethodInfo Method { get; }

        /// <summary>
        /// 接口类
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 参数描述集合
        /// </summary>
        public ICollection<ApiParameterDescriptor> Parameters { get; }

        /// <summary>
        /// 调用api方法,获取返回值
        /// </summary>
        /// <param name="api">接口对象</param>
        /// <param name="apiParameters">接口参数</param>
        /// <returns></returns>
        public object Invoke(object api, IDictionary<string, object> apiParameters)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (apiParameters == null) throw new ArgumentNullException(nameof(apiParameters));
            var args = new object[Parameters.Count];
            foreach (var p in Parameters)
            {
                object value;
                if (apiParameters.TryGetValue(p.Name, out value) == false)
                {
                    value = p.DefaultValue;
                }
                var ex = p.IsValid(value, apiParameters);
                if (ex != null)
                {
                    return ex;
                }
                args[p.Parameter.Position] = value;
            }
            return Method.Invoke(api, args);
        }
    }
}