namespace Bog.Data.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using AutoMapper;

    using Bog.Data.Entities.Contracts;
    using Bog.Data.Repositories.Contracts;

    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="TData">
    /// </typeparam>
    /// <typeparam name="TModel">
    /// </typeparam>
    public class DataRepository<TData, TModel> : IRepository<TData, TModel>
        where TData : DataEntityBase where TModel : class
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{TData,TModel}"/> class. 
        /// Initializes a new instance of the <see cref="DataRepository{T}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public DataRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<TData>();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        protected DbContext Context { get; set; }

        /// <summary>
        ///     Gets or sets the data set.
        /// </summary>
        protected DbSet<TData> DbSet { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Add(TModel entity)
        {
            TData dataEntity = Mapper.Map<TModel, TData>(entity);

            DbEntityEntry entry = this.Context.Entry(dataEntity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(dataEntity);
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(TModel entity)
        {
            TData dataEntity = Mapper.Map<TModel, TData>(entity);

            this.Delete(dataEntity);
        }

        public void Delete(TData dataEntity)
        {
            DbEntityEntry entry = this.Context.Entry(dataEntity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(dataEntity);
                this.DbSet.Remove(dataEntity);
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            TModel entity = this.GetById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        /// <summary>
        /// The detach.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Detach(TModel entity)
        {
            TData dataEntity = Mapper.Map<TModel, TData>(entity);

            DbEntityEntry entry = this.Context.Entry(dataEntity);

            entry.State = EntityState.Detached;
        }

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IQueryable" />.
        /// </returns>
        public virtual IEnumerable<TModel> GetAll()
        {
            DbSet<TData> collection = this.DbSet;
            return Mapper.Map<IEnumerable<TData>, IEnumerable<TModel>>(collection);

            // return this.DbSet.Project().To<TModel>();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public TModel GetById(int id)
        {
            TData dataEntity = this.DbSet.Find(id);
            return Mapper.Map<TData, TModel>(dataEntity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(TModel entity)
        {
            TData dataEntity = Mapper.Map<TModel, TData>(entity);

            DbEntityEntry entry = this.Context.Entry(dataEntity);
            if (entry.State != EntityState.Detached)
            {
                this.DbSet.Attach(dataEntity);
            }

            entry.State = EntityState.Modified;
        }

        #endregion
    }
}