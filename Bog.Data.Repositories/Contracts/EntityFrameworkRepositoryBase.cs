namespace Bog.Data.Repositories.Contracts
{
    using System;
    using System.Web.Mvc;

    using Bog.Data.EntityFramework;

    /// <summary>
    /// The data repository base.
    /// </summary>
    public class EntityFrameworkRepositoryBase : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkRepositoryBase"/> class.
        /// </summary>
        public EntityFrameworkRepositoryBase()
        {
            this.Data = DependencyResolver.Current.GetService<BogContext>();
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        protected BogContext Data { get; private set; }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Data.Dispose();
        }
    }
}
