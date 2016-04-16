using Benford.Controllers;
using Benford.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benford
{
    public class AwesomeDependencyResolver : IDependencyResolver
    {
        private Dictionary<Type, Type> map;

        public AwesomeDependencyResolver(Dictionary<Type, Type> map)
        {
            this.map = map;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.Assembly == System.Reflection.Assembly.GetExecutingAssembly())
            {
                if (serviceType.IsClass)
                {
                    var constructor = serviceType.GetConstructors().FirstOrDefault();
                    if (constructor != null)
                    {
                        var parameters = constructor.GetParameters().Select(p => this.GetService(p.ParameterType)).ToArray();
                        return constructor.Invoke(parameters);
                    }
                }
                if (serviceType.IsInterface)
                {
                    if (this.map.ContainsKey(serviceType))
                    {
                        return this.GetService(this.map[serviceType]);
                    }
                }
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new object[] { };
        }
    }
}