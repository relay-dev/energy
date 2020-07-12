using System;

namespace Energy.Extensions
{
    internal static class ObjectExtensions
    {
        internal static string NotNull(this string s)
        {
            if (s == null)
            {
                throw new ArgumentException("The string used to initialize the energy dimension type cannot be null", nameof(s));
            }

            return s;
        }

        internal static string NotEmpty(this string s)
        {
            if (s?.Trim() == string.Empty)
            {
                throw new ArgumentException("The string used to initialize the energy dimension type cannot be empty", nameof(s));
            }

            return s;
        }
    }
}
