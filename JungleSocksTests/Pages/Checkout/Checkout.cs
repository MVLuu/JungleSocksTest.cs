using System.Collections.Generic;
using OpenQA.Selenium;

namespace Testing.JungleSocks.UI
{
    /// <summary>
    ///     Class to interact with the Checkout modal.
    /// </summary>
    public class Checkout
    {
        private const string Body = "body";
            
        private const string LineItems = ".line_item";
        
        private const string SubTotal = "subtotal";
        
        private const string Taxes = "taxes";
        
        private const string Total = "total";

        private IWebDriver WebDriver;

        private Helper.Helper Helper;

        public Checkout(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Helper = new Helper.Helper(webDriver);
        }
        
        public string GetSubTotal()
        {
            return Helper.FindElementById(SubTotal).Text;
        }

        public string GetTax()
        {
            return Helper.FindElementById(Taxes).Text;
        }

        public string GetTotal()
        {
            return Helper.FindElementById(Total).Text;
        }
        
        /// <summary>
        ///     Get the order line items.
        ///     TODO: Return List<List<string>> so that user doesn't have to parse.
        /// </summary>
        /// <returns>A list of line items on check out page.</returns>
        public List<string> GetLineItems()
        {
            List<string> lineItems = new List<string>();
            foreach (var lineItem in Helper.FindElementByCss(LineItems))
            {
                lineItems.Add(lineItem.Text);
            }

            return lineItems;
        }

        /// <summary>
        ///     Case where text validation is needed for entire page.
        ///     If this is use often, consider optimization.
        /// </summary>
        /// <returns>All texts on page.</returns>
        public string GetVisibleText()
        {
            return Helper.FindElementById(Body).Text;
        }
    }
}
