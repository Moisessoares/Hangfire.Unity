namespace Hangfire
{
    using Microsoft.Practices.Unity;

    public static class UnityBootstrapperConfigurationExtensions
    {
        /// <summary>
        /// Tells <c>bootstrapper</c> to use the specified Unity
        /// container as a global job activator.
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="unityContainer">Unity container that will be used to activate jobs</param>
        public static void UseUnityActivator(this IBootstrapperConfiguration configuration, IUnityContainer unityContainer)
        {
            configuration.UseActivator(new UnityJobActivator(unityContainer));
        }
    }
}
