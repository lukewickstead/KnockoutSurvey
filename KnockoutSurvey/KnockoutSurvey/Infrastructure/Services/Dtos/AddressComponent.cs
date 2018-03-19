using System.Collections.Generic;

namespace KnockoutSurvey.Infrastructure.Services.Dtos
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
}