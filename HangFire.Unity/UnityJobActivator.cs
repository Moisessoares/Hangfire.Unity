namespace Hangfire
{
    using System;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// HangFire Job Activator based on Unity IoC Container.
    /// </summary>
    public class UnityJobActivator : JobActivator
    {
        private readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityJobActivator"/>
        /// class with a given Unity Container.
        /// </summary>
        /// <param name="container">Container that will be used to create instance
        /// of classes during job activation process.</param>
        public UnityJobActivator(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException();
            }

            this.container = container;
        }

        /// <inheritdoc />
        public override object ActivateJob(Type jobType)
        {
            return this.container.Resolve(jobType);
        }
    }
}
