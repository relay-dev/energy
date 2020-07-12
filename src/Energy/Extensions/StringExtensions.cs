using System.Linq;
using System.Text.RegularExpressions;

namespace Energy.Extensions
{
    internal static class StringExtensions
    {
        internal static string Scrub(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Trim();

                if (HasNonAlphaCharacters(s))
                {
                    s = Regex.Replace(s, "[^A-Za-z-]", string.Empty);
                }
            }

            return s ?? string.Empty;
        }

        private static bool HasNonAlphaCharacters(string s)
        {
            return s.Any(c => !char.IsLetter(c));
        }
    }
}
