using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit.Abstractions;

namespace Globotickets.UI.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hooks(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }
        
        [BeforeStep]
        public void BeforeStep()
        {
            _specFlowOutputHelper.WriteLine("BeforeStep Hook executing...");
        }
        
        [AfterStep]
        public void AfterStep()
        {
            _specFlowOutputHelper.WriteLine("AfterStep Hook executing...");
        }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            _specFlowOutputHelper.WriteLine("BeforeScenario Hook executing...");
        }
        
        [AfterScenario]
        public void AfterScenario()
        {
            _specFlowOutputHelper.WriteLine("AfterScenario Hook executing...");
        }
    }
}