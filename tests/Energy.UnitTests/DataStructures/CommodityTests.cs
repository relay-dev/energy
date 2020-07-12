using Energy.DataStructures;
using Shouldly;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.DataStructures
{
    public class CommodityTests : UnitTest
    {
        public CommodityTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void Commodity_ShouldSetAsResidential_WhenInputIsValid()
        {
            // Arrange
            string input = "Electric";

            // Act
            var output = new Commodity(input);

            // Assert
            output.Code.ShouldBe(Commodity.Electric.Code);
        }

        [Fact]
        public void Commodity_ShouldSetAsSmallCommercial_WhenInputIsValid()
        {
            // Arrange
            string input = "Gas";

            // Act
            var output = new Commodity(input);

            // Assert
            output.Code.ShouldBe(Commodity.Gas.Code);
        }

        [Fact]
        public void Commodity_ShouldSetAsLargeCommercial_WhenInputIsValid()
        {
            // Arrange
            string input = "Solar";

            // Act
            var output = new Commodity(input);

            // Assert
            output.Code.ShouldBe(Commodity.Solar.Code);
        }

        [Fact]
        public void Commodity_ShouldSetAsUnknown_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = new Commodity(input);

            // Assert
            output.Code.ShouldBe(Commodity.Unrecognized.Code);
        }

        [Fact]
        public void Commodity_ShouldSetAsUnknown_WhenInputIsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var output = new Commodity(input);

            // Assert
            output.Code.ShouldBe(Commodity.Unrecognized.Code);
        }

        [Fact]
        public void Commodity_ShouldSetAsUnknown_WhenInputIsInvalid()
        {
            // Arrange
            string input = "12345";

            // Act
            var output = new Commodity(input);

            // Assert
            output.Code.ShouldBe(Commodity.Unrecognized.Code);
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            Commodity right = new Commodity("Electric");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStructureIsOnRightAndLeft()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            Commodity right = new Commodity("E");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            Commodity right = new Commodity("Gas");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            Commodity right = Commodity.Electric;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            string right = "Electric";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnRight()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            string right = "E";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnRight()
        {
            // Arrange
            Commodity left = new Commodity("Electric");
            string right = "G";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            Commodity left = Commodity.Electric;
            string right = "Electric";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Electric";
            Commodity right = new Commodity("Electric");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnLeft()
        {
            // Arrange
            string left = "E";
            Commodity right = new Commodity("Electric");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Gas";
            Commodity right = new Commodity("Electric");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void Commodity_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Electric";
            Commodity right = Commodity.Electric;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void Commodity_ShouldReturnIdWhenCastingToInt_UnderAllConditions()
        {
            // Arrange
            var input = Commodity.Solar;
            int expected = Commodity.Solar.Id;

            // Act
            int output = (int)input;

            // Assert
            output.ShouldBe(expected);
        }

        [Fact]
        public void Commodity_ShouldReturnTrueOnTryParse_WhenTheInputIsValid()
        {
            // Arrange
            string input = "Gas";

            // Act
            bool output = Commodity.TryParse(input, out Commodity instance);

            // Assert
            output.ShouldBeTrue();
            instance.ShouldBe(Commodity.Gas);
        }

        [Fact]
        public void Commodity_ShouldReturnFalseOnTryParse_WhenTheInputIsInvalid()
        {
            // Arrange
            string input = "1234";

            // Act
            bool output = Commodity.TryParse(input, out Commodity instance);

            // Assert
            output.ShouldBeFalse();
            instance.ShouldBe(Commodity.Unrecognized);
        }

        [Theory]
        [MemberData(nameof(ValidElectricStrings))]
        public void Commodity_ShouldParseAllResidentialValues_WhenTheyAreValid(string commodity)
        {
            // Arrange
            Commodity input = new Commodity(commodity);

            // Act
            bool output = (input == Commodity.Electric);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidGasStrings))]
        public void Commodity_ShouldParseAllSmallCommercialValues_WhenTheyAreValid(string commodity)
        {
            // Arrange
            Commodity input = new Commodity(commodity);

            // Act
            bool output = (input == Commodity.Gas);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidSolarStrings))]
        public void Commodity_ShouldParseAllLargeCommercialValues_WhenTheyAreValid(string commodity)
        {
            // Arrange
            Commodity input = new Commodity(commodity);

            // Act
            bool output = (input == Commodity.Solar);

            // Assert
            output.ShouldBeTrue();
        }

        /// <summary>
        /// Data source for Electric Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidElectricStrings =>
            new List<object[]>
            {
                new object[] { "e" },
                new object[] { "el" },
                new object[] { "ele" },
                new object[] { "elec" },
                new object[] { "electric" },
                new object[] { "electricity" },
                new object[] { "E" },
                new object[] { "EL" },
                new object[] { "ELE" },
                new object[] { "ELEC" },
                new object[] { "ELECTRIC" },
                new object[] { "ELECTRICITY" },
                new object[] { "E." },
                new object[] { "Elec." }
            };

        /// <summary>
        /// Data source for Gas Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidGasStrings =>
            new List<object[]>
            {
                new object[] { "g" },
                new object[] { "ga" },
                new object[] { "gas" },
                new object[] { "G" },
                new object[] { "GA" },
                new object[] { "GAS" },
                new object[] { "G." },
                new object[] { "Ga." }
            };

        /// <summary>
        /// Data source for Solar Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidSolarStrings =>
            new List<object[]>
            {
                new object[] { "s" },
                new object[] { "so" },
                new object[] { "sol" },
                new object[] { "solar" },
                new object[] { "S" },
                new object[] { "SO" },
                new object[] { "SOL" },
                new object[] { "SOLAR" },
                new object[] { "S." },
                new object[] { "sol." }
            };
    }
}
