using Microsoft.AspNetCore.Mvc;

namespace Application.Dtos.Requests
{
    public record Paging
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; }
        [FromQuery(Name = "per_page")]
        public int PerPage { get; set; }
    }
}
