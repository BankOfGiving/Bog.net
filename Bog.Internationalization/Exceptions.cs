namespace Bog.Internationalization
{
    /// <summary>
    ///     A localization engine is needed to provide proper localization.
    ///     For now this will be used to store keys.
    /// </summary>
    public static class Exceptions
    {
        /// <summary>
        ///     The donation exceptions.
        /// </summary>
        public static class DonationExceptions
        {
            #region Public Properties

            /// <summary>
            ///     Gets the null instance.
            /// </summary>
            public static string RequiredInstance
            {
                get
                {
                    return "At least one Instance is required.";
                }
            }

            /// <summary>
            ///     Gets the title empty.
            /// </summary>
            public static string RequiredTitle
            {
                get
                {
                    return "Donation Title cannot be empty.";
                }
            }

            #endregion
        }

        /// <summary>
        ///     The donation exceptions.
        /// </summary>
        public static class InstanceExceptions
        {
            #region Public Properties

            /// <summary>
            ///     Gets the null instance.
            /// </summary>
            public static string InvalidAddress
            {
                get
                {
                    return "At least one Instance is required.";
                }
            }

            #endregion
        }
    }
}