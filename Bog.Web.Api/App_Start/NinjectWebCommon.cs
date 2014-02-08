using Bog.Web.Api.App_Start;

using WebActivator;

[assembly: PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Bog.Web.Api.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;

    using Bog.Composition;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using WebApiContrib.IoC.Ninject;

    public static class NinjectWebCommon
    {
        #region Static Fields

        /// <summary>
        ///     The bootstrapper.
        /// </summary>
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<BogCompositionContainer>().ToSelf().InSingletonScope();

            BogCompositionContainer container = kernel.Get<BogCompositionContainer>();
            IEnumerable<IServiceBindings> externalBindings = container.GetExportedValues<IServiceBindings>();

            foreach (IServiceBindings externalBinding in externalBindings)
            {
                externalBinding.RegisterServices(kernel);
            }
        }

        #endregion
    }
}