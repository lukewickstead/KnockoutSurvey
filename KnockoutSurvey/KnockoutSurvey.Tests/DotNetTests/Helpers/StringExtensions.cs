using System.Linq;

namespace KnockoutSurvey.Tests.DotNetTests.Helpers
{
    internal static class StringExtensions
    {
        internal static string StringOfLength(this string input, int legnth)
        {
            var seed = string.IsNullOrEmpty(input) ? '.' : input.First();
            return new string(seed, legnth);
        }
    }
}