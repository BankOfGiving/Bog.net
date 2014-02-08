namespace Bog.Web.Api
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Bog.Composition;

    /// <summary>
    ///     The register mapping definitions.
    /// </summary>
    public class EntityMapping : Profile
    {
        #region Public Properties

        /// <summary>
        ///     Gets the profile name.
        /// </summary>
        public override string ProfileName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The configure.
        /// </summary>
        protected override void Configure()
        {
            var container = DependencyResolver.Current.GetService<BogCompositionContainer>();

            IEnumerable<IEntityMapping> externalMappings = container.GetExportedValues<IEntityMapping>();

            foreach (IEntityMapping externalBinding in externalMappings)
            {
                externalBinding.CreateMap(this);
            }
        }

        #endregion
    }
}