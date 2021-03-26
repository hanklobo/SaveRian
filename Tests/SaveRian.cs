using SaveRian;
using Xunit;

namespace Tests
{
    public class SaveRian : GameEngine
    {
        [Theory]
        [InlineData("5",5)]
        [InlineData("0",0)]
        [InlineData("banana",0)]
        public void TestUserInput(string input, int output)
        {
            var game = new GameEngine(true);
            var userInput = game.LoadUserInput(input);
            Assert.Equal(output,userInput);
        }
        [Theory]
        [InlineData(5,3)]
        [InlineData(6,5)]
        [InlineData(41,19)]
        public void TestDesiredPosition(int totalSoldiers, int finalPosition)
        {
            var game = new GameEngine(true);
            var position = game.DesiredPosition(totalSoldiers);
            Assert.Equal(finalPosition,position);
        }
    }
}