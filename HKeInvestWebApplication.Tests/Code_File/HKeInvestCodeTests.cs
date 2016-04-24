using NUnit.Framework;
using HKeInvestWebApplication.Code_File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKeInvestWebApplication.Code_File.Tests
{
    [TestFixture()]
    public class HKeInvestCodeTests
    {
        /*[Test()]
        public void getDataTypeTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void getSortDirectionTest() 
        {
            Assert.Fail();
        }

        [Test()]
        public void unloadGridViewTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void getColumnIndexByNameTest()
        {
            Assert.Fail();
        }*/

        /*[Test()]
        public void convertCurrencyTest()
        {
            Assert.Fail();
        }*/

        [TestCase("USD", "7.791", "EUR", "8.488", 1000, 917.88)]
        [TestCase("HKD", "1.000", "GBP", "11.100", 2000, 180.18)]
        [TestCase("EUR", "8.488", "HKD", "1.000", 3000, 25464.00)]
        [TestCase("HKD", "1.000", "JPY", "0.065", 4000, 61538.46)]
        [TestCase("GBP", "11.100", "USD", "7.791", 5000, 7123.60)]
        public void convertCurrencyTest(string fromCurrency, string fromCurrencyRate, string toCurrency, string toCurrencyRate, decimal value, decimal expected)
        {
            HKeInvestCode demo = new HKeInvestCode();
            decimal result = demo.convertCurrency(fromCurrency, fromCurrencyRate, toCurrency, toCurrencyRate, value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}