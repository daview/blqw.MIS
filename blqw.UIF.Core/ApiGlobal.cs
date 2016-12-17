﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blqw.UIF.DataModification;
using blqw.UIF.Filters;
using blqw.UIF.Validation;

namespace blqw.UIF
{
    /// <summary>
    /// Api全局操作基类
    /// </summary>
    public abstract class ApiGlobal
    {
        public abstract void Initialization();

        public ICollection<ApiFilterAttribute> Filters { get; } = new List<ApiFilterAttribute>();

        public ICollection<DataValidationAttribute> Validations { get; } = new List<DataValidationAttribute>();

        public ICollection<DataModificationAttribute> Modifications { get; } = new List<DataModificationAttribute>();
    }
}