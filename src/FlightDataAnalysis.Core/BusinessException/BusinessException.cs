namespace FlightDataAnalysis.Core.BusinessException
{
    /// <summary>
    /// The business validation exception message.
    /// </summary>
    public abstract class BusinessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        protected BusinessException(string message)
            : base(message)
        {
        }
    }
}
