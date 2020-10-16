using Shouldly;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.DataStructures
{
    public class UnitOfMeasureTests : UnitTest
    {
        public UnitOfMeasureTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsKilowattHour_WhenInputIsValid()
        {
            // Arrange
            string input = "kWh";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.kWh.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsMegawattHour_WhenInputIsValid()
        {
            // Arrange
            string input = "MWh";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.MWh.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsGigawattHour_WhenInputIsValid()
        {
            // Arrange
            string input = "GWh";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.GWh.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsTherm_WhenInputIsValid()
        {
            // Arrange
            string input = "Therm";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Therm.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsDecatherm_WhenInputIsValid()
        {
            // Arrange
            string input = "Dth";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Decatherm.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsCentumCubicFeet_WhenInputIsValid()
        {
            // Arrange
            string input = "Ccf";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Ccf.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsOneThousandCubicFeet_WhenInputIsValid()
        {
            // Arrange
            string input = "Mcf";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Mcf.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsUnknown_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Unrecognized.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsUnknown_WhenInputIsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Unrecognized.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldSetAsUnknown_WhenInputIsInvalid()
        {
            // Arrange
            string input = "12345";

            // Act
            var output = new UnitOfMeasure(input);

            // Assert
            output.Code.ShouldBe(UnitOfMeasure.Unrecognized.Code);
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            UnitOfMeasure right = new UnitOfMeasure("kWh");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStructureIsOnRightAndLeft()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            UnitOfMeasure right = new UnitOfMeasure("KILOWATTHOURS");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            UnitOfMeasure right = new UnitOfMeasure("MWh");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            UnitOfMeasure right = UnitOfMeasure.kWh;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            string right = "kWh";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnRight()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            string right = "KILOWATTHOURS";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnRight()
        {
            // Arrange
            UnitOfMeasure left = new UnitOfMeasure("kWh");
            string right = "MWh";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            UnitOfMeasure left = UnitOfMeasure.kWh;
            string right = "kWh";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "kWh";
            UnitOfMeasure right = new UnitOfMeasure("kWh");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnLeft()
        {
            // Arrange
            string left = "KILOWATTHOURS";
            UnitOfMeasure right = new UnitOfMeasure("kWh");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "MWh";
            UnitOfMeasure right = new UnitOfMeasure("kWh");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void UnitOfMeasure_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "kWh";
            UnitOfMeasure right = UnitOfMeasure.kWh;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void UnitOfMeasure_ShouldReturnIdWhenCastingToInt_UnderAllConditions()
        {
            // Arrange
            var input = UnitOfMeasure.Decatherm;
            int expected = UnitOfMeasure.Decatherm.Id;

            // Act
            int output = (int)input;

            // Assert
            output.ShouldBe(expected);
        }

        [Fact]
        public void UnitOfMeasure_ShouldReturnTrueOnTryParse_WhenTheInputIsValid()
        {
            // Arrange
            string input = "kWh";

            // Act
            bool output = UnitOfMeasure.TryParse(input, out UnitOfMeasure instance);

            // Assert
            output.ShouldBeTrue();
            instance.ShouldBe(UnitOfMeasure.kWh);
        }

        [Fact]
        public void UnitOfMeasure_ShouldReturnFalseOnTryParse_WhenTheInputIsInvalid()
        {
            // Arrange
            string input = "1234";

            // Act
            bool output = UnitOfMeasure.TryParse(input, out UnitOfMeasure instance);

            // Assert
            output.ShouldBeFalse();
            instance.ShouldBe(UnitOfMeasure.Unrecognized);
        }

        [Theory]
        [MemberData(nameof(ValidKilowattHourStrings))]
        public void UnitOfMeasure_ShouldParseAllKilowattHourValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.kWh);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidMegawattHourStrings))]
        public void UnitOfMeasure_ShouldParseAllMegawattHourValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.MWh);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidGigawattHourStrings))]
        public void UnitOfMeasure_ShouldParseAllGigawattHourValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.GWh);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidThermStrings))]
        public void UnitOfMeasure_ShouldParseAllThermValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.Therm);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidDecathermStrings))]
        public void UnitOfMeasure_ShouldParseAllDecathermValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.Decatherm);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidCentumCubicFeetStrings))]
        public void UnitOfMeasure_ShouldParseAllCentumCubicFeetValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.Ccf);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidOneThousandCubicFeetStrings))]
        public void UnitOfMeasure_ShouldParseAllOneThousandCubicFeetValues_WhenTheyAreValid(string unitOfMeasure)
        {
            // Arrange
            UnitOfMeasure input = new UnitOfMeasure(unitOfMeasure);

            // Act
            bool output = (input == UnitOfMeasure.Mcf);

            // Assert
            output.ShouldBeTrue();
        }

        /// <summary>
        /// Data source for KilowattHour Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidKilowattHourStrings =>
            new List<object[]>
            {
                new object[] { "kw" },
                new object[] { "kwh" },
                new object[] { "kilowatt" },
                new object[] { "kilowatts" },
                new object[] { "kilowatthour" },
                new object[] { "kilowatthours" },
                new object[] { "KW" },
                new object[] { "KWH" },
                new object[] { "KILOWATT" },
                new object[] { "KILOWATTS" },
                new object[] { "KILOWATTHOUR" },
                new object[] { "kilowatthours" },
                new object[] { "kw." },
                new object[] { "k.w.h" },
                new object[] { "kilowatt." },
                new object[] { "kilowatts." },
                new object[] { "kilowatt.hour" },
                new object[] { "kilowatt.hours." }
            };

        /// <summary>
        /// Data source for MegawattHour Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidMegawattHourStrings =>
            new List<object[]>
            {
                new object[] { "mw" },
                new object[] { "mwh" },
                new object[] { "megawatt" },
                new object[] { "megawatts" },
                new object[] { "megawatthour" },
                new object[] { "megawatthours" },
                new object[] { "MW" },
                new object[] { "MWH" },
                new object[] { "MEGAWATT" },
                new object[] { "MEGAWATTS" },
                new object[] { "MEGAWATTHOUR" },
                new object[] { "MEGAWATTHOURS" },
                new object[] { "mw." },
                new object[] { "m.w.h." },
                new object[] { "mega.watt" },
                new object[] { "mega.watts." },
                new object[] { "megawatt.hour." },
                new object[] { "megawatt.hours." }
            };

        /// <summary>
        /// Data source for GigawattHour Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidGigawattHourStrings =>
            new List<object[]>
            {
                new object[] { "gw" },
                new object[] { "gwh" },
                new object[] { "gigawatt" },
                new object[] { "gigawatts" },
                new object[] { "gigawatthour" },
                new object[] { "gigawatthours" },
                new object[] { "GW" },
                new object[] { "GWH" },
                new object[] { "GIGAWATT" },
                new object[] { "GIGAWATTS" },
                new object[] { "GIGAWATTHOUR" },
                new object[] { "GIGAWATTHOURS" },
                new object[] { "gw." },
                new object[] { "g.w.h." },
                new object[] { "gigawatt." },
                new object[] { "gigawatts." },
                new object[] { "gigawatthour." },
                new object[] { "gigawatthours." }
            };

        /// <summary>
        /// Data source for Therm Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidThermStrings =>
            new List<object[]>
            {
                new object[] { "t" },
                new object[] { "th" },
                new object[] { "ther" },
                new object[] { "therm" },
                new object[] { "therms" },
                new object[] { "T" },
                new object[] { "TH" },
                new object[] { "THER" },
                new object[] { "THERM" },
                new object[] { "THERMS" },
                new object[] { "t." },
                new object[] { "t.h." },
                new object[] { "ther." },
                new object[] { "therm." },
                new object[] { "therms." }
            };

        /// <summary>
        /// Data source for Decatherm Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidDecathermStrings =>
            new List<object[]>
            {
                new object[] { "dec" },
                new object[] { "dth" },
                new object[] { "deca" },
                new object[] { "decatherm" },
                new object[] { "decatherms" },
                new object[] { "DEC" },
                new object[] { "DTH" },
                new object[] { "DECA" },
                new object[] { "DECATHERM" },
                new object[] { "DECATHERMS" },
                new object[] { "dec." },
                new object[] { "d.t.h." },
                new object[] { "deca." },
                new object[] { "decatherm." },
                new object[] { "decatherms." }
            };

        /// <summary>
        /// Data source for Centum Cubic Feet Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidCentumCubicFeetStrings =>
            new List<object[]>
            {
                new object[] { "ccf" },
                new object[] { "centum" },
                new object[] { "centums" },
                new object[] { "centumcubic" },
                new object[] { "centumcubics" },
                new object[] { "centumcubicfeet" },
                new object[] { "CCF" },
                new object[] { "CENTUM" },
                new object[] { "CENTUMS" },
                new object[] { "CENTUMCUBIC" },
                new object[] { "CENTUMCUBICS" },
                new object[] { "CENTUMCUBICFEET" },
                new object[] { "c.c.f." },
                new object[] { "centum." },
                new object[] { "centums." },
                new object[] { "centum.cubic" },
                new object[] { "centumcubics." },
                new object[] { "centum.cubic.feet" }
            };

        /// <summary>
        /// Data source for 1,000 Cubic Feet Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidOneThousandCubicFeetStrings =>
            new List<object[]>
            {
                new object[] { "mcf" },
                new object[] { "MCF" },
                new object[] { "m.c.f." }
            };
    }
}
