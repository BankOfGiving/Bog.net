namespace Bog.Logging
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The logger.
    /// </summary>
    public static class Logger
    {
        #region Public Methods and Operators

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <param name="AdditionalInformation">
        /// The additional information.
        /// </param>
        public static void LogException(Exception ex, string AdditionalInformation = "")
        {
            // TODO:  Add logger
            Debug.Write(ex);
        }

        #endregion
    }
}