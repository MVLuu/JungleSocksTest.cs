
using OpenQA.Selenium;
using System;

namespace Testing.JungleSocks.UI
{

    /// <summary>
    ///     Class to interact with the Order modal.
    /// </summary>
    public class Order
    {
        private const string Body = "body";
        
        private const string LineItems = ".line_item";
        
        private const string LineItemZebra = ".line_item.zebra";
        
        private const string LineItemQuantityZebra = "line_item_quantity_zebra";
        
        private const string LineItemLion = "line_item.lion";
        
        private const string LineItemQuantityLion = "#line_item_quantity_lion";
        
        private const string LineItemElephant = "line_item.elephant";
        
        private const string LineItemQuantityElephant ="line_item_quantity_elephant";
        
        private const string LineItemGiraffe = "#line_item.giraffe";
        
        private const string LineItemQuantityGiraffe = "#line_item_quantity_giraffe";
        
        private const string StateDropdown = "state";
        
        private const string Checkout = "commit";

        public IWebDriver WebDriver;

        public Helper.Helper Helper;

        public Order(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Helper = new UI.Helper.Helper(webDriver);
        }

        public void EnterQuantityZebra(string value)
        {
            Helper.FindElementById(LineItemQuantityZebra).Clear();
            Helper.FindElementById(LineItemQuantityZebra).SendKeys(value);
        }

        public void EnterQuantityLion(string value)
        {
            Helper.FindElementById(LineItemQuantityLion).Clear();
            Helper.FindElementById(LineItemQuantityLion).SendKeys(value);
        }

        public void EnterQuantityElephant(string value)
        {
            Helper.FindElementById(LineItemQuantityElephant).Click();
            Helper.FindElementById(LineItemQuantityElephant).SendKeys(value);
        }

        public void EnterQuantityGiraffe(string value)
        {
            Helper.FindElementById(LineItemQuantityGiraffe).Clear();
            Helper.FindElementById(LineItemQuantityGiraffe).SendKeys(value);
        }

        public void SelectState(string stateName)
        {
            Helper.SelectDropdownByName(StateDropdown, stateName);
        }

        public Checkout ClickCheckOut()
        {
            Helper.FindElementByName(Checkout).Click();
            var checkout = new Checkout(WebDriver);

            // TODO: Need to implement a check for page exist (with expiration) before returning checkout modal.
            try
            {
                checkout.GetTax();
            }
            catch (Exception e)
            {
                checkout.GetTax();
            }


            return checkout;
        }
    }
}
