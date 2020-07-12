using Energy.DataStructures;
using Energy.Services.Impl;
using Sampler.ConsoleApplication;
using System;
using System.Collections.Generic;

namespace Energy.Samples
{
    [SampleFixture]
    public class ServiceSamples : Sample
    {
        /// <notes>
        /// All dimensions can be returned as a collection.
        /// </notes>
        [Sample(Key = "1")]
        public void AllDimensionsCanBeReturnedAsACollection()
        {
            IEnumerable<AccountClass> accountClasses = new EnergyDimensionService()
                .GetAllAccountClasses();

            foreach (AccountClass accountClass in accountClasses)
            {
                Console.WriteLine(accountClass);
            }
        }
    }
}
