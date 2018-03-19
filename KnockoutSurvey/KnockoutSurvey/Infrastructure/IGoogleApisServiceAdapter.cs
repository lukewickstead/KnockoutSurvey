namespace KnockoutSurvey.Infrastructure
{
    public interface IGoogleApisServiceAdapter
    {
        string GetAddress(decimal latitude, decimal longitude);
    }
}