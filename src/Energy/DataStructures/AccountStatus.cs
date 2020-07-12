using Energy.Extensions;
using System;

namespace Energy.DataStructures
{
    /// <summary>
    /// The status of an energy account.
    /// </summary>
    public readonly struct AccountStatus : IEnergyDimension, IEquatable<AccountStatus>
    {
        /// <summary>
        /// Unrecognized value.
        /// </summary>
        public static AccountStatus Unrecognized = AccountStatus.CreateInstance("Unrecognized");

        /// <summary>
        /// Canceled value.
        /// </summary>
        public static AccountStatus Canceled = AccountStatus.CreateInstance("Canceled", 1, "CAN");

        /// <summary>
        /// Closed value.
        /// </summary>
        public static AccountStatus Closed = AccountStatus.CreateInstance("Closed", 2, "CLO");

        /// <summary>
        /// Drop Pending value.
        /// </summary>
        public static AccountStatus DropPending = AccountStatus.CreateInstance("Drop Pending", 3, "DPE");

        /// <summary>
        /// Duplicate value.
        /// </summary>
        public static AccountStatus Duplicate = AccountStatus.CreateInstance("Duplicate", 4, "DUP");

        /// <summary>
        /// Off Flow value.
        /// </summary>
        public static AccountStatus OffFlow = AccountStatus.CreateInstance("Off Flow", 5, "OFF");

        /// <summary>
        /// On Flow value.
        /// </summary>
        public static AccountStatus OnFlow = AccountStatus.CreateInstance("On Flow", 6, "ONF");

        /// <summary>
        /// Pending value.
        /// </summary>
        public static AccountStatus Pending = AccountStatus.CreateInstance("Pending", 7, "PEN");

        /// <summary>
        /// Queued value.
        /// </summary>
        public static AccountStatus Queued = AccountStatus.CreateInstance("Queued", 8, "QUE");

        /// <summary>
        /// Rejected value.
        /// </summary>
        public static AccountStatus Rejected = AccountStatus.CreateInstance("Rejected", 9, "REJ");

        /// <summary>
        /// Scheduled value.
        /// </summary>
        public static AccountStatus Scheduled = AccountStatus.CreateInstance("Scheduled", 10, "SCH");

        /// <summary>
        /// Submitted.
        /// </summary>
        public static AccountStatus Submitted = AccountStatus.CreateInstance("Submitted", 11, "SUB");

        /// <summary>
        /// Creates a new AccountStatus.
        /// </summary>
        /// <param name="accountStatus">A string representation of an AccountStatus.</param>
        public AccountStatus(string accountStatus)
        {
            AccountStatus status = Parse(accountStatus);

            Id = status.Id;
            Name = status.Name;
            Code = status.Code;
            DisplayName = status.DisplayName;
        }

        /// <summary>
        /// Creates a new AccountStatus (for internal use only; used by the CreateInstance method to support the static instances).
        /// </summary>
        /// <param name="id">The Id of the AccountStatus.</param>
        /// <param name="name">The name of the AccountStatus.</param>
        /// <param name="code">The standard code that represents this AccountStatus.</param>
        /// <param name="displayName">The name that should be used when displaying this AccountStatus as a title.</param>
        internal AccountStatus(int id, string name, string code, string displayName)
        {
            name.NotNull().NotEmpty();

            Id = id;
            Name = name;
            Code = code ?? name[0].ToString().ToUpper();
            DisplayName = displayName ?? name;
        }

        /// <summary>
        /// The ID of the dimension.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the dimension.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The standard code that represents the dimension.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the dimension as a title.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Parses a string to an AccountStatus.
        /// </summary>
        /// <param name="accountStatus">A string representation of the AccountStatus.</param>
        /// <returns>A new instance of an AccountStatus.</returns>
        public static AccountStatus Parse(string accountStatus)
        {
            switch (accountStatus.Scrub().ToUpper())
            {
                case "CAN":
                case "CANCELED":
                    return Canceled;
                case "CLO":
                case "CLOSED":
                    return Closed;
                case "DPE":
                case "DROPPENDING":
                    return DropPending;
                case "DUP":
                case "DUPLICATE":
                    return Duplicate;
                case "OFF":
                case "OFFFLOW":
                    return OffFlow;
                case "ONF":
                case "ONFLOW":
                    return OnFlow;
                case "PEN":
                case "PEND":
                case "PENDING":
                    return Pending;
                case "QUE":
                case "QUEUED":
                    return Queued;
                case "REJ":
                case "REJECTED":
                    return Rejected;
                case "SCH":
                case "SCHEDULED":
                    return Scheduled;
                case "SUB":
                case "SUBMITTED":
                    return Submitted;
                default:
                    return Unrecognized;
            }
        }

        /// <summary>
        /// Attempts to parse a string to an AccountStatus.
        /// </summary>
        /// <param name="accountStatus">The account status.</param>
        /// <param name="instance">If the parse operation succeeds, a new instance of an AccountStatus will be output.</param>
        /// <returns><c>true</c> if the parse operation succeeds; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string accountStatus, out AccountStatus instance)
        {
            instance = Parse(accountStatus);

            return instance != Unrecognized;
        }

        /// <summary>
        /// This is used to construct the static instances.
        /// </summary>
        /// <param name="name">The name of the AccountStatus.</param>
        /// <param name="id">The Id of the AccountStatus.</param>
        /// <param name="code">The standard code that represents the AccountStatus.</param>
        /// <param name="displayName">The name that should be used when displaying the AccountStatus as a title.</param>
        internal static AccountStatus CreateInstance(string name, int id = 0, string code = null, string displayName = null)
        {
            name.NotNull().NotEmpty();

            return new AccountStatus(id, name, code, displayName);
        }

        /// <summary>Returns the name property for this instance.</summary>
        /// <returns>The name property for this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Overload the implicit cast operator so that when an AccountStatus is cast to an int, the Id is returned.
        /// </summary>
        /// <param name="accountStatus">An instance of an AccountStatus</param>
        public static implicit operator int(AccountStatus accountStatus) => accountStatus.Id;

        /// <summary>
        /// Overload of the == operator to support comparing two AccountStatuses.
        /// </summary>
        /// <param name="left">The AccountStatus on the left side of the equation.</param>
        /// <param name="right">The AccountStatus on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountStatuses are equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator ==(AccountStatus left, AccountStatus right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overload of the != operator to support comparing two AccountStatuses.
        /// </summary>
        /// <param name="left">The AccountStatus on the left side of the equation.</param>
        /// <param name="right">The AccountStatus on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountStatuses are not equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator !=(AccountStatus left, AccountStatus right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Overload of the == operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The AccountStatus on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountStatus is equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator ==(AccountStatus left, string right)
        {
            return left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The AccountStatus on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountStatuses are not equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator !=(AccountStatus left, string right)
        {
            return !left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the == operator to support comparing a string to an AccountStatus.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The AccountStatus on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is equivalent to the AccountStatus; otherwise, <c>false</c>.</returns>
        public static bool operator ==(string left, AccountStatus right)
        {
            return right.Equals(Parse(left));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a string to a AccountStatus.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The AccountStatus on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is not equivalent to the AccountStatus; otherwise, <c>false</c>.</returns>
        public static bool operator !=(string left, AccountStatus right)
        {
            return !right.Equals(Parse(left));
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(AccountStatus other)
        {
            return Id == other.Id && Name == other.Name && Code == other.Code && DisplayName == other.DisplayName;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            return obj is AccountStatus other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Code, DisplayName);
        }
    }
}
