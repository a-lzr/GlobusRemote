using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Services
{
    public static class RegisterHelper
    {
        public static void RegisterScoped<T>(this IServiceCollection services)
        {
            RegisterScoped(services, typeof(T));
        }

        public static void RegisterScoped(this IServiceCollection services, Type type)
        {
            // https://habr.com/ru/company/otus/blog/539762/
            services.AddScoped(type, serviceProvider =>
            {
                var constructor = type.GetConstructors()
                    .OrderByDescending(x => x.GetParameters().Length)
                    .First();

                var parametorsValue = constructor.GetParameters()
                    .Select(p => serviceProvider.GetService(p.ParameterType))
                    .ToArray();

                return constructor.Invoke(parametorsValue);
            });
        }
    }
}
