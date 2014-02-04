namespace Bog.Enumerations
{
    /// <summary>
    /// The instance range.
    /// </summary>
    public enum InstanceRange
    {
        /// <summary>
        /// The next available instance by date.
        /// </summary>
        Next,

        /// <summary>
        /// Pull all instances that have a start date greater than today.
        /// </summary>
        Future,

        /// <summary>
        /// Pull all instances that have a start date greater than yesterday.
        /// </summary>
        FutureIncludingToday,

        /// <summary>
        /// Pull all instances regardless of start date.
        /// </summary>
        All,

        /// <summary>
        /// Return no instances.
        /// </summary>
        None,
    }
}
