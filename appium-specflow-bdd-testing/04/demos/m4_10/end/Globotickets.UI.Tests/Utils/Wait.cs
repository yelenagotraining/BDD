using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace Globotickets.UI.Tests.Utils
{
    public class Wait
    {
        private readonly AppiumDriver<IWebElement> _driver;

        public Wait(AppiumDriver<IWebElement> driver)
        {
            _driver = driver;
        }

        public string WaitUntilElementContainsValue(IWebElement element, TimeSpan timeout)
        {
            return new WebDriverWait(_driver, timeout).Until(driver => element.GetAttribute("value") ?? null);
        }
        
        public string WaitUntilElementContainsText(IWebElement element, TimeSpan timeout)
        {
            return new WebDriverWait(_driver, timeout).Until(driver => !string.IsNullOrWhiteSpace(element.Text) ? element.Text : null);
        }
    }
}