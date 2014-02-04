namespace Bog.Web.Api.Controllers
{
    using System.ComponentModel.Composition;

    using Bog.Composition;
    using Bog.Web.Api.Controllers.Contracts;

    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    /// IoC bindings.
    /// </summary>
    [Export(typeof(IServiceBindings))]
    public class ServiceBindings : IServiceBindings
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDonationController>().To<DonationController>().InRequestScope();
        }
    }
}