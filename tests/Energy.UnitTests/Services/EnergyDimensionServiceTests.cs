using Energy.Services.Impl;
using Shouldly;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.Services
{
    public class EnergyDimensionServiceTests : AutoMockTest<EnergyDimensionService>
    {
        public EnergyDimensionServiceTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void GetAllAccountClasses_ShouldReturnAllValidValues_UnderAllConditions()
        {
            // Arrange & Act
            AccountClass[] output = CUT.GetAllAccountClasses().ToArray();

            // Assert
            output.ShouldNotBeNull();
            output.ShouldNotBeEmpty();
            output.ShouldContain(AccountClass.Residential);
            output.ShouldContain(AccountClass.SmallCommercial);
            output.ShouldContain(AccountClass.LargeCommercial);
        }

        [Fact]
        public void GetAllAccountStatuses_ShouldReturnAllValidValues_UnderAllConditions()
        {
            // Arrange & Act
            AccountStatus[] output = CUT.GetAllAccountStatuses().ToArray();

            // Assert
            output.ShouldNotBeNull();
            output.ShouldNotBeEmpty();
            output.ShouldContain(AccountStatus.Canceled);
            output.ShouldContain(AccountStatus.Closed);
            output.ShouldContain(AccountStatus.DropPending);
            output.ShouldContain(AccountStatus.Duplicate);
            output.ShouldContain(AccountStatus.OffFlow);
            output.ShouldContain(AccountStatus.OnFlow);
            output.ShouldContain(AccountStatus.Pending);
            output.ShouldContain(AccountStatus.Queued);
            output.ShouldContain(AccountStatus.Rejected);
            output.ShouldContain(AccountStatus.Scheduled);
            output.ShouldContain(AccountStatus.Submitted);
        }

        [Fact]
        public void GetAllCommodities_ShouldReturnAllValidValues_UnderAllConditions()
        {
            // Arrange & Act
            Commodity[] output = CUT.GetAllCommodities().ToArray();

            // Assert
            output.ShouldNotBeNull();
            output.ShouldNotBeEmpty();
            output.ShouldContain(Commodity.Electric);
            output.ShouldContain(Commodity.Gas);
            output.ShouldContain(Commodity.Solar);
        }

        [Fact]
        public void GetAllPlanTypes_ShouldReturnAllValidValues_UnderAllConditions()
        {
            // Arrange & Act
            PlanType[] output = CUT.GetAllPlanTypes().ToArray();

            // Assert
            output.ShouldNotBeNull();
            output.ShouldNotBeEmpty();
            output.ShouldContain(PlanType.Fixed);
            output.ShouldContain(PlanType.Variable);
            output.ShouldContain(PlanType.Indexed);
        }

        [Fact]
        public void GetAllRateTypes_ShouldReturnAllValidValues_UnderAllConditions()
        {
            // Arrange & Act
            RateType[] output = CUT.GetAllRateTypes().ToArray();

            // Assert
            output.ShouldNotBeNull();
            output.ShouldNotBeEmpty();
            output.ShouldContain(RateType.Enrollment);
            output.ShouldContain(RateType.Switch);
            output.ShouldContain(RateType.Renewal);
            output.ShouldContain(RateType.Intro);
            output.ShouldContain(RateType.Winback);
        }

        [Fact]
        public void GetAllUnitOfMeasures_ShouldReturnAllValidValues_UnderAllConditions()
        {
            // Arrange & Act
            UnitOfMeasure[] output = CUT.GetAllUnitOfMeasures().ToArray();

            // Assert
            output.ShouldNotBeNull();
            output.ShouldNotBeEmpty();
            output.ShouldContain(UnitOfMeasure.kWh);
            output.ShouldContain(UnitOfMeasure.MWh);
            output.ShouldContain(UnitOfMeasure.GWh);
            output.ShouldContain(UnitOfMeasure.Therm);
            output.ShouldContain(UnitOfMeasure.Decatherm);
            output.ShouldContain(UnitOfMeasure.Ccf);
            output.ShouldContain(UnitOfMeasure.Mcf);
        }
    }
}
