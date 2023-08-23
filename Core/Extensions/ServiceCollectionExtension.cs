using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.IoC;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtension // class static olması lazım
    {

        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection); //core da dahil olmak üzere ekleyeceğimiz büütn injeksiyonları toplayacağımız yer
        }
        
    }
}

