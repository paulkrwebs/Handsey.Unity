using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handsey.Unity.Tests
{
    [TestFixture]
    public class UnityIocContainerTests
    {
        private UnityContainer _unityContainer;
        private UnityIocContainer _unityIocContainer;

        [SetUp]
        public void SetUp()
        {
            _unityContainer = new UnityContainer();
            _unityIocContainer = new UnityIocContainer(_unityContainer);
        }

        [Test]
        public void Register_TypeAndTypeAndString_TypeRegsiteredOnUnityContainerWithName()
        {
            _unityIocContainer.Register(typeof(IIocContainer), typeof(MockObject), "dave");

            // Can't mock the extension method so mocking the method the extension method calls (not ideal!)
            Assert.That(_unityContainer.Resolve<IIocContainer>("dave"), Is.TypeOf<MockObject>(), "object was not registered");
        }

        [Test]
        public void ResolveAll_NoParams_ResolveAllCalledOnUnityContainer()
        {
            _unityIocContainer.Register(typeof(IIocContainer), typeof(MockObject), "dave");
            _unityIocContainer.Register(typeof(IIocContainer), typeof(MockObject2), "dave2");

            // Can't mock the extension method so mocking the method the extension method calls (not ideal!)
            Assert.That(_unityIocContainer.ResolveAll<IIocContainer>().Count(), Is.EqualTo(2), "object was not registered");
        }

        private class MockObject : IIocContainer
        {
            public void Register(Type from, Type to)
            {
                throw new NotImplementedException();
            }

            public void Register(Type from, Type to, string name)
            {
                throw new NotImplementedException();
            }

            public TResolve[] ResolveAll<TResolve>()
            {
                throw new NotImplementedException();
            }
        }

        private class MockObject2 : IIocContainer
        {
            public void Register(Type from, Type to)
            {
                throw new NotImplementedException();
            }

            public void Register(Type from, Type to, string name)
            {
                throw new NotImplementedException();
            }

            public TResolve[] ResolveAll<TResolve>()
            {
                throw new NotImplementedException();
            }
        }
    }
}