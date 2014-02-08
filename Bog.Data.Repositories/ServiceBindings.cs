namespace Bog.Data.Repositories
{
    using System.ComponentModel.Composition;

    using Bog.Composition;

    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    ///     IoC bindings.
    /// </summary>
    [Export(typeof(IServiceBindings))]
    public class ServiceBindings : IServiceBindings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataWorker>().To<DataWorker>().InRequestScope();

            // kernel.Bind<DataRepository<DonationData>>().To<DonationDataRepository<Donation>>().InRequestScope();
            // kernel.Bind<DataRepository<InstanceData>>().To<InstanceDataRepository>().InRequestScope();
            // kernel.Bind<DataRepository<TagData>>().To<TagDataRepository>().InRequestScope();
        }

        #endregion
    }
}