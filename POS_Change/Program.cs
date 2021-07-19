using CASHMasters.POS.Exceptions;
using CASHMasters.POS.Model;
using CASHMasters.POS.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Change
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-US");

                string[] denominations;
                Dictionary<decimal, int> inputCoins = new Dictionary<decimal, int>();

                string value = System.Configuration.ConfigurationManager.AppSettings["MXN"];

                denominations = value.Split('|');

                Console.WriteLine("Enter the price of the item:");
                decimal itemPrice = Convert.ToDecimal(Console.ReadLine());

                if (itemPrice < 0)
                    throw new ArgumentException("The value entered can't be negative.");

                foreach(string denomination in denominations ){
                    Console.WriteLine(String.Format("Enter the number of {0} coins/bills (Enter 0 if none):", denomination));
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    if(quantity < 0)
                        throw new ArgumentException("The value entered can't be negative.");
                    inputCoins.Add(Convert.ToDecimal(denomination), quantity);
                }

                Change change = (new ChangeBuilder()).BuildDefaultCurrency().GetResult();

                Dictionary<decimal, int> outputCoins = change.Calculate_Change(itemPrice, inputCoins);

                decimal outputDecimal = MoneyHelper.CalculateTotal(outputCoins);

                Console.WriteLine(string.Format("Your change is {0:c2}:", outputDecimal));

                foreach (var obj in outputCoins)
                {
                    Console.WriteLine(obj.Key + " : " + obj.Value);
                }             
                
            }
            catch (NotEnoughMoneyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedCurrencyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ParsingDenominationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }
    }
}
