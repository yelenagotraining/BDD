using System;
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
        private readonly VenuePriceCalculatorStepsContext _context;

        public VenuePriceCalculatorStepDefinitions(MainPage mainPage, VenuePriceCalculatorStepsContext context)
        {
            _mainPage = mainPage;
            _context = context;
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
        
        [When(@"Jim clicks on the service level picker")]
        public void WhenJimClicksOnTheServiceLevelPicker()
        {
            _mainPage.ServiceLevelPicker.Click();
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
        
        [When(@"selects (.*) option for the Venue")]
        public void WhenSelectsOptionForTheVenue(string venue)
        {
            _mainPage.SelectVenue(venue);
        }

        [When(@"selects (.*) option for the Service Level")]
        public void WhenSelectsOptionForTheServiceLevel(string serviceLevel)
        {
            _mainPage.SelectServiceLevel(serviceLevel);
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

        [When(@"Jim enters randomly chosen number of guests")]
        public void WhenJimEntersRandomlyChosenNumberOfGuests()
        {
            _mainPage.EnterNumberOfGuests(_context.NumberOfGuests.ToString());
        }

        [Then(@"the calculated result should be correct")]
        public void ThenTheCalculatedResultShouldBeCorrect()
        {
            var result = $"Total cost is: ${2500 + _context.NumberOfGuests * 100}.0";
            _mainPage.GetResult().Should().Be(result);
        }
    }
}