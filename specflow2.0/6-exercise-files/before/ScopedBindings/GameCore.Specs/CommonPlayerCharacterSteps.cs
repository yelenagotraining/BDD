using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class CommonPlayerCharacterSteps
    {
        private readonly PlayerCharacterStepsContext _context;

        public CommonPlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }


        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            // TODO: create and store new player in context

            _context.Player = new PlayerCharacter();
        }
    }
}
