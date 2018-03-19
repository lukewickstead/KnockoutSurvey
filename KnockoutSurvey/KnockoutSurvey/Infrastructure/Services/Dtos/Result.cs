using System.Collections.Generic;

namespace KnockoutSurvey.Infrastructure.Services.Dtos
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public List<string> postcode_localities { get; set; }
        public List<string> types { get; set; }
    }
}