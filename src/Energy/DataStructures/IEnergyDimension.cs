namespace Energy.DataStructures
{
    /// <summary>
    /// Represent an attribute pertaining to a record in a system built for the Energy industry.
    /// </summary>
    public interface IEnergyDimension
    {
        /// <summary>
        /// The ID of the dimension.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The name of the dimension.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The standard code that represents the dimension.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the dimension as a title.
        /// </summary>
        string DisplayName { get; }
    }
}
