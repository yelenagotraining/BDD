using Globotickets.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Globotickets.UI.Tests.Steps
{
    [Binding, Scope(Tag = "SharedSteps")]
    public class SharedSteps
    {
        private readonly MainPage _mainPage;

        public SharedSteps(MainPage mainPage)
        {
            _mainPage = mainPage;
        }
        
        [Given(@"Jim has opened the Globotickets application")]
        public void GivenJimHasOpenedTheGloboticketsApplication()
        {
            ScenarioContext.StepIsPending();
        }
    }
}