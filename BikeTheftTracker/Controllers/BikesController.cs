using Application.Dtos.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeTheftTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IBikesService _bikesService;

        public BikesController(IBikesService bikesService)
        {
            _bikesService = bikesService;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> SearchBikes([FromQuery] SearchRequest searchRequest)
        {
            var result = await _bikesService.SearchBikes(searchRequest);

            return Ok(result);
        }
    }
}
