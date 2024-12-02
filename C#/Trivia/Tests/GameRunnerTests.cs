using System;
using System.IO;
using System.Threading.Tasks;
using Trivia;
using VerifyXunit;
using Xunit;

namespace Tests;

public class GameRunnerTests
{
    [Fact]
    public Task Run_GameRunner_CallsAddMethodThreeTimes()
    {
        // Arrange
        StringWriter consoleOut = new();
        Console.SetOut(consoleOut);

        var random = new Random(300);
        var sut = new GameRunner();

        // Act
        sut.Run(random);

        // Assert
        return Verifier.Verify(consoleOut.ToString());
    }
}
