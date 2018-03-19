using System;

namespace KnockoutSurvey.Infrastructure
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ConsoleAdapter : IConsoleAdapter
    {
        public void WriteLine(string outputString)
        {
            Console.WriteLine(outputString);
        }
    }
}