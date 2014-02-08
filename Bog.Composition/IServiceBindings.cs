namespace Bog.Composition
{
    using Ninject;

    /// <summary>
    ///     The ServiceBindings interface.
    /// </summary>
    public interface IServiceBindings
    {
        #region Public Methods and Operators

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        void RegisterServices(IKernel kernel);

        #endregion
    }
}