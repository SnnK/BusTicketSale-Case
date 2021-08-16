using System.Collections.Generic;

namespace OBiletCase.Model.DTOs
{
    public class BusLocationDto
    {
        public string Status { get; set; }

        public IEnumerable<BLDataDto> Data { get; set; }
    }

    public class BLDataDto
    {
        public long Id { get; set; }

        public long ParentId { get; set; }

        public string Name { get; set; }

        public long? Rank { get; set; }
    }
}
