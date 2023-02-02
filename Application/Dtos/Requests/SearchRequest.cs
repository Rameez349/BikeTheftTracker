using Application.Dtos.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Application.Dtos.Requests
{
    public record SearchRequest : Paging
    {
        [FromQuery(Name = "serial")]
        public string? Serial { get; set; }
        [FromQuery(Name = "query")]
        public string? Query { get; set; }
        [FromQuery(Name = "manufacturer")]
        public string? Manufacturer { get; set; }
        [FromQuery(Name = "colors")]
        public string? Colors { get; set; }
        [FromQuery(Name = "location")]
        public string? Location { get; set; }
        [FromQuery(Name = "distance")]
        public string? Distance { get; set; }
        [FromQuery(Name = "stolenness")]
        public Stolenness Stolenness { get; set; }
    }
}
