using System;
using System.Collections.Generic;

namespace OBiletCase.Model.DTOs
{
    public class BusJourneyDto
    {
        public string Status { get; set; }

        public IEnumerable<BJDataDto> Data { get; set; }
    }

    public class BJDataDto
    {
        public long Id { get; set; }

        public string OriginLocation { get; set; }

        public string DestinationLocation { get; set; }

        public bool IsActive { get; set; }

        public JourneyDto Journey { get; set; }

        public long? Rank { get; set; }
    }

    public class JourneyDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTimeOffset Departure { get; set; }

        public DateTimeOffset Arrival { get; set; }

        public string Currency { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal InternetPrice { get; set; }

    }
}