using FluentAssertions;
using System;
using System.IO;
using System.Threading.Tasks;
using Trivia;
using VerifyXunit;
using Xunit;

namespace Tests;
public class GameTests
{
    public class HowManyPlayers : GameTests
    {
        [Fact]
        public void Should_ReturnZero_When_NoPlayerIsAdded()
        {
            var sut = new Game();

            var result = sut.HowManyPlayers();

            result.Should().Be(0);
        }

        [Fact]
        public void Should_ReturnPlayerNumber_When_PlayersAreAdded()
        {
            var sut = new Game();

            AddPlayers(sut, 4);

            var result = sut.HowManyPlayers();

            result.Should().Be(4);
        }
    }

    public class IsPlayable : GameTests
    {
        [Fact]
        public void Should_ReturnFalse_When_NoPlayer()
        {
            var sut = new Game();

            var result = sut.IsPlayable();

            result.Should().BeFalse();
        }

        [Fact]
        public void Should_ReturnFalse_When_NotEnoughPlayers()
        {
            var sut = new Game();

            AddPlayers(sut, 1);

            var result = sut.IsPlayable();

            result.Should().BeFalse();
        }

        [Fact]
        public void Should_ReturnTrue_When_EnoughPlayers()
        {
            var sut = new Game();

            AddPlayers(sut, 4);

            var result = sut.IsPlayable();

            result.Should().BeTrue();
        }
    }

    public class AddPlayer
    {
        [Fact]
        public void Should_IncreasePlayerCount()
        {
            StringWriter writer = new();
            Console.SetOut(writer);

            Game sut = new();

            sut.Add("Player 1");

            sut.HowManyPlayers().Should().Be(1);
        }

        [Fact]
        public Task Should_LogPlayerAdded()
        {
            StringWriter consoleWriter = new();
            Console.SetOut(consoleWriter);

            Game sut = new();

            sut.Add("Player 1");

            return Verifier.Verify(consoleWriter.ToString());
        }
    }

    protected static void AddPlayers(Game sut, int count)
    {
        for (var i = 0; i < count; i++)
        {
            sut.Add("Player " + i);
        }
    }
}
