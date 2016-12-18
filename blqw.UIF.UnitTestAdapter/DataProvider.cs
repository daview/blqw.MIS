﻿using blqw.UIF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blqw.SIF.Session;
using blqw.UIF.Descriptor;
using blqw.UIF.NetFramework45;

namespace blqw.UIF
{
    class DataProvider : IApiDataProvider
    {
        static string SessionId = Guid.NewGuid().ToString("n");

        ParseResult _result;
        public DataProvider(ParseResult result)
        {
            _result = result ?? throw new ArgumentNullException(nameof(result));
        }
        public object GetApiInstance(ApiDescriptor api)
            => _result.Instance;

        public ApiData GetParameter(ApiParameterDescriptor parameter)
            => new ApiData(_result.Parameters[parameter.Parameter.Position]);

        public ApiData GetProperty(ApiPropertyDescriptor property)
            => _result.Properties.TryGetValue(property.Property, out var value) ? new ApiData(value) : ApiData.NotFound;

        public ISession GetSession()
            => new MemorySession(SessionId, 3600, () => SessionId = Guid.NewGuid().ToString("n"));
    }
}
