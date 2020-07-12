using Energy.Extensions;
using System;

namespace Energy.DataStructures
{
    /// <summary>
    /// The measurement type that should be used when calculating energy usage.
    /// </summary>
    public readonly struct UnitOfMeasure : IEnergyDimension, IEquatable<UnitOfMeasure>
    {
        /// <summary>
        /// Unrecognized value.
        /// </summary>
        public static UnitOfMeasure Unrecognized = UnitOfMeasure.CreateInstance("Unrecognized");

        /// <summary>
        /// Kilowatt-Hour value.
        /// </summary>
        public static UnitOfMeasure kWh = UnitOfMeasure.CreateInstance("Kilowatt-hour", 1, "kWh");

        /// <summary>
        /// Megawatt-hour value.
        /// </summary>
        public static UnitOfMeasure MWh = UnitOfMeasure.CreateInstance("Megawatt-hour", 2, "MWh");

        /// <summary>
        /// Gigawatt-hour value.
        /// </summary>
        public static UnitOfMeasure GWh = UnitOfMeasure.CreateInstance("Gigawatt-hour", 3, "GWh");

        /// <summary>
        /// Therm value.
        /// </summary>
        public static UnitOfMeasure Therm = UnitOfMeasure.CreateInstance("Therm", 4, "Therm", "THR");

        /// <summary>
        /// Decatherm value.
        /// </summary>
        public static UnitOfMeasure Decatherm = UnitOfMeasure.CreateInstance("Decatherm", 5, "Dth");

        /// <summary>
        /// Centum cubic feet value.
        /// </summary>
        public static UnitOfMeasure Ccf = UnitOfMeasure.CreateInstance("Centum cubic feet", 6, "Ccf");

        /// <summary>
        /// 1,000 cubic feet value.
        /// </summary>
        public static UnitOfMeasure Mcf = UnitOfMeasure.CreateInstance("1,000 cubic feet", 7, "Mcf");

        /// <summary>
        /// Creates a new UnitOfMeasure.
        /// </summary>
        /// <param name="unitOfMeasure">A string representation of an UnitOfMeasure.</param>
        public UnitOfMeasure(string unitOfMeasure)
        {
            UnitOfMeasure uom = Parse(unitOfMeasure);

            Id = uom.Id;
            Name = uom.Name;
            Code = uom.Code;
            DisplayName = uom.DisplayName;
            Abbreviation = uom.Abbreviation;
        }

        /// <summary>
        /// Creates a new UnitOfMeasure (for internal use only; used by the CreateInstance method to support the static instances).
        /// </summary>
        /// <param name="id">The Id of the UnitOfMeasure.</param>
        /// <param name="name">The name of the UnitOfMeasure.</param>
        /// <param name="code">The standard code that represents this UnitOfMeasure.</param>
        /// <param name="displayName">The name that should be used when displaying this UnitOfMeasure as a title.</param>
        /// <param name="abbreviation">The abbreviation version of this UnitOfMeasure (kWh, Ccf, etc.).</param>
        internal UnitOfMeasure(int id, string name, string code, string displayName, string abbreviation)
        {
            name.NotNull().NotEmpty();

            Id = id;
            Name = name;
            Code = code ?? abbreviation?.ToUpper() ?? name[0].ToString().ToUpper();
            DisplayName = displayName ?? name;
            Abbreviation = abbreviation ?? name[0].ToString().ToUpper();
        }

        /// <summary>
        /// The ID of the UnitOfMeasure.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the UnitOfMeasure.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The standard code that represents the UnitOfMeasure.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The name that should be used when displaying the UnitOfMeasure as a title.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// The abbreviation version of this UnitOfMeasure (kWh, CCF, etc.).
        /// </summary>
        public string Abbreviation { get; }

        /// <summary>
        /// Parses a string to an UnitOfMeasure.
        /// </summary>
        /// <param name="unitOfMeasure">A string representation of the UnitOfMeasure.</param>
        /// <returns>A new instance of an UnitOfMeasure.</returns>
        public static UnitOfMeasure Parse(string unitOfMeasure)
        {
            switch (unitOfMeasure.Scrub().ToUpper())
            {
                case "KW":
                case "KWH":
                case "KILOWATT":
                case "KILOWATTS":
                case "KILOWATTHOUR":
                case "KILOWATTHOURS":
                    return kWh;
                case "MW":
                case "MWH":
                case "MEGAWATT":
                case "MEGAWATTS":
                case "MEGAWATTHOUR":
                case "MEGAWATTHOURS":
                    return MWh;
                case "GW":
                case "GWH":
                case "GIGAWATT":
                case "GIGAWATTS":
                case "GIGAWATTHOUR":
                case "GIGAWATTHOURS":
                    return GWh;
                case "T":
                case "TH":
                case "THER":
                case "THERM":
                case "THERMS":
                    return Therm;
                case "DEC":
                case "DTH":
                case "DECA":
                case "DECATHERM":
                case "DECATHERMS":
                    return Decatherm;
                case "CCF":
                case "CENTUM":
                case "CENTUMS":
                case "CENTUMCUBIC":
                case "CENTUMCUBICS":
                case "CENTUMCUBICFEET":
                    return Ccf;
                case "MCF":
                    return Mcf;
                default:
                    return Unrecognized;
            }
        }

        /// <summary>
        /// Attempts to parse a string to an UnitOfMeasure.
        /// </summary>
        /// <param name="unitOfMeasure">The unit of measure.</param>
        /// <param name="instance">If the parse operation succeeds, a new instance of an UnitOfMeasure will be output.</param>
        /// <returns><c>true</c> if the parse operation succeeds; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string unitOfMeasure, out UnitOfMeasure instance)
        {
            instance = Parse(unitOfMeasure);

            return instance != Unrecognized;
        }

        /// <summary>
        /// This is used to construct the static instances.
        /// </summary>
        /// <param name="name">The name of the UnitOfMeasure.</param>
        /// <param name="id">The Id of the UnitOfMeasure.</param>
        /// <param name="abbreviation">The abbreviation version of this UnitOfMeasure (kWh, CCF, etc.).</param>
        /// <param name="code">The standard code that represents the UnitOfMeasure.</param>
        /// <param name="displayName">The name that should be used when displaying the UnitOfMeasure as a title.</param>
        internal static UnitOfMeasure CreateInstance(string name, int id = 0, string abbreviation = null, string code = null, string displayName = null)
        {
            name.NotNull().NotEmpty();

            return new UnitOfMeasure(id, name, code, displayName, abbreviation);
        }

        /// <summary>Returns the name property for this instance.</summary>
        /// <returns>The name property for this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Overload the implicit cast operator so that when an UnitOfMeasure is cast to an int, the Id is returned.
        /// </summary>
        /// <param name="unitOfMeasure">An instance of an UnitOfMeasure</param>
        public static implicit operator int(UnitOfMeasure unitOfMeasure) => unitOfMeasure.Id;

        /// <summary>
        /// Overload of the == operator to support comparing two UnitOfMeasures.
        /// </summary>
        /// <param name="left">The UnitOfMeasure on the left side of the equation.</param>
        /// <param name="right">The UnitOfMeasure on the right side of the equation.</param>
        /// <returns><c>true</c> if the given UnitOfMeasures are equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator ==(UnitOfMeasure left, UnitOfMeasure right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overload of the != operator to support comparing two UnitOfMeasures.
        /// </summary>
        /// <param name="left">The UnitOfMeasure on the left side of the equation.</param>
        /// <param name="right">The UnitOfMeasure on the right side of the equation.</param>
        /// <returns><c>true</c> if the given UnitOfMeasures are not equivalent; otherwise, <c>false</c>.</returns>
        public static bool operator !=(UnitOfMeasure left, UnitOfMeasure right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Overload of the == operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The UnitOfMeasure on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given UnitOfMeasure is equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator ==(UnitOfMeasure left, string right)
        {
            return left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a dimension instance to a string.
        /// </summary>
        /// <param name="left">The UnitOfMeasure on the left side of the equation.</param>
        /// <param name="right">The string on the right side of the equation.</param>
        /// <returns><c>true</c> if the given UnitOfMeasures are not equivalent to the string; otherwise, <c>false</c>.</returns>
        public static bool operator !=(UnitOfMeasure left, string right)
        {
            return !left.Equals(Parse(right));
        }

        /// <summary>
        /// Overload of the == operator to support comparing a string to an UnitOfMeasure.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The UnitOfMeasure on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is equivalent to the UnitOfMeasure; otherwise, <c>false</c>.</returns>
        public static bool operator ==(string left, UnitOfMeasure right)
        {
            return right.Equals(Parse(left));
        }

        /// <summary>
        /// Overload of the != operator to support comparing a string to a UnitOfMeasure.
        /// </summary>
        /// <param name="left">The string on the left side of the equation.</param>
        /// <param name="right">The UnitOfMeasure on the right side of the equation.</param>
        /// <returns><c>true</c> if the given string is not equivalent to the UnitOfMeasure; otherwise, <c>false</c>.</returns>
        public static bool operator !=(string left, UnitOfMeasure right)
        {
            return !right.Equals(Parse(left));
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(UnitOfMeasure other)
        {
            return Id == other.Id && Name == other.Name && Code == other.Code && DisplayName == other.DisplayName && Abbreviation == other.Abbreviation;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            return obj is UnitOfMeasure other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Code, DisplayName);
        }
    }
}
