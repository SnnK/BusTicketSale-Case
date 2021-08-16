using System.Collections.Generic;
using OBiletCase.Model.DTOs;

namespace OBiletCase.Web.Models.ViewModel
{
    public class IndexViewModel
    {
        public BusLocationDto BusLocationDto { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
