namespace Bog.Domain.Entities
{
    using System.Collections.Generic;

    using Bog.Domain.Entities.Contracts;
    using Bog.Internationalization;

    using FluentValidation;

    /// <summary>
    ///     The donation.
    /// </summary>
    public class Donation : DomainEntityBase, IAccountOwnedEntity, IIdentifiableEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the donation id.
        /// </summary>
        public int DonationId { get; set; }

        /// <summary>
        ///     Gets or sets the entity id.
        /// </summary>
        public int EntityId
        {
            get
            {
                return this.DonationId;
            }

            set
            {
                this.DonationId = value;
            }
        }

        /// <summary>
        ///     Gets or sets the instances.
        /// </summary>
        public List<Instance> Instances { get; set; }

        /// <summary>
        ///     Gets or sets the owner account id.
        /// </summary>
        public int OwnerAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     The get validator.
        /// </summary>
        /// <returns>
        ///     The <see cref="IValidator" />.
        /// </returns>
        protected override IValidator GetValidator()
        {
            return new DonationValidator();
        }

        #endregion

        /// <summary>
        ///     The donation validator.
        /// </summary>
        private class DonationValidator : AbstractValidator<Donation>
        {
            #region Constructors and Destructors

            /// <summary>
            ///     Initializes a new instance of the <see cref="DonationValidator" /> class.
            /// </summary>
            public DonationValidator()
            {
                this.RuleFor(obj => obj.Title)
                    .NotEmpty()
                    .WithLocalizedMessage(() => Exceptions.DonationExceptions.RequiredTitle);
                this.RuleFor(obj => obj.Instances)
                    .NotEmpty()
                    .WithLocalizedMessage(() => Exceptions.DonationExceptions.RequiredInstance);
            }

            #endregion
        }
    }
}