using System.Collections.Generic;
using Energy.DataStructures;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.DataStructures
{
    public class RateTypeTests : UnitTest
    {
        public RateTypeTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void RateType_ShouldSetAsEnrollment_WhenInputIsValid()
        {
            // Arrange
            string input = "Enrollment";

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Enrollment.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsRenewal_WhenInputIsValid()
        {
            // Arrange
            string input = "Renewal";

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Renewal.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsSwitch_WhenInputIsValid()
        {
            // Arrange
            string input = "Switch";

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Switch.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsIntro_WhenInputIsValid()
        {
            // Arrange
            string input = "Intro";

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Intro.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsWinback_WhenInputIsValid()
        {
            // Arrange
            string input = "Winback";

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Winback.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsUnknown_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Unrecognized.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsUnknown_WhenInputIsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Unrecognized.Code);
        }

        [Fact]
        public void RateType_ShouldSetAsUnknown_WhenInputIsInvalid()
        {
            // Arrange
            string input = "12345";

            // Act
            var output = new RateType(input);

            // Assert
            output.Code.ShouldBe(RateType.Unrecognized.Code);
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            RateType right = new RateType("Enrollment");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStructureIsOnRightAndLeft()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            RateType right = new RateType("ENR");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            RateType right = new RateType("Switch");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            RateType right = RateType.Enrollment;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            string right = "Enrollment";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnRight()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            string right = "ENR";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnRight()
        {
            // Arrange
            RateType left = new RateType("Enrollment");
            string right = "Switch";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            RateType left = RateType.Enrollment;
            string right = "Enrollment";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Enrollment";
            RateType right = new RateType("Enrollment");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnLeft()
        {
            // Arrange
            string left = "ENR";
            RateType right = new RateType("Enrollment");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Switch";
            RateType right = new RateType("Enrollment");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void RateType_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Enrollment";
            RateType right = RateType.Enrollment;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void RateType_ShouldReturnIdWhenCastingToInt_UnderAllConditions()
        {
            // Arrange
            var input = RateType.Winback;
            int expected = RateType.Winback.Id;

            // Act
            int output = (int)input;

            // Assert
            output.ShouldBe(expected);
        }

        [Fact]
        public void RateType_ShouldReturnTrueOnTryParse_WhenTheInputIsValid()
        {
            // Arrange
            string input = "Enrollment";

            // Act
            bool output = RateType.TryParse(input, out RateType instance);

            // Assert
            output.ShouldBeTrue();
            instance.ShouldBe(RateType.Enrollment);
        }

        [Fact]
        public void RateType_ShouldReturnFalseOnTryParse_WhenTheInputIsInvalid()
        {
            // Arrange
            string input = "1234";

            // Act
            bool output = RateType.TryParse(input, out RateType instance);

            // Assert
            output.ShouldBeFalse();
            instance.ShouldBe(RateType.Unrecognized);
        }

        [Theory]
        [MemberData(nameof(ValidEnrollmentStrings))]
        public void RateType_ShouldParseAllEnrollmentValues_WhenTheyAreValid(string rateType)
        {
            // Arrange
            RateType input = new RateType(rateType);

            // Act
            bool output = (input == RateType.Enrollment);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidSwitchStrings))]
        public void RateType_ShouldParseAllSwitchValues_WhenTheyAreValid(string rateType)
        {
            // Arrange
            RateType input = new RateType(rateType);

            // Act
            bool output = (input == RateType.Switch);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidRenewalStrings))]
        public void RateType_ShouldParseAllRenewalValues_WhenTheyAreValid(string rateType)
        {
            // Arrange
            RateType input = new RateType(rateType);

            // Act
            bool output = (input == RateType.Renewal);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidIntroStrings))]
        public void RateType_ShouldParseAllIntroValues_WhenTheyAreValid(string rateType)
        {
            // Arrange
            RateType input = new RateType(rateType);

            // Act
            bool output = (input == RateType.Intro);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidWinbackStrings))]
        public void RateType_ShouldParseAllWinbackValues_WhenTheyAreValid(string rateType)
        {
            // Arrange
            RateType input = new RateType(rateType);

            // Act
            bool output = (input == RateType.Winback);

            // Assert
            output.ShouldBeTrue();
        }

        /// <summary>
        /// Data source for Enrollment Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidEnrollmentStrings =>
            new List<object[]>
            {
                new object[] { "e" },
                new object[] { "enr" },
                new object[] { "enroll" },
                new object[] { "enrollment" },
                new object[] { "E" },
                new object[] { "ENR" },
                new object[] { "ENROLL" },
                new object[] { "ENROLLMENT" },
                new object[] { "E." },
                new object[] { "enr." },
                new object[] { "enroll." }
            };

        /// <summary>
        /// Data source for Switch Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidSwitchStrings =>
            new List<object[]>
            {
                new object[] { "s" },
                new object[] { "swi" },
                new object[] { "switch" },
                new object[] { "S" },
                new object[] { "SWI" },
                new object[] { "SWITCH" },
                new object[] { "S." },
                new object[] { "swi." },
                new object[] { "SWITCH." }
            };

        /// <summary>
        /// Data source for Renewal Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidRenewalStrings =>
            new List<object[]>
            {
                new object[] { "r" },
                new object[] { "ren" },
                new object[] { "renew" },
                new object[] { "renewal" },
                new object[] { "R" },
                new object[] { "REN" },
                new object[] { "RENEW" },
                new object[] { "RENEWAL" },
                new object[] { "R." },
                new object[] { "ren." },
                new object[] { "renew." },
                new object[] { "renewal." }
            };

        /// <summary>
        /// Data source for Intro Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidIntroStrings =>
            new List<object[]>
            {
                new object[] { "i" },
                new object[] { "int" },
                new object[] { "intro" },
                new object[] { "introduction" },
                new object[] { "introductory" },
                new object[] { "I" },
                new object[] { "INT" },
                new object[] { "INTRO" },
                new object[] { "INTRODUCTION" },
                new object[] { "INTRODUCTORY" },
                new object[] { "I." },
                new object[] { "int." },
                new object[] { "intro." },
                new object[] { "introduction." },
                new object[] { "INTRODUCTORY." }
            };

        /// <summary>
        /// Data source for Winback Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidWinbackStrings =>
            new List<object[]>
            {
                new object[] { "w" },
                new object[] { "win" },
                new object[] { "winback" },
                new object[] { "W" },
                new object[] { "WIN" },
                new object[] { "WINBACK" },
                new object[] { "W." },
                new object[] { "win." },
                new object[] { "winback." }
            };
    }
}
