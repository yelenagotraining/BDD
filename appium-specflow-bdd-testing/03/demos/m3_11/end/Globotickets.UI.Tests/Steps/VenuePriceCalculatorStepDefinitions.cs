using FluentAssertions;
using Globotickets.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Globotickets.UI.Tests.Steps
{
    [Binding]
    public class VenuePriceCalculatorStepDefinitions
    {
        private readonly MainPage _mainPage;

        public VenuePriceCalculatorStepDefinitions(MainPage mainPage)
        {
            _mainPage = mainPage;
        }
        
        [Given(@"Jim has opened the Globotickets application")]
        public void GivenJimHasOpenedTheGloboticketsApplication()
        {
            _mainPage.Title.Displayed.Should().BeTrue();
        }

        [When(@"Jim clicks on the venue picker")]
        public void WhenJimClicksOnTheVenuePicker()
        {
            _mainPage.VenuePicker.Click();
        }

        [Then(@"the (.*) option should be present")]
        public void ThenTheOptionShouldBePresent(string venue)
        {
            _mainPage.GetVenueItemLabels().Should().Contain(label => label.Equals(venue));
        }
    }
}