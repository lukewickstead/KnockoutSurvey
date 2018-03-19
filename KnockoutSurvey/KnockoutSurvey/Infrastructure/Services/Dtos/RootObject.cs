using System.Collections.Generic;

namespace KnockoutSurvey.Infrastructure.Services.Dtos
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class RootObject
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}