using CASHMasters.POS.Exceptions;
using CASHMasters.POS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHMasters.POS.Model
{
    /// <summary>
    /// Change class
    /// </summary>
    public class Change
    {        
        private readonly decimal[] _denominations; 
        public decimal[] Denominations   
        {
            get { return _denominations; }              
        }

        public Change(decimal[] denominations)
        {
            denominations = denominations.Distinct().ToArray();
            Array.Sort(denominations);
            Array.Reverse(denominations);            

            this._denominations = denominations;
        }

        /// <summary>
        /// Calculate the correct change to be returned. The solution is optimal for standarized currency systems.
        /// </summary>
        /// <param name="itemPrice">The price of the item being purchased.</param>
        /// <param name="coinsAndBills">The number of coin and bills given by the customer expressed as a Dictionary{Denomination, Quantity}</param>
        /// <returns>A Dictionary representing the optimal change, the change amount is equal or less than the total change because fractions are not used in physical transactions.</returns>
        public Dictionary<decimal, int> Calculate_Change(decimal itemPrice, Dictionary<decimal, int> coinsAndBills){
            decimal givenAmount = MoneyHelper.CalculateTotal(coinsAndBills);

            if (givenAmount < itemPrice)
                throw new NotEnoughMoneyException();

            Dictionary<decimal, int> change = new Dictionary<decimal, int>();

            decimal changeAmount = givenAmount - itemPrice;

            foreach (decimal denomination in _denominations)
            {
                int denominationQuantity = Convert.ToInt32(Math.Floor(changeAmount / denomination)); 
                change.Add(denomination, denominationQuantity);
                changeAmount -= denominationQuantity * denomination;
            }

            return change;
        }
    }
}
