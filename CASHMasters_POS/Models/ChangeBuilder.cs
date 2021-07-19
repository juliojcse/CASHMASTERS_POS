using CASHMasters.POS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHMasters.POS.Model
{
    /// <summary>
    /// Builder for change instances.
    /// </summary>
    public class ChangeBuilder
    {
        private string[] _denominations;

        /// <summary>
        /// Sets the currency to be used by the builder.
        /// </summary>
        /// <param name="currency">The currency to be used.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedCurrencyException">
        /// When the currency is not supported (not defined in App.config)
        /// </exception>
        public ChangeBuilder BuildCurrency(string currency)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings[currency];

            if (value == null)
                throw new NotSupportedCurrencyException();

            _denominations = value.Split('|');

            return this;
        }

        /// <summary>
        /// Sets the default currency to be used (MXN).
        /// </summary>
        /// <returns></returns>
        public ChangeBuilder BuildDefaultCurrency()
        {
            string defaultCurrency = System.Configuration.ConfigurationManager.AppSettings["DefaultCurrencyValue"];

            return BuildCurrency(defaultCurrency);
        }

        /// <summary>
        /// Returns a new Change instace based on configuration.
        /// </summary>
        /// <returns>A new configured Change instance.</returns>
        /// <exception cref="ParsingDenominationException">
        /// There is an error parsing the denominations (wrong separator).
        /// </exception>
        public Change GetResult()
        {
            try
            {
                return new Change(Array.ConvertAll(_denominations, decimal.Parse));        
            }
            catch (FormatException)
            {
                throw new ParsingDenominationException();
            }                                             
        }
    }
}
