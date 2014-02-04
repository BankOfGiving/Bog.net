namespace Bog.Domain.Entities.Contracts
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>
    ///     The entity base.
    /// </summary>
    public abstract class DomainEntityBase : IExtensibleDataObject, IDataErrorInfo
    {
        #region Fields

        /// <summary>
        ///     The _ validator.
        /// </summary>
        protected IValidator _Validator = null;

        /// <summary>
        ///     The _ validation errors.
        /// </summary>
        private IEnumerable<ValidationFailure> _ValidationErrors;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DomainEntityBase" /> class.
        /// </summary>
        protected DomainEntityBase()
        {
            this._Validator = this.GetValidator();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the extension data.
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>
        ///     Gets a value indicating whether is valid.
        /// </summary>
        public virtual bool IsValid
        {
            get
            {
                return this._ValidationErrors == null || !this._ValidationErrors.Any();
            }
        }

        /// <summary>
        ///     Gets the validation errors.
        /// </summary>
        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get
            {
                return this._ValidationErrors;
            }
        }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        ///     Gets the error.
        /// </summary>
        string IDataErrorInfo.Error
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion

        #region Explicit Interface Indexers

        /// <summary>
        /// The data error info.this.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                if (this._ValidationErrors != null && this._ValidationErrors.Any())
                {
                    foreach (ValidationFailure validationError in this._ValidationErrors)
                    {
                        if (validationError.PropertyName == columnName)
                        {
                            errors.AppendLine(validationError.ErrorMessage);
                        }
                    }
                }

                return errors.ToString();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The validate.
        /// </summary>
        public void Validate()
        {
            // If there is no defined validator, kick out of the method.
            if (this._Validator == null)
            {
                return;
            }

            ValidationResult results = this._Validator.Validate(this);
            this._ValidationErrors = results.Errors;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The get validator.
        /// </summary>
        /// <returns>
        ///     The <see cref="IValidator" />.
        /// </returns>
        protected virtual IValidator GetValidator()
        {
            return null;
        }

        #endregion
    }
}