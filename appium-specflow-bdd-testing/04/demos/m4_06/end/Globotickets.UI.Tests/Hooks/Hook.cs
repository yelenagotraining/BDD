using System;
using Gherkin.Ast;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit.Abstractions;

namespace Globotickets.UI.Tests.Hooks
{
    [Binding, Scope(Scenario = "Jim enters number of guests that is above the limit")]
    public class Hooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hooks(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }
        
        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            _specFlowOutputHelper.WriteLine("BeforeScenarioBlock Hook executing...");
        }
        
        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            _specFlowOutputHelper.WriteLine("AfterScenarioBlock Hook executing...");
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