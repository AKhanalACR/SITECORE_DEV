using SimpleInjector.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ACRHelix.Foundation.IoC
{
    public class DefaultFirstConstructorBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type implementationType)
        {
            return GetConstructor(null, implementationType);
        }

        public ConstructorInfo GetConstructor(Type serviceType, Type implementationType)
        {
            var constructors = implementationType.GetConstructors();
            if (constructors.Any())
            {
                return (
                    from ctor in constructors
                    orderby ctor.GetParameters().Length ascending
                    select ctor)
                    .First();
            }

            return null;
        }
    }
}