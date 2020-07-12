using System;
using Energy.Extensions;

namespace Energy.DataStructures
{
    /// <summary>
    /// The classification of an energy account.
    /// </summary>
    public readonly struct AccountClass : IEnergyDimension, IEquatable<AccountClass>
    {
        /// <summary>
        /// Unrecognized value.
        /// </summary>
        public static AccountClass Unrecognized = AccountClass.CreateInstance("Unrecognized");

        /// <summary>
        /// Residential value.
        /// </summary>
        public static AccountClass Residential = AccountClass.CreateInstance("Residential", 1);

        /// <summary>
        /// Small Commercial value.
        /// </summary>
        public static AccountClass SmallCommercial = AccountClass.CreateInstance("Small Commercial", 2, "SC");

        /// <summary>
        /// Large Commercial value.
        /// </summary>
        public static AccountClass LargeCommercial = AccountClass.CreateInstance("Large Commercial", 3, "LC");

        /// <summary>
        /// Creates a new AccountClass.
        /// </summary>
        /// <param name="accountClass">A string representation of an AccountClass.</param>
        public AccountClass(string accountClass)
        {
            AccountClass a = Parse(accountClass);

            Id = a.Id;
            Name = a.Name;
            Code = a.Code;
            DisplayName = a.DisplayName;
        }

        /// <summary>
        /// Creates a new AccountClass (for internal use only; used by the CreateInstance method to support the static instances).
        /// </summary>
        /// <param name="id">The Id of the AccountClass.</param>
        /// <param name="name">The name of the AccountClass.</param>
        /// <param name="code">The standard code that represents this AccountClass.</param>
        /// <param name="displayName">The name that should be used when displaying this AccountClass as a title.</param>
        internal AccountClass(int id, string name, string code, string displayName)
        {
            name.NotNull().NotEmpty();

            Id = id;
            Name = name;
            Code = code ?? name[0].ToString().ToUpper();
            DisplayName = displayName ?? name;
        }

        /// <summary>
        /// The ID of the AccountClass.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the AccountClass.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The standard code that represents the AccountClass.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the AccountClass as a title.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Parses a string to an AccountClass.
        /// </summary>
        /// <param name="accountClass">A string representation of the AccountClass.</param>
        /// <returns>A new instance of an AccountClass.</returns>
        public static AccountClass Parse(string accountClass)
        {
            switch (accountClass.Scrub().ToUpper())
            {
                case "R":
                case "RES":
                case "RESI":
                case "RESIDENCE":
                case "RESIDENTIAL":
                    return Residential;
                case "SC":
                case "SCOM":
                case "SCOMM":
                case "SMALLCOM":
                case "SMALLCOMM":
                case "SMALLCOMMERCIAL":
                    return SmallCommercial;
                case "LC":
                case "LCOM":
                case "LCOMM":
                case "LARGECOM":
                case "LARGECOMM":
                case "LARGECOMMERCIAL":
                    return LargeCommercial;
                default:
                    return Unrecognized;
            }
        }

        /// <summary>
        /// Attempts to parse a string to an AccountClass.
        /// </summary>
        /// <param name="accountClass">The account class.</param>
        /// <param name="instance">If the parse operation succeeds, a new instance of an AccountClass will be output.</param>
        /// <returns><c>true</c> if the parse operation succeeds; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string accountClass, out AccountClass instance)
        {
            instance = Parse(accountClass);

            return instance != Unrecognized;
        }

        /// <summary>
        /// This is used to construct the static instances.
        /// </summary>
        /// <param name="name">The name of the AccountClass.</param>
        /// <param name="id">The Id of the AccountClass.</param>
        /// <param name="code">The standard code that represents the AccountClass.</param>
        /// <param name="displayName">The name that should be used when displaying the AccountClass as a title.</param>
        internal static AccountClass CreateInstance(string name, int id = 0, string code = null, string displayName = null)
        {
            name.NotNull().NotEmpty();

            return new AccountClass(id, name, code, displayName);
        }

        /// <summary>Returns the fully qualified type name of this instance.</summary>
        /// <returns>The fully qualified type name.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Overload the implicit cast operator so that when an AccountClass is cast to an int, the Id is returned.
        /// </summary>
        /// <param name="accountClass">An instance of an AccountClass</param>
        public static implicit operator int(AccountClass accountClass) => accountClass.Id;

        /// <summary>
        /// Overload of the == operator to support comparing two AccountClasses.
        /// </summary>
        /// <param name="left">The AccountClass on the left side of the equation.</param>
        /// <param name="right">The AccountClass on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountClasses are equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator ==(AccountClass left, AccountClass right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overload of the != operator to support comparing two AccountClasses.
        /// </summary>
        /// <param name="left">The AccountClass on the left side of the equation.</param>
        /// <param name="right">The AccountClass on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountClasses are not equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator !=(AccountClass left, AccountClass right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Overload of the == operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The AccountClass on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountClass is equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator ==(AccountClass left, string right)
        {
            return left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The AccountClass on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given AccountClasses are not equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator !=(AccountClass left, string right)
        {
            return !left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the == operator to support comparing a string to an AccountClass.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The AccountClass on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is equivalent to the AccountClass; otherwise, <c>false</c>.</returns>
        public static bool operator ==(string left, AccountClass right)
        {
            return right.Equals(Parse(left));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a string to a AccountClass.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The AccountClass on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is not equivalent to the AccountClass; otherwise, <c>false</c>.</returns>
        public static bool operator !=(string left, AccountClass right)
        {
            return !right.Equals(Parse(left));
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(AccountClass other)
        {
            return Name == other.Name && Code == other.Code && DisplayName == other.DisplayName;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            return obj is AccountClass other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Code, DisplayName);
        }
    }
}
