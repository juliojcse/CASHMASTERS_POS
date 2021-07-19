using CASHMasters.POS.Exceptions;
using CASHMasters.POS.Model;
using CASHMasters.POS.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASHMasters_Pos_Tests
{
    [TestClass]
    public class UnitTestMoneyHelper
    {        

        [TestInitialize]
        public void InitializeTest()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-US");            
        }

        [TestMethod]
        public void Test_CalculateTotal()
        {
            Dictionary<decimal, int> inputCoins = new Dictionary<decimal, int>();
            inputCoins.Add(100, 5); //500
            inputCoins.Add(20, 1); //20
            inputCoins.Add(10, 2); //20

            decimal total = MoneyHelper.CalculateTotal(inputCoins);

            Assert.IsTrue(total == 540);
        }

                      
    }
}
