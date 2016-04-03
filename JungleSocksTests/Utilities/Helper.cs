using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Testing.JungleSocks.UI.Helper
{
    public class Helper
    {
        IWebDriver WebDriver;

        public Helper(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IList<IWebElement> FindElementByCss(string cssValue)
        {
            return WebDriver.FindElements(By.CssSelector(cssValue));
        }

        public IWebElement FindElementById(string id)
        {
            return WebDriver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByName(string id)
        {
            return WebDriver.FindElement(By.Name(id));
        }

        public IList<IWebElement> FindElementsById(string id)
        {
            return WebDriver.FindElements(By.Id(id));
        }

        public void SelectDropdownByName(string name, string visibleText)
        {
            new SelectElement(WebDriver.FindElement(By.Name(name))).SelectByText(visibleText);
        }
    }
}
