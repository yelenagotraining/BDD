using TechTalk.SpecFlow;

namespace Globotickets.UI.Tests.Steps
{
    [Binding]
    public class VenuePriceCalculatorStepDefinitions
    {
        [Given(@"Jim has opened the Globotickets application")]
        public void GivenJimHasOpenedTheGloboticketsApplication()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"Jim clicks on the venue picker")]
        public void WhenJimClicksOnTheVenuePicker()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"the (.*) option should be present")]
        public void ThenTheCityHallOptionShouldBePresent(string venue)
        {
            ScenarioContext.StepIsPending();
        }
    }
}