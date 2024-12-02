using System.Threading.Tasks;
using Trivia;
using VerifyXunit;
using Xunit;

namespace Tests;
public class GameTests
{
    public class HowManyPlayers
    {
        [Fact]
        public Task Should_ReturnZero_When_NoPlayerIsAdded()
        {
            var sut = new Game();

            var result = sut.HowManyPlayers();

            return Verifier.Verify(result);
        }
    }
}
