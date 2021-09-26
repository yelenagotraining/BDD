using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Globotickets.UI.Tests.Drivers;
using Globotickets.UI.Tests.Utils;
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
        
        private IWebElement NumberOfGuests =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.AccessibilityId("NumberOfGuests")
                : By.Id("numberOfGuests"));

        public IWebElement VenuePicker =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.AccessibilityId("Venue")
                : By.Id("venue"));
        
        public IWebElement ServiceLevelPicker =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.AccessibilityId("ServiceLevel")
                : By.Id("serviceLevel"));
        
        private IEnumerable<IWebElement> VenueItems =>
            Driver.FindElements(PlatformName.Equals(MobilePlatform.IOS)
            ? MobileBy.IosNSPredicate("name == 'venueItem'")
            : By.Id("android:id/text1"));
        
        private IEnumerable<IWebElement> ServiceLevelItems =>
            Driver.FindElements(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.IosNSPredicate("name == 'serviceLevelItem'")
                : By.Id("android:id/text1"));
        
        private IWebElement Result =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.AccessibilityId("Result")
                : By.Id("result"));
        
        private IWebElement CalculateButton =>
            Driver.FindElement(PlatformName.Equals(MobilePlatform.IOS)
                ? MobileBy.IosNSPredicate("name == 'Calculate' AND type == 'XCUIElementTypeButton'")
                : By.Id("calculateBtn"));
        
        #endregion

        #region Methods

        public void EnterNumberOfGuests(string text)
        {
            NumberOfGuests.SendKeys(text + (PlatformName.Equals(MobilePlatform.IOS) ? Keys.Enter : string.Empty));
        }
        
        public IEnumerable<string> GetVenueItemLabels()
        {
            if (PlatformName.Equals(MobilePlatform.IOS))
            {
                return VenueItems.Select(item => item.GetAttribute("label"));
            }

            return VenueItems.Select(item => item.Text);
        }

        public string GetSelectedVenue()
        {
            if (PlatformName.Equals(MobilePlatform.IOS))
            {
                return VenuePicker.FindElement(MobileBy.AccessibilityId("VenueInformation")).GetAttribute("value");
            }

            return VenuePicker.FindElement(By.Id("android:id/text1")).Text;
        }

        public void SelectVenue(string venue)
        {
            if (PlatformName.Equals(MobilePlatform.IOS))
            {
                // Select venue option
                VenueItems.First(item => item.GetAttribute("label").Equals(venue)).Click();
                // Navigate back
                Driver.Navigate().Back();
                return;
            }

            VenueItems.First(item => item.Text.Equals(venue)).Click();
        }
        
        public void SelectServiceLevel(string serviceLevel)
        {
            if (PlatformName.Equals(MobilePlatform.IOS))
            {
                // Select venue option
                ServiceLevelItems.First(item => item.GetAttribute("label").Equals(serviceLevel)).Click();
                // Navigate back
                Driver.Navigate().Back();
                return;
            }

            ServiceLevelItems.First(item => item.Text.Equals(serviceLevel)).Click();
        }

        public string GetResult()
        {
            if (PlatformName.Equals(MobilePlatform.IOS))
            {
                return new Wait(Driver).WaitUntilElementContainsValue(Result, TimeSpan.FromSeconds(10));
            }

            return new Wait(Driver).WaitUntilElementContainsText(Result, TimeSpan.FromSeconds(10));
        }

        public void ClickOnCalculateButton()
        {
            Thread.Sleep(2000);
            CalculateButton.Click();
        }

        #endregion
    }
}