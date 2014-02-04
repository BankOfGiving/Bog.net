namespace Bog.Data.Repositories.EntityFramework
{
    using System.Data.Entity;

    using Bog.Data.Entities;

    /// <summary>
    /// The instance data repository.
    /// </summary>
    public class InstanceDataRepository : DataRepository<InstanceData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceDataRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public InstanceDataRepository(DbContext context)
            : base(context)
        {
        }
    }
}