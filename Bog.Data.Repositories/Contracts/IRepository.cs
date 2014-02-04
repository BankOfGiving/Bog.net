namespace Bog.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TData">Type of data entity.</typeparam>
    /// <typeparam name="TModel">Type of domain model.</typeparam>
    public interface IRepository<TData, TModel>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(TModel entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(TModel entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);

        /// <summary>
        /// The detach.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Detach(TModel entity);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        TModel GetById(int id);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(TModel entity);

        #endregion
    }
}