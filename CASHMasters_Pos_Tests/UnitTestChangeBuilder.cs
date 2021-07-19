using CASHMasters.POS.Exceptions;
using CASHMasters.POS.Model;
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
    public class UnitTestChangeBuilder
    {

        private ChangeBuilder builder;

        [TestInitialize]
        public void InitializeTest()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-US");
            builder = new ChangeBuilder();
        }

        [TestMethod]
        public void Test_SupportedCurrency()
        {
            Change change = builder.BuildCurrency("USD").GetResult();
            Assert.IsTrue(change != null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedCurrencyException))]
        public void Test_NotSupportedCurrency()
        {
            Change change = builder.BuildCurrency("EUR").GetResult();            
        }

        [TestMethod]
        public void Test_ValidChangeInstance()
        {
            Change change = builder.BuildDefaultCurrency().GetResult();
            
            Assert.IsTrue(change != null);            

            Assert.IsTrue(change.Denominations.Length == 11);
        }

        [TestMethod]
        [ExpectedException(typeof(ParsingDenominationException))]
        public void Test_InvalidChangeInstance()
        {
            Change change = builder.BuildCurrency("invalidMXN").GetResult();
           
        }
    }
}
