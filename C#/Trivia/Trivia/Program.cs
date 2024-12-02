using System;
using System.Diagnostics.CodeAnalysis;

namespace Trivia
{

    [ExcludeFromCodeCoverage]
    public class Program
    {

        public static void Main(string[] args)
        {
            var random = new Random();
            var gameRunner = new GameRunner();

            gameRunner.Run(random);
        }
    }
}