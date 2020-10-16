using System.Collections.Generic;

namespace Energy.Services
{
    public interface IEnergyDimensionService
    {
        /// <summary>
        /// Gets all valid Account Classes
        /// </summary>
        /// <returns>A collection of all Account Classes</returns>
        IEnumerable<AccountClass> GetAllAccountClasses();

        /// <summary>
        /// Gets all valid Account Statuses
        /// </summary>
        /// <returns>A collection of all Account Statuses</returns>
        IEnumerable<AccountStatus> GetAllAccountStatuses();

        /// <summary>
        /// Gets all valid Commodities
        /// </summary>
        /// <returns>A collection of all Commodities</returns>
        IEnumerable<Commodity> GetAllCommodities();

        /// <summary>
        /// Gets all valid Plan Types
        /// </summary>
        /// <returns>A collection of all Plan Types</returns>
        IEnumerable<PlanType> GetAllPlanTypes();

        /// <summary>
        /// Gets all valid Rate Types
        /// </summary>
        /// <returns>A collection of all Rate Types</returns>
        IEnumerable<RateType> GetAllRateTypes();

        /// <summary>
        /// Gets all valid Unit of Measures
        /// </summary>
        /// <returns>A collection of all Unit of Measures</returns>
        IEnumerable<UnitOfMeasure> GetAllUnitOfMeasures();
    }
}
