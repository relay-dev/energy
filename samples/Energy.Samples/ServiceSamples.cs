using Consolater;
using Energy.Services.Impl;
using System;
using System.Collections.Generic;

namespace Energy.Samples
{
    [ConsoleAppMenuItem]
    public class ServiceSamples : Sample
    {
        /// <notes>
        /// All dimensions can be returned as a collection.
        /// </notes>
        [ConsoleAppSelection(Key = "1")]
        public void AllDimensionsCanBeReturnedAsACollection()
        {
            IEnumerable<AccountClass> accountClasses = new EnergyDimensionService()
                .GetAllAccountClasses();

            foreach (AccountClass accountClass in accountClasses)
            {
                Console.WriteLine(accountClass.ToString());
            }
        }
    }
}
