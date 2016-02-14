using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handsey.Unity
{
    public class UnityIocContainer : IIocContainer
    {
        private readonly IUnityContainer _unityContainer;

        public UnityIocContainer(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public void Register(Type from, Type to)
        {
            _unityContainer.RegisterType(from, to);
        }

        public void Register(Type from, Type to, string name)
        {
            _unityContainer.RegisterType(from, to, name);
        }

        public TResolve[] ResolveAll<TResolve>()
        {
            return _unityContainer.ResolveAll<TResolve>().ToArray();
        }
    }
}