﻿namespace KnockoutSurvey.Infrastructure.Services.Dtos
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Geometry
    {
        public Bounds bounds { get; set; }
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }
}