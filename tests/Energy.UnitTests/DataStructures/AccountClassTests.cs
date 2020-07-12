using Energy.DataStructures;
using Shouldly;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.DataStructures
{
    public class AccountClassTests : UnitTest
    {
        public AccountClassTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void AccountClass_ShouldSetAsResidential_WhenInputIsValid()
        {
            // Arrange
            string input = "Residential";

            // Act
            var output = new AccountClass(input);

            // Assert
            output.Code.ShouldBe(AccountClass.Residential.Code);
        }

        [Fact]
        public void AccountClass_ShouldSetAsSmallCommercial_WhenInputIsValid()
        {
            // Arrange
            string input = "Small Commercial";

            // Act
            var output = new AccountClass(input);

            // Assert
            output.Code.ShouldBe(AccountClass.SmallCommercial.Code);
        }

        [Fact]
        public void AccountClass_ShouldSetAsLargeCommercial_WhenInputIsValid()
        {
            // Arrange
            string input = "Large Commercial";

            // Act
            var output = new AccountClass(input);

            // Assert
            output.Code.ShouldBe(AccountClass.LargeCommercial.Code);
        }

        [Fact]
        public void AccountClass_ShouldSetAsUnknown_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = new AccountClass(input);

            // Assert
            output.Code.ShouldBe(AccountClass.Unrecognized.Code);
        }

        [Fact]
        public void AccountClass_ShouldSetAsUnknown_WhenInputIsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var output = new AccountClass(input);

            // Assert
            output.Code.ShouldBe(AccountClass.Unrecognized.Code);
        }

        [Fact]
        public void AccountClass_ShouldSetAsUnknown_WhenInputIsInvalid()
        {
            // Arrange
            string input = "12345";

            // Act
            var output = new AccountClass(input);

            // Assert
            output.Code.ShouldBe(AccountClass.Unrecognized.Code);
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            AccountClass right = new AccountClass("Residential");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            AccountClass right = new AccountClass("Resi");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            AccountClass right = new AccountClass("Small Commercial");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            AccountClass right = AccountClass.Residential;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            string right = "Residential";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnRight()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            string right = "Resi";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnRight()
        {
            // Arrange
            AccountClass left = new AccountClass("Residential");
            string right = "Small Commercial";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            AccountClass left = AccountClass.Residential;
            string right = "Residential";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Residential";
            AccountClass right = new AccountClass("Residential");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnLeft()
        {
            // Arrange
            string left = "Resi";
            AccountClass right = new AccountClass("Residential");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Small Commercial";
            AccountClass right = new AccountClass("Residential");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void AccountClass_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Residential";
            AccountClass right = AccountClass.Residential;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountClass_ShouldReturnIdWhenCastingToInt_UnderAllConditions()
        {
            // Arrange
            var input = AccountClass.LargeCommercial;
            int expected = AccountClass.LargeCommercial.Id;

            // Act
            int output = (int)input;

            // Assert
            output.ShouldBe(expected);
        }

        [Fact]
        public void AccountClass_ShouldReturnTrueOnTryParse_WhenTheInputIsValid()
        {
            // Arrange
            string input = "Residential";

            // Act
            bool output = AccountClass.TryParse(input, out AccountClass instance);

            // Assert
            output.ShouldBeTrue();
            instance.ShouldBe(AccountClass.Residential);
        }

        [Fact]
        public void AccountClass_ShouldReturnFalseOnTryParse_WhenTheInputIsInvalid()
        {
            // Arrange
            string input = "1234";

            // Act
            bool output = AccountClass.TryParse(input, out AccountClass instance);

            // Assert
            output.ShouldBeFalse();
            instance.ShouldBe(AccountClass.Unrecognized);
        }

        [Theory]
        [MemberData(nameof(ValidResidentialStrings))]
        public void AccountClass_ShouldParseAllResidentialValues_WhenTheyAreValid(string accountClass)
        {
            // Arrange
            AccountClass input = new AccountClass(accountClass);

            // Act
            bool output = (input == AccountClass.Residential);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidSmallCommercialStrings))]
        public void AccountClass_ShouldParseAllSmallCommercialValues_WhenTheyAreValid(string accountClass)
        {
            // Arrange
            AccountClass input = new AccountClass(accountClass);

            // Act
            bool output = (input == AccountClass.SmallCommercial);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidLargeCommercialStrings))]
        public void AccountClass_ShouldParseAllLargeCommercialValues_WhenTheyAreValid(string accountClass)
        {
            // Arrange
            AccountClass input = new AccountClass(accountClass);

            // Act
            bool output = (input == AccountClass.LargeCommercial);

            // Assert
            output.ShouldBeTrue();
        }

        /// <summary>
        /// Data source for Residential Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidResidentialStrings =>
            new List<object[]>
            {
                new object[] { "r" },
                new object[] { "res" },
                new object[] { "resi" },
                new object[] { "residence" },
                new object[] { "residential" },
                new object[] { "R" },
                new object[] { "RES" },
                new object[] { "RESI" },
                new object[] { "RESIDENCE" },
                new object[] { "RESIDENTIAL" },
                new object[] { "Res." },
                new object[] { "Resi." }
            };

        /// <summary>
        /// Data source for Small Commercial Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidSmallCommercialStrings =>
            new List<object[]>
            {
                new object[] { "sc" },
                new object[] { "scom" },
                new object[] { "scomm" },
                new object[] { "smallcomm" },
                new object[] { "small comm" },
                new object[] { "small_comm" },
                new object[] { "smallcommercial" },
                new object[] { "small commercial" },
                new object[] { "small_commercial" },
                new object[] { "SC" },
                new object[] { "SCOM" },
                new object[] { "SCOMM" },
                new object[] { "SMALLCOMM" },
                new object[] { "SMALL COMM" },
                new object[] { "SMALL_COMM" },
                new object[] { "SMALLCOMMERCIAL" },
                new object[] { "SMALL COMMERCIAL" },
                new object[] { "SMALL_COMMERCIAL" },
                new object[] { "s.c." },
                new object[] { "sc." },
                new object[] { "scomm." },
                new object[] { "Small Comm." },
                new object[] { "Small_Com." },
                new object[] { "smallcomm." }
            };

        /// <summary>
        /// Data source for Large Commercial Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidLargeCommercialStrings =>
            new List<object[]>
            {
                new object[] { "lc" },
                new object[] { "lcom" },
                new object[] { "lcomm" },
                new object[] { "largecomm" },
                new object[] { "large comm" },
                new object[] { "large_comm" },
                new object[] { "largecommercial" },
                new object[] { "large commercial" },
                new object[] { "large_commercial" },
                new object[] { "LC" },
                new object[] { "LCOM" },
                new object[] { "LCOMM" },
                new object[] { "LARGECOMM" },
                new object[] { "LARGE COMM" },
                new object[] { "LARGE_COMM" },
                new object[] { "LARGECOMMERCIAL" },
                new object[] { "LARGE COMMERCIAL" },
                new object[] { "LARGE_COMMERCIAL" },
                new object[] { "l.c." },
                new object[] { "lc." },
                new object[] { "lcomm." },
                new object[] { "Large Comm." },
                new object[] { "Large_Com." },
                new object[] { "largecomm." }
            };
    }
}
