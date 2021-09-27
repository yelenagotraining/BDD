using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class CommonPlayerCharacterSteps
    {
        private PlayerCharacter _player;


        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            // TODO: create and store new player in context

            _player = new PlayerCharacter();
        }
    }
}
