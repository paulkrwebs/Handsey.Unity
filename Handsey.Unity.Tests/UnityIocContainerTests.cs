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
        private Mock<IUnityContainer> _unityContainer;
        private UnityIocContainer _unityIocContainer;

        [SetUp]
        public void SetUp()
        {
            _unityContainer = new Mock<IUnityContainer>();
            _unityIocContainer = new UnityIocContainer(_unityContainer.Object);
        }

        [Test]
        public void Register_TypeAndType_TypeRegsiteredOnUnityContainer()
        {
            _unityIocContainer.Register(typeof(int), typeof(string));
            // Can't mock the extension method so mocking the method the extension method calls (not ideal!)
            _unityContainer.Verify(u => u.RegisterType(typeof(int), typeof(string), It.IsAny<string>(), It.IsAny<LifetimeManager>()), Times.Once(), "Regsiter was not called on the unity container");
        }

        [Test]
        public void Register_TypeAndTypeAndString_TypeRegsiteredOnUnityContainerWithName()
        {
            _unityIocContainer.Register(typeof(int), typeof(string), "dave");
            // Can't mock the extension method so mocking the method the extension method calls (not ideal!)
            _unityContainer.Verify(u => u.RegisterType(typeof(int), typeof(string), It.Is<string>(x => x == "dave"), It.IsAny<LifetimeManager>()), Times.Once(), "Regsiter was not called on the unity container");
        }

        [Test]
        public void ResolveAll_NoParams_ResolveAllCalledOnUnityContainer()
        {
            _unityIocContainer.ResolveAll<int>();
            // Can't mock the extension method so mocking the method the extension method calls (not ideal!)
            _unityContainer.Verify(u => u.ResolveAll(It.IsAny<Type>()), Times.Once(), "Resolve all was not called on the unity container");
        }
    }
}