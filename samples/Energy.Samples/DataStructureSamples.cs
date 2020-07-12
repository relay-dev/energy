using Energy.DataStructures;
using Sampler.ConsoleApplication;
using System;

namespace Energy.Samples
{
    /// <remarks>
    /// For the sake of a clear and consistent set of examples, most of the sample methods below demonstrate only how to use the AccountClass dimension.
    /// All other dimensions work very similarly. A sample method with all dimensions available in this library is available towards the end of this class.
    /// </remarks>
    [SampleFixture]
    public class DataStructureSamples : Sample
    {
        /// <notes>
        /// Each dimension contains everything needed to parse an input string and return it's standardized constituents.
        /// </notes>
        [Sample(Key = "1")]
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
        [Sample(Key = "2")]
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
        [Sample(Key = "3")]
        public void StaticValuesRepresentValidValues()
        {
            string accountClassString = "Large Commercial";

            bool isLargeCommercial = (accountClassString == AccountClass.LargeCommercial);
            AccountClass localAccountClass = AccountClass.SmallCommercial;

            Console.WriteLine("Is Large Commercial: {0}", isLargeCommercial);
            Console.WriteLine("Local Account Class: {0}", localAccountClass.Name);
        }

        /// <notes>
        /// Each dimension can be compared for equality.
        /// </notes>
        [Sample(Key = "4")]
        public void CompareForEquality()
        {
            bool areResidentialInstancesEquivalent = (new AccountClass("Residential") == new AccountClass("Residential"));
            bool areResidentialSmallCommercialInstancesEquivalent = (new AccountClass("Residential") == new AccountClass("Small Commercial"));

            Console.WriteLine("Are Residential instances equivalent?: {0}", areResidentialInstancesEquivalent);
            Console.WriteLine("Are Residential Small Commercial instances equivalent?: {0}", areResidentialSmallCommercialInstancesEquivalent);
        }

        /// <notes>
        /// Each dimension can also be compared for equality using strings.
        /// </notes>
        [Sample(Key = "5")]
        public void CompareForEqualityFromStrings()
        {
            bool isResidentialResidentialEquivalent = (new AccountClass("Residential") == "Residential");
            bool isResidentialSmallCommercialEquivalent = (new AccountClass("Residential") == "Small Commercial");
            bool isSmallCommercialSmallCommercialAbbreviationEquivalent = (new AccountClass("Small Commercial") == "SC");

            Console.WriteLine("Is Residential Residential equivalent?: {0}", isResidentialResidentialEquivalent);
            Console.WriteLine("Is Residential SmallCommercial equivalent?: {0}", isResidentialSmallCommercialEquivalent);
            Console.WriteLine("Is SmallCommercial SmallCommercial equivalent?: {0}", isSmallCommercialSmallCommercialAbbreviationEquivalent);
        }
    }
}
