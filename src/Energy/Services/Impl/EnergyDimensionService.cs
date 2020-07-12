using Energy.DataStructures;
using System.Collections.Generic;

namespace Energy.Services.Impl
{
    public class EnergyDimensionService : IEnergyDimensionService
    {
        /// <summary>
        /// Gets all valid Account Classes
        /// </summary>
        /// <returns>A collection of all Account Classes</returns>
        public IEnumerable<AccountClass> GetAllAccountClasses()
        {
            return new[]
            {
                AccountClass.Residential,
                AccountClass.SmallCommercial,
                AccountClass.LargeCommercial
            };
        }

        /// <summary>
        /// Gets all valid Account Statuses
        /// </summary>
        /// <returns>A collection of all Account Statuses</returns>
        public IEnumerable<AccountStatus> GetAllAccountStatuses()
        {
            return new[]
            {
                AccountStatus.Canceled,
                AccountStatus.Closed,
                AccountStatus.DropPending,
                AccountStatus.Duplicate,
                AccountStatus.OffFlow,
                AccountStatus.OnFlow,
                AccountStatus.Pending,
                AccountStatus.Queued,
                AccountStatus.Rejected,
                AccountStatus.Scheduled,
                AccountStatus.Submitted
            };
        }

        /// <summary>
        /// Gets all valid Commodities
        /// </summary>
        /// <returns>A collection of all Commodities</returns>
        public IEnumerable<Commodity> GetAllCommodities()
        {
            return new[]
            {
                Commodity.Electric,
                Commodity.Gas,
                Commodity.Solar
            };
        }

        /// <summary>
        /// Gets all valid Plan Types
        /// </summary>
        /// <returns>A collection of all Plan Types</returns>
        public IEnumerable<PlanType> GetAllPlanTypes()
        {
            return new[]
            {
                PlanType.Fixed,
                PlanType.Variable,
                PlanType.Indexed
            };
        }

        /// <summary>
        /// Gets all valid Rate Types
        /// </summary>
        /// <returns>A collection of all Rate Types</returns>
        public IEnumerable<RateType> GetAllRateTypes()
        {
            return new[]
            {
                RateType.Enrollment,
                RateType.Switch,
                RateType.Renewal,
                RateType.Intro,
                RateType.Winback
            };
        }

        /// <summary>
        /// Gets all valid Unit of Measures
        /// </summary>
        /// <returns>A collection of all Unit of Measures</returns>
        public IEnumerable<UnitOfMeasure> GetAllUnitOfMeasures()
        {
            return new[]
            {
                UnitOfMeasure.kWh,
                UnitOfMeasure.MWh,
                UnitOfMeasure.GWh,
                UnitOfMeasure.Therm,
                UnitOfMeasure.Decatherm,
                UnitOfMeasure.Ccf,
                UnitOfMeasure.Mcf
            };
        }
    }
}
