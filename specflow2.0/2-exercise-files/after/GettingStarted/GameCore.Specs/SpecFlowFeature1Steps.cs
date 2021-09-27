using System;
using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given]
        public void GivenIHaveEntered_P0_IntoTheCalculator(int p0)
        {
            ScenarioContext.Current.Pending();
        }



        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
