namespace Bog.Domain.Entities
{
    using System.Security.Principal;

    using Bog.Domain.Entities.Contracts;

    /// <summary>
    /// The account.
    /// </summary>
    public class Account : DomainEntityBase, IIdentifiableEntity, System.Security.Principal.IPrincipal
    {
        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        public int EntityId
        {
            get
            {
                return this.AccountId;
            }

            set
            {
                this.AccountId = value;
            }
        }

        /// <summary>
        /// Gets the owner account id.
        /// </summary>
        public int OwnerAccountId
        {
            get
            {
                return this.AccountId;
            }
        }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        public IIdentity Identity { get; private set; }
    }
}