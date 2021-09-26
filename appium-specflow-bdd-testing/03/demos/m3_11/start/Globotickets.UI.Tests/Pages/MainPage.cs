using System.Collections.Generic;
using System.Linq;
using Globotickets.UI.Tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Globotickets.UI.Tests.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(DriverProvider driverProvider, ConfigurationProvider configurationProvider) : base(driverProvider, configurationProvider)
        {
        }

        #region Elements

        public IWebElement Title =>
            Driver.FindElement(MobileBy.IosNSPredicate("value == 'Globotickets'"));

        public IWebElement VenuePicker =>
            Driver.FindElement(MobileBy.AccessibilityId("Venue"));

        public IEnumerable<IWebElement> VenueItems =>
            Driver.FindElements(MobileBy.IosNSPredicate("name == 'venueItem'"));

        #endregion

        #region Methods

        public IEnumerable<string> GetVenueItemLabels()
        {
            return VenueItems.Select(item => item.GetAttribute("label"));
        }

        #endregion
    }
}