using Energy.Extensions;
using System;

namespace Energy
{
    /// <summary>
    /// A description of the way an energy account rate is intended to be offered.
    /// </summary>
    public readonly struct RateType : IEnergyDimension, IEquatable<RateType>
    {
        /// <summary>
        /// Unrecognized value.
        /// </summary>
        public static RateType Unrecognized = RateType.CreateInstance("Unrecognized");

        /// <summary>
        /// Enrollment value.
        /// </summary>
        public static RateType Enrollment = RateType.CreateInstance("Enrollment", 1, "ENR");

        /// <summary>
        /// Switch value.
        /// </summary>
        public static RateType Switch = RateType.CreateInstance("Switch", 2, "SWI");

        /// <summary>
        /// Renewal value.
        /// </summary>
        public static RateType Renewal = RateType.CreateInstance("Renewal", 3, "REN");

        /// <summary>
        /// Intro value.
        /// </summary>
        public static RateType Intro = RateType.CreateInstance("Intro", 4, "INT");

        /// <summary>
        /// Winback value.
        /// </summary>
        public static RateType Winback = RateType.CreateInstance("Winback", 5, "WIN");

        /// <summary>
        /// Creates a new RateType.
        /// </summary>
        /// <param name="rateType">A string representation of an RateType.</param>
        public RateType(string rateType)
        {
            RateType rt = Parse(rateType);

            Id = rt.Id;
            Name = rt.Name;
            Code = rt.Code;
            DisplayName = rt.DisplayName;
        }

        /// <summary>
        /// Creates a new RateType (for internal use only; used by the CreateInstance method to support the static instances).
        /// </summary>
        /// <param name="id">The Id of the RateType.</param>
        /// <param name="name">The name of the RateType.</param>
        /// <param name="code">The standard code that represents this RateType.</param>
        /// <param name="displayName">The name that should be used when displaying this RateType as a title.</param>
        internal RateType(int id, string name, string code, string displayName)
        {
            name.NotNull().NotEmpty();

            Id = id;
            Name = name;
            Code = code ?? name[0].ToString().ToUpper();
            DisplayName = displayName ?? name;
        }

        /// <summary>
        /// The ID of the RateType.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the RateType.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The standard code that represents the RateType.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the RateType as a title.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Parses a string to an RateType.
        /// </summary>
        /// <param name="rateType">A string representation of the RateType.</param>
        /// <returns>A new instance of an RateType.</returns>
        public static RateType Parse(string rateType)
        {
            switch (rateType.Scrub().ToUpper())
            {
                case "E":
                case "ENR":
                case "ENROLL":
                case "ENROLLMENT":
                    return Enrollment;
                case "S":
                case "SWI":
                case "SWITCH":
                    return Switch;
                case "R":
                case "REN":
                case "RENEW":
                case "RENEWAL":
                    return Renewal;
                case "I":
                case "INT":
                case "INTRO":
                case "INTRODUCTION":
                case "INTRODUCTORY":
                    return Intro;
                case "W":
                case "WIN":
                case "WINBACK":
                    return Winback;
                default:
                    return Unrecognized;
            }
        }

        /// <summary>
        /// Attempts to parse a string to an RateType.
        /// </summary>
        /// <param name="rateType">The rate type.</param>
        /// <param name="instance">If the parse operation succeeds, a new instance of an RateType will be output.</param>
        /// <returns><c>true</c> if the parse operation succeeds; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string rateType, out RateType instance)
        {
            instance = Parse(rateType);

            return instance != Unrecognized;
        }

        /// <summary>
        /// This is used to construct the static instances.
        /// </summary>
        /// <param name="name">The name of the RateType.</param>
        /// <param name="id">The Id of the RateType.</param>
        /// <param name="code">The standard code that represents the RateType.</param>
        /// <param name="displayName">The name that should be used when displaying the RateType as a title.</param>
        internal static RateType CreateInstance(string name, int id = 0, string code = null, string displayName = null)
        {
            name.NotNull().NotEmpty();

            return new RateType(id, name, code, displayName);
        }

        /// <summary>Returns the name property for this instance.</summary>
        /// <returns>The name property for this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Overload the implicit cast operator so that when an RateType is cast to an int, the Id is returned.
        /// </summary>
        /// <param name="rateType">An instance of an RateType</param>
        public static implicit operator int(RateType rateType) => rateType.Id;

        /// <summary>
        /// Overload of the == operator to support comparing two RateTypes.
        /// </summary>
        /// <param name="left">The RateType on the left side of the equation.</param>
        /// <param name="right">The RateType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given RateTypes are equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RateType left, RateType right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overload of the != operator to support comparing two RateTypes.
        /// </summary>
        /// <param name="left">The RateType on the left side of the equation.</param>
        /// <param name="right">The RateType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given RateTypes are not equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RateType left, RateType right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Overload of the == operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The RateType on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given RateType is equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RateType left, string right)
        {
            return left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The RateType on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given RateTypes are not equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RateType left, string right)
        {
            return !left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the == operator to support comparing a string to an RateType.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The RateType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is equivalent to the RateType; otherwise, <c>false</c>.</returns>
        public static bool operator ==(string left, RateType right)
        {
            return right.Equals(Parse(left));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a string to a RateType.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The RateType on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is not equivalent to the RateType; otherwise, <c>false</c>.</returns>
        public static bool operator !=(string left, RateType right)
        {
            return !right.Equals(Parse(left));
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(RateType other)
        {
            return Id == other.Id && Name == other.Name && Code == other.Code && DisplayName == other.DisplayName;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            return obj is RateType other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Code, DisplayName);
        }
    }
}
