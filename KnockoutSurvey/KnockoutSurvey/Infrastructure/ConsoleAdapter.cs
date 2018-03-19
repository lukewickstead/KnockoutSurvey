using System;

namespace KnockoutSurvey.Infrastructure
{
    public class ConsoleAdapter : IConsoleAdapter
    {
        public void WriteLine(string outputString)
        {
            Console.WriteLine(outputString);
        }
    }
}