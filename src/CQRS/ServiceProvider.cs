using System.Reflection;
using Behlog.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProvider
{
    
        public static IServiceCollection AddBehlogCQRS(this IServiceCollection services) {
            services.AddBehlogManager();
            services.AddBehlogMiddleware();
            return services;
        }

        /// <summary>
        /// Registers handlers and the mediator types from <see cref="AppDomain.CurrentDomain"/>.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddBehlogManager(this IServiceCollection services)
            => services.AddBehlogManager(AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic));

        /// <summary>
        /// Registers handlers and mediator types from the specified assemblies
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="assemblies">Assemblies to scan</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddBehlogManager(this IServiceCollection services, params Assembly[] assemblies)
            => services.AddBehlogManager(assemblies.AsEnumerable());

        /// <summary>
        /// Registers handlers and mediator types from the specified assemblies
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="assemblies">Assemblies to scan</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddBehlogManager(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            ReflectionUtilities.AddRequiredServices(services);

            ReflectionUtilities.AddBehlogClasses(services, assemblies);

            return services;
        }

        /// <summary>
        /// Registers handlers and mediator types from the assemblies that contain the specified types
        /// </summary>
        /// <param name="services"></param>
        /// <param name="handlerAssemblyMarkerTypes"></param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddBehlogManager(this IServiceCollection services, params Type[] handlerAssemblyMarkerTypes)
            => services.AddBehlogManager(handlerAssemblyMarkerTypes.AsEnumerable());

        /// <summary>
        /// Registers handlers and mediator types from the assemblies that contain the specified types
        /// </summary>
        /// <param name="services"></param>
        /// <param name="handlerAssemblyMarkerTypes"></param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddBehlogManager(this IServiceCollection services, IEnumerable<Type> handlerAssemblyMarkerTypes)
        {
            ReflectionUtilities.AddRequiredServices(services);
            ReflectionUtilities.AddBehlogClasses(services, handlerAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));
            return services;
        }

        public static IServiceCollection AddBehlogMiddleware(this IServiceCollection services) =>
            services.AddBehlogMiddleware(AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic));

        public static IServiceCollection AddBehlogMiddleware(this IServiceCollection services, params Assembly[] assemblies)
            => services.AddBehlogMiddleware(assemblies.AsEnumerable());

        public static IServiceCollection AddBehlogMiddleware(this IServiceCollection services,
            IEnumerable<Assembly> assembliesToScan)
        {
            return ReflectionUtilities.AddBehlogMiddleware(services, assembliesToScan);
        }
    
}