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

    public class IsPlayable
    {
        [Fact]
        public Task Should_ReturnFalse_When_NoPlayer()
        {
            var sut = new Game();

            var result = sut.IsPlayable();

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Should_ReturnFalse_When_NotEnoughPlayers()
        {
            var sut = new Game();
            sut.Add("Player 1");

            var result = sut.IsPlayable();

            return Verifier.Verify(result);
        }


        [Fact]
        public Task Should_ReturnTrue_When_EnoughPlayers()
        {
            var sut = new Game();

            for (var i = 1; i < 6; i++)
            {
                sut.Add("Player " + i);
            }

            var result = sut.IsPlayable();

            return Verifier.Verify(result);
        }
    }
}
