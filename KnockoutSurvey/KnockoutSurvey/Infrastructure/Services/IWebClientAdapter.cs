namespace KnockoutSurvey.Infrastructure.Services
{
    public interface IWebClientAdapter
    {
        string DownloadString(string url);
    }
}