using Shouldly;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Energy.UnitTests.DataStructures
{
    public class AccountStatusTests : UnitTest
    {
        public AccountStatusTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void AccountStatus_ShouldSetAsCanceled_WhenInputIsValid()
        {
            // Arrange
            string input = "Canceled";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Canceled.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsClosed_WhenInputIsValid()
        {
            // Arrange
            string input = "Closed";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Closed.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsDropPending_WhenInputIsValid()
        {
            // Arrange
            string input = "DropPending";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.DropPending.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsDuplicate_WhenInputIsValid()
        {
            // Arrange
            string input = "Duplicate";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Duplicate.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsOffFlow_WhenInputIsValid()
        {
            // Arrange
            string input = "OffFlow";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.OffFlow.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsOnFlow_WhenInputIsValid()
        {
            // Arrange
            string input = "OnFlow";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.OnFlow.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsPending_WhenInputIsValid()
        {
            // Arrange
            string input = "Pending";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Pending.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsQueued_WhenInputIsValid()
        {
            // Arrange
            string input = "Queued";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Queued.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsRejected_WhenInputIsValid()
        {
            // Arrange
            string input = "Rejected";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Rejected.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsScheduled_WhenInputIsValid()
        {
            // Arrange
            string input = "Scheduled";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Scheduled.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsSubmitted_WhenInputIsValid()
        {
            // Arrange
            string input = "Submitted";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Submitted.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsUnknown_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Unrecognized.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsUnknown_WhenInputIsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Unrecognized.Code);
        }

        [Fact]
        public void AccountStatus_ShouldSetAsUnknown_WhenInputIsInvalid()
        {
            // Arrange
            string input = "12345";

            // Act
            var output = new AccountStatus(input);

            // Assert
            output.Code.ShouldBe(AccountStatus.Unrecognized.Code);
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Pending");
            AccountStatus right = new AccountStatus("Pending");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Pending");
            AccountStatus right = new AccountStatus("PEN");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Pending");
            AccountStatus right = new AccountStatus("Queued");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStructureIsOnRightAndLeft()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Canceled");
            AccountStatus right = AccountStatus.Canceled;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Canceled");
            string right = "Canceled";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnRight()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Canceled");
            string right = "CAN";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnRight()
        {
            // Arrange
            AccountStatus left = new AccountStatus("Canceled");
            string right = "Closed";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnRight()
        {
            // Arrange
            AccountStatus left = AccountStatus.OnFlow;
            string right = "OnFlow";

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "OffFlow";
            AccountStatus right = new AccountStatus("OffFlow");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenInputStringsMismatchButAreEquivalentAndStringIsOnLeft()
        {
            // Arrange
            string left = "DPE";
            AccountStatus right = new AccountStatus("DropPending");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsNotEqual_WhenInputStringsMismatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Rejected";
            AccountStatus right = new AccountStatus("Submitted");

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeFalse();
        }

        [Fact]
        public void AccountStatus_ShouldEvaluateAsEqual_WhenComparingStaticInstancesInputStringsMatchAndStringIsOnLeft()
        {
            // Arrange
            string left = "Scheduled";
            AccountStatus right = AccountStatus.Scheduled;

            // Act
            bool output = (left == right);

            // Assert
            output.ShouldBeTrue();
        }

        [Fact]
        public void AccountStatus_ShouldReturnIdWhenCastingToInt_UnderAllConditions()
        {
            // Arrange
            var input = AccountStatus.Duplicate;
            int expected = AccountStatus.Duplicate.Id;

            // Act
            int output = (int)input;

            // Assert
            output.ShouldBe(expected);
        }

        [Fact]
        public void AccountStatus_ShouldReturnTrueOnTryParse_WhenTheInputIsValid()
        {
            // Arrange
            string input = "Canceled";

            // Act
            bool output = AccountStatus.TryParse(input, out AccountStatus instance);

            // Assert
            output.ShouldBeTrue();
            instance.ShouldBe(AccountStatus.Canceled);
        }

        [Fact]
        public void AccountStatus_ShouldReturnFalseOnTryParse_WhenTheInputIsInvalid()
        {
            // Arrange
            string input = "1234";

            // Act
            bool output = AccountStatus.TryParse(input, out AccountStatus instance);

            // Assert
            output.ShouldBeFalse();
            instance.ShouldBe(AccountStatus.Unrecognized);
        }

        [Theory]
        [MemberData(nameof(ValidCanceledStrings))]
        public void AccountStatus_ShouldParseAllCanceledValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Canceled);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidClosedStrings))]
        public void AccountStatus_ShouldParseAllClosedValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Closed);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidDropPendingStrings))]
        public void AccountStatus_ShouldParseAllDropPendingValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.DropPending);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidDuplicateStrings))]
        public void AccountStatus_ShouldParseAllDuplicateValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Duplicate);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidOffFlowStrings))]
        public void AccountStatus_ShouldParseAllOffFlowValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.OffFlow);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidOnFlowStrings))]
        public void AccountStatus_ShouldParseAllOnFlowValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.OnFlow);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidPendingStrings))]
        public void AccountStatus_ShouldParseAllPendingValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Pending);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidQueuedStrings))]
        public void AccountStatus_ShouldParseAllQueuedValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Queued);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidRejectedStrings))]
        public void AccountStatus_ShouldParseAllRejectedValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Rejected);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidScheduledStrings))]
        public void AccountStatus_ShouldParseAllScheduledValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Scheduled);

            // Assert
            output.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidSubmittedStrings))]
        public void AccountStatus_ShouldParseAllSubmittedValues_WhenTheyAreValid(string accountStatus)
        {
            // Arrange
            AccountStatus input = new AccountStatus(accountStatus);

            // Act
            bool output = (input == AccountStatus.Submitted);

            // Assert
            output.ShouldBeTrue();
        }

        /// <summary>
        /// Data source for Canceled Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidCanceledStrings =>
            new List<object[]>
            {
                new object[] { "can" },
                new object[] { "canceled" },
                new object[] { "CAN" },
                new object[] { "CANCELED" },
                new object[] { "Can." }
            };

        /// <summary>
        /// Data source for Closed Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidClosedStrings =>
            new List<object[]>
            {
                new object[] { "clo" },
                new object[] { "closed" },
                new object[] { "CLO" },
                new object[] { "CLOSED" },
                new object[] { "Clo." }
            };

        /// <summary>
        /// Data source for DropPending Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidDropPendingStrings =>
            new List<object[]>
            {
                new object[] { "dpe" },
                new object[] { "droppending" },
                new object[] { "DPE" },
                new object[] { "DROPPENDING" },
                new object[] { "Dpe." }
            };

        /// <summary>
        /// Data source for Duplicate Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidDuplicateStrings =>
            new List<object[]>
            {
                new object[] { "dup" },
                new object[] { "duplicate" },
                new object[] { "DUP" },
                new object[] { "DUPLICATE" },
                new object[] { "Dup." }
            };

        /// <summary>
        /// Data source for OffFlow Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidOffFlowStrings =>
            new List<object[]>
            {
                new object[] { "off" },
                new object[] { "offflow" },
                new object[] { "OFF" },
                new object[] { "OFFFLOW" },
                new object[] { "Off." }
            };

        /// <summary>
        /// Data source for OnFlow Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidOnFlowStrings =>
            new List<object[]>
            {
                new object[] { "onf" },
                new object[] { "onflow" },
                new object[] { "ONF" },
                new object[] { "ONFLOW" },
                new object[] { "Onf." }
            };

        /// <summary>
        /// Data source for Pending Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidPendingStrings =>
            new List<object[]>
            {
                new object[] { "pen" },
                new object[] { "pend" },
                new object[] { "pending" },
                new object[] { "PEN" },
                new object[] { "PEND" },
                new object[] { "PENDING" },
                new object[] { "Pend." }
            };

        /// <summary>
        /// Data source for Queued Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidQueuedStrings =>
            new List<object[]>
            {
                new object[] { "que" },
                new object[] { "queued" },
                new object[] { "QUE" },
                new object[] { "QUEUED" },
                new object[] { "Que." }
            };

        /// <summary>
        /// Data source for Rejected Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidRejectedStrings =>
            new List<object[]>
            {
                new object[] { "rej" },
                new object[] { "rejected" },
                new object[] { "REJ" },
                new object[] { "REJECTED" },
                new object[] { "Rej." }
            };

        /// <summary>
        /// Data source for Scheduled Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidScheduledStrings =>
            new List<object[]>
            {
                new object[] { "sch" },
                new object[] { "scheduled" },
                new object[] { "SCH" },
                new object[] { "SCHEDULED" },
                new object[] { "Sch." }
            };

        /// <summary>
        /// Data source for Submitted Theory.
        /// </summary>
        public static IEnumerable<object[]> ValidSubmittedStrings =>
            new List<object[]>
            {
                new object[] { "sub" },
                new object[] { "submitted" },
                new object[] { "SUB" },
                new object[] { "SUBMITTED" },
                new object[] { "Sub." }
            };
    }
}
