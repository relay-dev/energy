using Consolater;
using System;

namespace Energy.Samples
{
    /// <remarks>
    /// For the sake of a clear and consistent set of examples, most of the sample methods below demonstrate only how to use the AccountClass dimension.
    /// All other dimensions work very similarly. A sample method with all dimensions available in this library is available towards the end of this class.
    /// </remarks>
    [ConsoleAppMenuItem]
    public class DataStructureSamples : Sample
    {
        /// <notes>
        /// Each dimension contains everything needed to parse an input string and return it's standardized constituents.
        /// </notes>
        [ConsoleAppSelection(Key = "1")]
        public void StandardizedFieldsAreExposedForInstances()
        {
            var accountClass = new AccountClass("Residential");

            Console.WriteLine(accountClass.Name);
            Console.WriteLine(accountClass.Code);
            Console.WriteLine(accountClass.DisplayName);
        }

        /// <notes>
        /// Each dimension will sensibly parse the input string to account for variations in representation from different vendors.
        /// </notes>
        [ConsoleAppSelection(Key = "2")]
        public void InterpretationIsFlexibleForInputStrings()
        {
            var accountClass1 = new AccountClass("R");
            var accountClass2 = new AccountClass("res");
            var accountClass3 = new AccountClass("Resi");
            var accountClass4 = new AccountClass("resi.");

            Console.WriteLine(accountClass1.Name);
            Console.WriteLine(accountClass2.Name);
            Console.WriteLine(accountClass3.Name);
            Console.WriteLine(accountClass4.Name);
        }

        /// <notes>
        /// Each dimension exposes static instances for quick comparison and assignment.
        /// </notes>
        [ConsoleAppSelection(Key = "3")]
        public void StaticValuesRepresentValidValues()
        {
            AccountClass accountClassResidential = AccountClass.Residential;
            AccountClass accountClassSmallCommercial = AccountClass.SmallCommercial;
            AccountClass accountClassLargeCommercial = AccountClass.LargeCommercial;

            Console.WriteLine(accountClassResidential.Name);
            Console.WriteLine(accountClassSmallCommercial.Name);
            Console.WriteLine(accountClassLargeCommercial.Name);
        }

        /// <notes>
        /// Each dimension can be compared for equality.
        /// </notes>
        [ConsoleAppSelection(Key = "4")]
        public void CompareForEquality()
        {
            AccountClass accountClassResidential1 = new AccountClass("Residential");
            AccountClass accountClassResidential2 = new AccountClass("Residential");
            AccountClass accountClassSmallCommercial = new AccountClass("Small Commercial");

            bool isResidentialResidentialEquivalent = (accountClassResidential1 == accountClassResidential2);
            bool isResidentialSmallCommercialEquivalent = (accountClassResidential1 == accountClassSmallCommercial);

            Console.WriteLine("Is Residential Residential equivalent?: {0}", isResidentialResidentialEquivalent);
            Console.WriteLine("Is Residential SmallCommercial equivalent?: {0}", isResidentialSmallCommercialEquivalent);
        }

        /// <notes>
        /// Each dimension can also be compared for equality using strings.
        /// </notes>
        [ConsoleAppSelection(Key = "5")]
        public void CompareForEqualityFromStrings()
        {
            AccountClass accountClassResidential1 = new AccountClass("Residential");
            AccountClass accountClassResidential2 = new AccountClass("Residential");
            AccountClass accountClassSmallCommercial = new AccountClass("Small Commercial");

            bool isResidentialResidentialEquivalent = (accountClassResidential1 == "Residential");
            bool isResidentialSmallCommercialEquivalent = (accountClassResidential2 == "Small Commercial");
            bool isSmallCommercialSmallCommercialAbbreviationEquivalent = (accountClassSmallCommercial == "SC");

            Console.WriteLine("Is Residential Residential equivalent?: {0}", isResidentialResidentialEquivalent);
            Console.WriteLine("Is Residential SmallCommercial equivalent?: {0}", isResidentialSmallCommercialEquivalent);
            Console.WriteLine("Is SmallCommercial SmallCommercial equivalent?: {0}", isSmallCommercialSmallCommercialAbbreviationEquivalent);
        }
    }
}
