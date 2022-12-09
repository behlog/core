using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core;
using Microsoft.Extensions.Configuration;
using Behlog.Core.Models;

namespace Microsoft.Extensions.DependencyInjection
{

    public static class BehlogServiceProvider
    {

        /// <summary>
        /// Adds Behlog Core Services
        /// this must call before the other services.
        /// </summary>
        /// <param name="services"></param>.
        /// <returns></returns>
        public static IServiceCollection AddBehlogCore(
            this IServiceCollection services, IConfiguration configuration) {
            
            services.AddHttpContextAccessor();
            services.AddScoped<IBehlogApplicationContext, BehlogApplicationContext>();
            services.AddScoped<ISystemDateTime, SystemDateTime>();
            services.AddScoped<IBehlogMediatorAssistant, BehlogMediatorAssistant>();
            var options = configuration.Get<BehlogOptions>();
            services.AddSingleton<BehlogOptions>(options);
            services.AddBehlogCQRS();
            
            return services;
        }
    }
}
