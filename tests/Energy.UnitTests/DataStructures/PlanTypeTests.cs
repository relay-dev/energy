using System.Collections.Generic;
using Energy.DataStructures;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.DataStructures
{
    public class PlanTypeTests : UnitTest
    {
        public PlanTypeTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void PlanType_ShouldSetAsFixed_WhenInputIsValid()
        {
            // Arrange
            string input = "Fixed";

            // Act
            var output = new PlanType(input);

            // Assert
            output.Code.ShouldBe(PlanType.Fixed.Code);
        }

        [Fact]
        public void PlanType_ShouldSetAsVariable_WhenInputIsValid()
        {
            // Arrange
            string input = "Variable";

            // Act
            var output = new PlanType(input);

            // Assert
            output.Code.ShouldBe(PlanType.Variable.Code);
        }

        [Fact]
        public void PlanType_ShouldSetAsIndexed_WhenInputIsValid()
        {
            // Arrange
            string input = "Indexed";

            // Act
            var output = new PlanType(input);

            // Assert
            output.Code.ShouldBe(PlanType.Indexed.Code);
        }

        [Fact]
        public void PlanType_ShouldSetAsUnknown_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = new PlanType(input);

            // Assert
            output.Code.ShouldBe(PlanType.Unrecognized.Code);
        }

        [Fact]
        public void PlanType_ShouldSetAsUnknown_WhenInputIsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var output = new PlanType(input);

            // Assert
            output.Code.ShouldBe(PlanType.Unrecognized.Code);
        }

        [Fact]
        public void PlanType_ShouldSetAsUnknown_WhenInputIsInvalid()
        {
            // Arrange
            string input = "12345";

            // Act
            var output = new PlanType(input);

            // Assert
            output.Code.ShouldBe(PlanType.Unrecognized.Code);
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            PlanType right = new PlanType("Fixed");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStructureIsOnRightAndLeft()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            PlanType right = new PlanType("FIX");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            PlanType right = new PlanType("Variable");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            PlanType right = PlanType.Fixed;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            string right = "Fixed";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnRight()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            string right = "FIX";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnRight()
        {
            // Arrange
            PlanType left = new PlanType("Fixed");
            string right = "Variable";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            PlanType left = PlanType.Fixed;
            string right = "Fixed";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Fixed";
            PlanType right = new PlanType("Fixed");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnLeft()
        {
            // Arrange
            string left = "FIX";
            PlanType right = new PlanType("Fixed");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Variable";
            PlanType right = new PlanType("Fixed");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void PlanType_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Fixed";
            PlanType right = PlanType.Fixed;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void PlanType_ShouldReturnIdWhenCastingToInt_UnderAllConditions()
        {
            // Arrange
            var input = PlanType.Indexed;
            int expected = PlanType.Indexed.Id;

            // Act
            int output = (int)input;

            // Assert
            output.ShouldBe(expected);
        }

        [Fact]
        public void PlanType_ShouldReturnTrueOnTryParse_WhenTheInputIsValid()
        {
            // Arrange
            string input = "Fixed";

            // Act
            bool output = PlanType.TryParse(input, out PlanType instance);

            // Assert
            output.ShouldBeTrue();
            instance.ShouldBe(PlanType.Fixed);
        }

        [Fact]
        public void PlanType_ShouldReturnFalseOnTryParse_WhenTheInputIsInvalid()
        {
            // Arrange
            string input = "1234";

            // Act
            bool output = PlanType.TryParse(input, out PlanType instance);

            // Assert
            output.ShouldBeFalse();
            instance.ShouldBe(PlanType.Unrecognized);
        }

        [Theory]
        [MemberData(nameof(ValidFixedStrings))]
        public void PlanType_ShouldParseAllFixedValues_WhenTheyAreValid(string planType)
        {
            // Arrange
            PlanType input = new PlanType(planType);

            // Act
            bool output = (input == PlanType.Fixed);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidVariableStrings))]
        public void PlanType_ShouldParseAllVariableValues_WhenTheyAreValid(string planType)
        {
            // Arrange
            PlanType input = new PlanType(planType);

            // Act
            bool output = (input == PlanType.Variable);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidIndexedStrings))]
        public void PlanType_ShouldParseAllIndexedValues_WhenTheyAreValid(string planType)
        {
            // Arrange
            PlanType input = new PlanType(planType);

            // Act
            bool output = (input == PlanType.Indexed);

            // Assert
            output.ShouldBeTrue();
        }

        /// <summary>
        /// Data source for Fixed Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidFixedStrings =>
            new List<object[]>
            {
                new object[] { "f" },
                new object[] { "fix" },
                new object[] { "fixed" },
                new object[] { "F" },
                new object[] { "FIX" },
                new object[] { "FIXED" },
                new object[] { "f." },
                new object[] { "F." },
                new object[] { "fix." },
                new object[] { "FIXED." }
            };

        /// <summary>
        /// Data source for Variable Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidVariableStrings =>
            new List<object[]>
            {
                new object[] { "v" },
                new object[] { "var" },
                new object[] { "variable" },
                new object[] { "V" },
                new object[] { "VAR" },
                new object[] { "VARIABLE" },
                new object[] { "v." },
                new object[] { "V." },
                new object[] { "Var." },
                new object[] { "variable." }
            };

        /// <summary>
        /// Data source for Indexed Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidIndexedStrings =>
            new List<object[]>
            {
                new object[] { "i" },
                new object[] { "idx" },
                new object[] { "ind" },
                new object[] { "index" },
                new object[] { "indexed" },
                new object[] { "I" },
                new object[] { "IDX" },
                new object[] { "IND" },
                new object[] { "INDEX" },
                new object[] { "INDEXED" },
                new object[] { "i." },
                new object[] { "I." },
                new object[] { "ind." },
                new object[] { "IDX." }
            };
    }
}
