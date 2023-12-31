﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.IoC;
using Core.Utilities.İnterceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception // data bozulduğu zaman çalışır ne zaman bozulur(data eklenirse silinirse güncellenirse)
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
