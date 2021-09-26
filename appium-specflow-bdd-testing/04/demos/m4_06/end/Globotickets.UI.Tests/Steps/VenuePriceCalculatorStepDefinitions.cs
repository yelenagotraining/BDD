using System.Linq;
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
        
        [Given(@"the (.*) venue option is selected")]
        public void GivenTheVenueOptionIsSelected(string venue)
        {
            _mainPage.GetSelectedVenue().Should().Be(venue);
        }

        [When(@"Jim clicks on the venue picker")]
        public void WhenJimClicksOnTheVenuePicker()
        {
            _mainPage.VenuePicker.Click();
        }
        
        [When(@"Jim enters (.*) for the number of guests")]
        public void WhenJimEntersForTheNumberOfGuests(string numberOfGuests)
        {
            _mainPage.EnterNumberOfGuests(numberOfGuests);
        }
        
        [When(@"clicks on the calculate button")]
        public void WhenClicksOnTheCalculateButton()
        {
            _mainPage.ClickOnCalculateButton();
        }
        
        [Then(@"the venues should be present")]
        public void ThenTheVenuesShouldBePresent(Table table)
        {
            _mainPage.GetVenueItemLabels().Should().Contain(table.Rows.Select(row => row.Values.First()));
        }

        [Then(@"the validation message ""(.*)"" is displayed\.")]
        [Then(@"the result ""(.*)"" is displayed\.")]
        public void ThenTheResultIsDisplayed(string result)
        {
            _mainPage.GetResult().Should().Be(result);
        }
    }
}