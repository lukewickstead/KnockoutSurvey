using KnockoutSurvey.Models;
using Newtonsoft.Json;

namespace KnockoutSurvey.Infrastructure
{
    // ReSharper disable once ClassNeverInstantiated.Global
        public class GoogleApisServiceAdapter : IGoogleApisServiceAdapter
    {
        // The API key should not really be checked. It should be added into the config during deployment.
        private const string BaseGoogleApisUrl =
            "https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key=AIzaSyApiY9lI5Q8szDsjvEm2MHrgEIz2EbIQP4";

        private readonly IWebClientAdapter _webClientAdapter;

        public GoogleApisServiceAdapter(IWebClientAdapter webClientAdapter)
        {
            _webClientAdapter = webClientAdapter;
        }

        public string GetAddress(decimal latitude, decimal longitude)
        {
            var url = GetUrl(latitude, longitude);
            var response = _webClientAdapter.DownloadString(url);

            var dto = JsonConvert.DeserializeObject<RootObject>(response);
            return dto.results[0].formatted_address;
        }

        private static string GetUrl(decimal latitude, decimal longitude)
        {
            return string.Format(BaseGoogleApisUrl, latitude, longitude);
        }
    }
}