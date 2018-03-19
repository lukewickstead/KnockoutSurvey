namespace KnockoutSurvey.Infrastructure
{
    public interface IWebClientAdapter
    {
        string DownloadString(string url);
    }
}