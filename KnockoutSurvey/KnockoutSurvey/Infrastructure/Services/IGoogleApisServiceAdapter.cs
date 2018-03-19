namespace KnockoutSurvey.Infrastructure.Services
{
    public interface IGoogleApisServiceAdapter
    {
        string GetAddress(decimal latitude, decimal longitude);
    }
}