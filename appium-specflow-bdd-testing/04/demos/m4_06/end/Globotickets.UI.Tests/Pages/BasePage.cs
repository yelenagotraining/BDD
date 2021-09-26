using Globotickets.UI.Tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Globotickets.UI.Tests.Pages
{
    public class BasePage
    {
        protected readonly AppiumDriver<IWebElement> Driver;
        protected readonly string PlatformName;

        public BasePage(DriverProvider driverProvider, ConfigurationProvider configurationProvider)
        {
            Driver = driverProvider.GetDriver();
            PlatformName = configurationProvider.GetSettings().PlatformName;
        }
    }
}