using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Testing.JungleSocks.UI;

namespace Testing.JungleSocks.UITests
{
    [TestClass]
    public class MainPageTest
    {
        private IWebDriver WebDriver;

        /// <summary>
        ///     Functional test to validate JungleSocks UI.
        ///     <steps>
        ///         1. Navigate to JungleSocks main page.
        ///     </steps>
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            WebDriver.Navigate().GoToUrl("https://jungle-socks.herokuapp.com");
        }

        /// <summary>
        ///     Scenario 1, basic ordering.
        ///     <steps>
        ///         Make one order for 3 elephant socks.
        ///         Select California from the state drop-down selection.
        ///         Click "check out" box.
        ///     </steps>
        ///     <verify>
        ///         Verify the number of line item (name, price and quantity), sub-total, validate tax calculation, and total.
        ///     </verify>
        /// </summary>
        [TestMethod]
        public void OneOrder()
        {
            const string expectedQuantity = "3";
            const string expectedItem = "elephant";
            const string expectedPrice = "35";
            const string state = "California";
            
            var order = new Order(WebDriver);
            order.EnterQuantityElephant(expectedQuantity);
            order.SelectState(state);
            var checkOut = order.ClickCheckOut();
            
            var lineItems = checkOut.GetLineItems();
            var firstItemRow = lineItems[0].Split(' ');
            Assert.AreEqual(expectedItem, firstItemRow[0], string.Format("Fail: Expected item name {0} does not match display name {1}", expectedItem, firstItemRow[0]));
            Assert.AreEqual(expectedPrice, firstItemRow[1], string.Format("Fail: Expected item price {0} does not match item price {1}", expectedPrice, firstItemRow[1]));
            Assert.AreEqual(expectedQuantity, firstItemRow[2], string.Format("Fail: Expected item quantity {0} does not match item quantity {1}", expectedQuantity, firstItemRow[2]));

            var subTotal = checkOut.GetSubTotal();
            var calculatedSubTotal = double.Parse(expectedQuantity) * double.Parse(expectedPrice);
            var expectedSubTotal = "$" + calculatedSubTotal.ToString("0.00");
            Assert.AreEqual(expectedSubTotal, subTotal, string.Format("Fail: Expected sub-total {0} value does not match display value {1}", expectedSubTotal, subTotal));

            var tax = checkOut.GetTax();
            var calculatedTax = TaxCalculator(state, double.Parse(expectedPrice), int.Parse(expectedQuantity));
            var expectedTax = "$" + calculatedTax.ToString("0.00");
            Assert.AreEqual(expectedTax, tax, string.Format("Fail: Expected tax {0} value does not match display value {1}", expectedTax, tax));

            var total = checkOut.GetTotal();
            var calculatedTotal = calculatedSubTotal + calculatedTax;
            var expectedTotal = "$" + calculatedTotal.ToString("0.00");
            Assert.AreEqual(expectedTotal, total, string.Format("Fail: Expected total {0} value does not match display value {1}", expectedTotal, total));

        }

        private double TaxCalculator(string stateName, double price, int quantity)
        {
            double expectedTax;

            var totalPreTax = price * quantity;

            switch (stateName.ToLower())
            {
                case "california":
                    expectedTax = totalPreTax * 0.08;
                    break;
                case "new york":
                    expectedTax = totalPreTax * 0.06;
                    break;
                case "minnesota":
                    expectedTax = totalPreTax;
                    break;
                default:
                    expectedTax = totalPreTax * 0.05;
                    break;
            }

            return Math.Round(expectedTax, 3);
        }

        /// <summary>
        ///     Close browser when done with test.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            WebDriver.Close();
        }
    }
}
