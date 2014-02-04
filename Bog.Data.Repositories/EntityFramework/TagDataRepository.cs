namespace Bog.Data.Repositories.EntityFramework
{
    using System.Data.Entity;
    using System.Linq;

    using Bog.Data.Entities;
    using Bog.Data.Repositories.Contracts;

    /// <summary>
    /// The instance data repository.
    /// </summary>
    public class TagDataRepository : DataRepository<TagData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagDataRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public TagDataRepository(DbContext context)
            : base(context)
        {
        }

        ///// <summary>
        ///// The get.
        ///// </summary>
        ///// <returns>
        ///// The <see cref="IQueryable"/>.
        ///// </returns>
        //public IQueryable<TagData> Get()
        //{
        //    return this.Data.TagDataSet;
        //}

        ///// <summary>
        ///// The get by name.
        ///// </summary>
        ///// <param name="namePart">
        ///// The tag search.
        ///// </param>
        ///// <returns>
        ///// The <see cref="IQueryable"/>.
        ///// </returns>
        //public IQueryable<TagData> GetByName(string namePart)
        //{
        //    return this.Data.TagDataSet.Where(t => t.Name.StartsWith(namePart));
        //}
    }
}