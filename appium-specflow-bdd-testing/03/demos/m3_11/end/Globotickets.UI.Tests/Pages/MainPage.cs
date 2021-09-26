using System.Collections.Generic;
using System.Linq;
using Globotickets.UI.Tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace Globotickets.UI.Tests.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(DriverProvider driverProvider, ConfigurationProvider configurationProvider) : base(driverProvider, configurationProvider)
        {
        }

        #region Elements

        public IWebElement Title =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.IosNSPredicate("value == 'Globotickets'")
                : By.Id("action_bar"));

        public IWebElement VenuePicker =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.AccessibilityId("Venue")
                : By.Id("venue"));

        public IEnumerable<IWebElement> VenueItems =>
            Driver.FindElements(PlatformName.Equals(MobilePlatform.IOS)
            ? MobileBy.IosNSPredicate("name == 'venueItem'")
            : By.Id("android:id/text1"));

        #endregion

        #region Methods

        public IEnumerable<string> GetVenueItemLabels()
        {
            if (PlatformName.Equals(MobilePlatform.IOS))
            {
                return VenueItems.Select(item => item.GetAttribute("label"));
            }

            return VenueItems.Select(item => item.Text);
        }

        #endregion
    }
}