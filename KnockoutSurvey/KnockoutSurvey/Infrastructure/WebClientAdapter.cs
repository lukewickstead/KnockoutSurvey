﻿using System.Net;
using KnockoutSurvey.Infrastructure;

namespace KnockoutSurvey.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class WebClientAdapter : IWebClientAdapter
    {
        public string DownloadString(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}