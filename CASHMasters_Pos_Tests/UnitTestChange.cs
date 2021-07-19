using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CASHMasters.POS.Model;
using System.Globalization;
using System.Collections.Generic;
using CASHMasters.POS.Util;
using CASHMasters.POS.Exceptions;
using System.Linq;

namespace CASHMasters_Pos_Tests
{
    [TestClass]
    public class UnitTestChange
    {
        private Change change;
        private Dictionary<decimal, int> inputCoins;
        private decimal itemPrice;

        [TestInitialize]
        public void InitializeTest()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-US");
            change = (new ChangeBuilder()).BuildDefaultCurrency().GetResult();
            inputCoins = new Dictionary<decimal, int>();
            inputCoins.Add(100, 5); //500
            itemPrice = Convert.ToDecimal(470);
        }

        [TestMethod]
        public void Test_GivenMoneyFullfillsPrice()
        {                       
            Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);

            decimal changeDecimal = MoneyHelper.CalculateTotal(changeOut);

            Assert.AreEqual(changeDecimal, Convert.ToDecimal(30));
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughMoneyException))]
        public void Test_GivenMoneyUnfullfillsPrice()
        {            
            decimal itemPrice = Convert.ToDecimal(550);

            Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);
        }

        [TestMethod]
        public void Test_OptimalChange()
        {                       

            Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);

            decimal changeDecimal = MoneyHelper.CalculateTotal(changeOut); //Expects 30
            
            Assert.AreEqual(changeOut[Convert.ToDecimal(20)], 1);
            Assert.AreEqual(changeOut[Convert.ToDecimal(10)], 1);
        }

        [TestMethod]
        public void Test_ExactChange()
        {                        
            Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);

            decimal inputDecimal = MoneyHelper.CalculateTotal(inputCoins);
            decimal changeDecimal = MoneyHelper.CalculateTotal(changeOut); //Expects 30

            Assert.AreEqual(itemPrice + changeDecimal, inputDecimal);

        }

        [TestMethod]
        public void Test_NotExactChange()
        {           
            decimal itemPrice = Convert.ToDecimal(470.08);

            Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);

            decimal inputDecimal = MoneyHelper.CalculateTotal(inputCoins);
            decimal changeDecimal = MoneyHelper.CalculateTotal(changeOut); //Expects 30

            Assert.AreEqual(changeDecimal, Convert.ToDecimal(29.90));
            Assert.IsTrue((inputDecimal - itemPrice - changeDecimal) < Convert.ToDecimal(0.05));
        }

        [TestMethod]
        public void Test_ValidDenominations()
        {                       
            Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);

            Assert.IsTrue(Enumerable.SequenceEqual(change.Denominations, changeOut.Keys));
        }
        
    }
   
}
