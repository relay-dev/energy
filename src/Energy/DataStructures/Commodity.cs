using System;
using Energy.Extensions;

namespace Energy.DataStructures
{
    /// <summary>
    /// The type of energy for a given account.
    /// </summary>
    public readonly struct Commodity : IEnergyDimension, IEquatable<Commodity>
    {
        /// <summary>
        /// Unrecognized value.
        /// </summary>
        public static Commodity Unrecognized = Commodity.CreateInstance("Unrecognized");

        /// <summary>
        /// Electric value.
        /// </summary>
        public static Commodity Electric = Commodity.CreateInstance("Electric", 1);

        /// <summary>
        /// Gas value.
        /// </summary>
        public static Commodity Gas = Commodity.CreateInstance("Gas", 2);

        /// <summary>
        /// Solar value.
        /// </summary>
        public static Commodity Solar = Commodity.CreateInstance("Solar", 3);

        /// <summary>
        /// Creates a new Commodity.
        /// </summary>
        /// <param name="commodity">A string representation of a Commodity.</param>
        public Commodity(string commodity)
        {
            Commodity c = Parse(commodity);

            Id = c.Id;
            Name = c.Name;
            Code = c.Code;
            DisplayName = c.DisplayName;
        }

        /// <summary>
        /// Creates a new Commodity (for internal use only; used by the CreateInstance method to support the static instances).
        /// </summary>
        /// <param name="id">The Id of the Commodity.</param>
        /// <param name="name">The name of the Commodity.</param>
        /// <param name="code">The standard code that represents the Commodity.</param>
        /// <param name="displayName">The name that should be used when displaying the Commodity as a title.</param>
        internal Commodity(int id, string name, string code, string displayName)
        {
            name.NotNull().NotEmpty();

            Id = id;
            Name = name;
            Code = code ?? name[0].ToString().ToUpper();
            DisplayName = displayName ?? name;
        }

        /// <summary>
        /// The ID of the Commodity.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the Commodity.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The standard code that represents the Commodity.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the Commodity as a title.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Parses a string to a Commodity.
        /// </summary>
        /// <param name="commodity">A string representation of the Commodity.</param>
        /// <returns>A new instance of an Commodity.</returns>
        public static Commodity Parse(string commodity)
        {
            switch (commodity.Scrub().ToUpper())
            {
                case "E":
                case "EL":
                case "ELE":
                case "ELEC":
                case "ELECTRIC":
                case "ELECTRICITY":
                    return Electric;
                case "G":
                case "GA":
                case "GAS":
                    return Gas;
                case "S":
                case "SO":
                case "SOL":
                case "SOLAR":
                    return Solar;
                default:
                    return Unrecognized;
            }
        }

        /// <summary>
        /// Attempts to parse a string to a Commodity.
        /// </summary>
        /// <param name="accountClass">The commodity.</param>
        /// <param name="instance">If the parse operation succeeds, a new instance of an Commodity will be output.</param>
        /// <returns><c>true</c> if the parse operation succeeds; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string accountClass, out Commodity instance)
        {
            instance = Parse(accountClass);

            return instance != Unrecognized;
        }

        /// <summary>
        /// This is used to construct the static instances.
        /// </summary>
        /// <param name="name">The name of the Commodity.</param>
        /// <param name="id">The Id of the Commodity.</param>
        /// <param name="code">The standard code that represents the Commodity.</param>
        /// <param name="displayName">The name that should be used when displaying the Commodity as a title.</param>
        internal static Commodity CreateInstance(string name, int id = 0, string code = null, string displayName = null)
        {
            name.NotNull().NotEmpty();

            return new Commodity(id, name, code, displayName);
        }

        /// <summary>Returns the name property for this instance.</summary>
        /// <returns>The name property for this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Overload the implicit cast operator so that when an AccountClass is cast to an int, the Id is returned.
        /// </summary>
        /// <param name="commodity">An instance of a Commodity</param>
        public static implicit operator int(Commodity commodity) => commodity.Id;

        /// <summary>
        /// Overload of the == operator to support comparing two Commodities.
        /// </summary>
        /// <param name="left">The Commodity on the left side of the equation.</param>
        /// <param name="right">The Commodity on the right side of the equation.</param>
        /// <returns><c>true</c> if the given Commodity are equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Commodity left, Commodity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overload of the != operator to support comparing two Commodities.
        /// </summary>
        /// <param name="left">The Commodity on the left side of the equation.</param>
        /// <param name="right">The Commodity on the right side of the equation.</param>
        /// <returns><c>true</c> if the given Commodities are not equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Commodity left, Commodity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Overload of the == operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The Commodity on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given Commodity is equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Commodity left, string right)
        {
            return left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The Commodity on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given Commodities are not equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Commodity left, string right)
        {
            return !left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the == operator to support comparing a string to an Commodity.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The Commodity on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is equivalent to the Commodity; otherwise, <c>false</c>.</returns>
        public static bool operator ==(string left, Commodity right)
        {
            return right.Equals(Parse(left));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a string to a Commodity.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The Commodity on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is not equivalent to the Commodity; otherwise, <c>false</c>.</returns>
        public static bool operator !=(string left, Commodity right)
        {
            return !right.Equals(Parse(left));
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(Commodity other)
        {
            return Name == other.Name && Code == other.Code && DisplayName == other.DisplayName;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            return obj is Commodity other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Code, DisplayName);
        }
    }
}
