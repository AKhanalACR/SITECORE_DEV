using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Foundation.IoC.Pipelines.InitializeContainer
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        IDependencyResolver _fallbackResolver;
        IDependencyResolver _newResolver;

        public CustomDependencyResolver(IDependencyResolver newResolver, IDependencyResolver fallbackResolver)
        {
            _newResolver = newResolver;
            _fallbackResolver = fallbackResolver;
        }

        public object GetService(Type serviceType)
        {
            object result = null;
            try
            {
                result = _newResolver.GetService(serviceType);
            }
            catch (ActivationException ex)
            {
                result = _fallbackResolver.GetService(serviceType);
            }

            return result;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType.Namespace.StartsWith("Sitecore."))
            {
                return _fallbackResolver.GetServices(serviceType);
            }

            IEnumerable<object> result = Enumerable.Empty<object>();
            result = _newResolver.GetServices(serviceType);

            if (result.Any())
            {
                return result;
            }
            return _fallbackResolver.GetServices(serviceType);
        }

    }
}