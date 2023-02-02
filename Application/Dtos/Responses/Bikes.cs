using System.Text.Json.Serialization;

namespace Application.Dtos.Responses
{
    public class Bikes
    {
        [JsonPropertyName("bikes")]
        public IEnumerable<BikeDetails> BikesCollection { get; set; } = default!;
    }
}
