using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core;

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
        public static IServiceCollection AddBehlogCore(this IServiceCollection services) {
            services.AddHttpContextAccessor();
            services.AddScoped<IBehlogApplicationContext, BehlogApplicationContext>();

            return services;
        }
    }
}
