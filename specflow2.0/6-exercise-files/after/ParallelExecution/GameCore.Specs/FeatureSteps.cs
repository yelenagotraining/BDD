using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I'm waiting for (.*) seconds")]
        public void GivenImWaiting(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
