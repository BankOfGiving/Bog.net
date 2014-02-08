namespace Bog.Data.EntityFramework
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
            kernel.Bind<BogContext>().ToSelf().InRequestScope();
        }

        #endregion
    }
}