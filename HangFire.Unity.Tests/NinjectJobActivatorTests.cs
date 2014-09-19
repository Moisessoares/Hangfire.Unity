namespace Hangfire.Unity.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// Unity job activator tests
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UnityJobActivatorTests
    {
        [TestInitialize]
        public void SetUp()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsAnExceptionWhenContainerIsNull()
        {
            var activator = new UnityJobActivator(null);
        }

        [TestMethod]
        public void ClassIsBasedOnJobActivator()
        {
            var activator = new UnityJobActivator(new UnityContainer());
            Assert.IsInstanceOfType(activator, typeof(JobActivator));
        }

        [TestMethod]
        public void ActivateJobCallsUnity()
        {
            var container = new UnityContainer();
            container.RegisterInstance(typeof(string), "called");
            var activator = new UnityJobActivator(container);
            var result = activator.ActivateJob(typeof(string));
            Assert.AreEqual("called", result);
        }

        [TestMethod]
        public void UseUnityActivatorPassesCorrectActivator()
        {
            var configuration = new Mock<IBootstrapperConfiguration>();
            var container = new Mock<IUnityContainer>();
            configuration.Object.UseUnityActivator(container.Object);
            configuration.Verify(x => x.UseActivator(It.IsAny<UnityJobActivator>()));
        }
    }
}
