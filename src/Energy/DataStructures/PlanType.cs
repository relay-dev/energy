using Energy.Extensions;
using System;

namespace Energy.DataStructures
{
    /// <summary>
    /// A description of how the energy account charges are issued during the term of the contract.
    /// </summary>
    public readonly struct PlanType : IEnergyDimension, IEquatable<PlanType>
    {
        /// <summary>
        /// Unrecognized value.
        /// </summary>
        public static PlanType Unrecognized = PlanType.CreateInstance("Unrecognized");

        /// <summary>
        /// Fixed value.
        /// </summary>
        public static PlanType Fixed = PlanType.CreateInstance("Fixed", 1, "FIX");

        /// <summary>
        /// Variable value.
        /// </summary>
        public static PlanType Variable = PlanType.CreateInstance("Variable", 2, "VAR");

        /// <summary>
        /// Fixed value.
        /// </summary>
        public static PlanType Indexed = PlanType.CreateInstance("Indexed", 3, "IDX");

        /// <summary>
        /// Creates a new PlanType.
        /// </summary>
        /// <param name="planType">A string representation of an PlanType.</param>
        public PlanType(string planType)
        {
            PlanType tt = Parse(planType);

            Id = tt.Id;
            Name = tt.Name;
            Code = tt.Code;
            DisplayName = tt.DisplayName;
        }

        /// <summary>
        /// Creates a new PlanType (for internal use only; used by the CreateInstance method to support the static instances).
        /// </summary>
        /// <param name="id">The Id of the PlanType.</param>
        /// <param name="name">The name of the PlanType.</param>
        /// <param name="code">The standard code that represents this PlanType.</param>
        /// <param name="displayName">The name that should be used when displaying this PlanType as a title.</param>
        internal PlanType(int id, string name, string code, string displayName)
        {
            name.NotNull().NotEmpty();

            Id = id;
            Name = name;
            Code = code ?? name[0].ToString().ToUpper();
            DisplayName = displayName ?? name;
        }

        /// <summary>
        /// The ID of the PlanType.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the PlanType.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The standard code that represents the PlanType.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the PlanType as a title.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Parses a string to an PlanType.
        /// </summary>
        /// <param name="planType">A string representation of the PlanType.</param>
        /// <returns>A new instance of an PlanType.</returns>
        public static PlanType Parse(string planType)
        {
            switch (planType.Scrub().ToUpper())
            {
                case "F":
                case "FIX":
                case "FIXED":
                    return Fixed;
                case "V":
                case "VAR":
                case "VARIABLE":
                    return Variable;
                case "I":
                case "IDX":
                case "IND":
                case "INDEX":
                case "INDEXED":
                    return Indexed;
                default:
                    return Unrecognized;
            }
        }

        /// <summary>
        /// Attempts to parse a string to an PlanType.
        /// </summary>
        /// <param name="planType">The term type.</param>
        /// <param name="instance">If the parse operation succeeds, a new instance of an PlanType will be output.</param>
        /// <returns><c>true</c> if the parse operation succeeds; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string planType, out PlanType instance)
        {
            instance = Parse(planType);

            return instance != Unrecognized;
        }

        /// <summary>
        /// This is used to construct the static instances.
        /// </summary>
        /// <param name="name">The name of the PlanType.</param>
        /// <param name="id">The Id of the PlanType.</param>
        /// <param name="code">The standard code that represents the PlanType.</param>
        /// <param name="displayName">The name that should be used when displaying the PlanType as a title.</param>
        internal static PlanType CreateInstance(string name, int id = 0, string code = null, string displayName = null)
        {
            name.NotNull().NotEmpty();

            return new PlanType(id, name, code, displayName);
        }

        /// <summary>Returns the fully qualified type name of this instance.</summary>
        /// <returns>The fully qualified type name.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Overload the implicit cast operator so that when an PlanType is cast to an int, the Id is returned.
        /// </summary>
        /// <param name="planType">An instance of an PlanType</param>
        public static implicit operator int(PlanType planType) => planType.Id;

        /// <summary>
        /// Overload of the == operator to support comparing two PlanTypes.
        /// </summary>
        /// <param name="left">The PlanType on the left side of the equation.</param>
        /// <param name="right">The PlanType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given PlanTypes are equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PlanType left, PlanType right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overload of the != operator to support comparing two PlanTypes.
        /// </summary>
        /// <param name="left">The PlanType on the left side of the equation.</param>
        /// <param name="right">The PlanType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given PlanTypes are not equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PlanType left, PlanType right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Overload of the == operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The PlanType on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given PlanType is equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PlanType left, string right)
        {
            return left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The PlanType on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given PlanTypes are not equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PlanType left, string right)
        {
            return !left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the == operator to support comparing a string to an PlanType.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The PlanType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is equivalent to the PlanType; otherwise, <c>false</c>.</returns>
        public static bool operator ==(string left, PlanType right)
        {
            return right.Equals(Parse(left));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a string to a PlanType.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The PlanType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is not equivalent to the PlanType; otherwise, <c>false</c>.</returns>
        public static bool operator !=(string left, PlanType right)
        {
            return !right.Equals(Parse(left));
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(PlanType other)
        {
            return Id == other.Id && Name == other.Name && Code == other.Code && DisplayName == other.DisplayName;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            return obj is PlanType other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Code, DisplayName);
        }
    }
}
