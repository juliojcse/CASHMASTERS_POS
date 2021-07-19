using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHMasters.POS.Util
{
    /// <summary>
    /// Helper class for common money operations.
    /// </summary>
    public static class MoneyHelper
    {
        /// <summary>
        /// Calculates the total price of and item.
        /// </summary>
        /// <param name="money">A Dictionary {Denomination, Quantity} representing the coins and bills given.</param>
        /// <returns>A decimal representing the total value.</returns>
        public static decimal CalculateTotal(Dictionary<decimal, int> money){

            decimal total = 0;

            foreach (KeyValuePair<decimal, int> entry in money)
            {
                total += entry.Key * entry.Value;
            }

            return total;
        }
    }
}
