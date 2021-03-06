﻿namespace Bog.Domain.Repositories
{
    using System.ComponentModel.Composition;

    using Bog.Composition;
    using Bog.Domain.Repositories.Contracts;

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
            kernel.Bind<IDonationRepository>().To<DonationRepository>().InRequestScope();
        }

        #endregion
    }
}