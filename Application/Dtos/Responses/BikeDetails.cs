using System.Text.Json.Serialization;

namespace Application.Dtos.Responses
{
    public class BikeDetails
    {
        [JsonPropertyName("date_stolen")]
        public long? DateStolen { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;
        [JsonPropertyName("frame_colors")]
        public string[] FrameColors { get; set; } = default!;
        [JsonPropertyName("frame_model")]
        public string FrameModel { get; set; } = default!;
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("is_stock_img")]
        public bool IsStockImage { get; set; }
        [JsonPropertyName("large_img")]
        public string LargeImage { get; set; } = default!;
        [JsonPropertyName("location_found")]
        public string LocationFound { get; set; } = default!;
        [JsonPropertyName("manufacturer_name")]
        public string ManufacturerName { get; set; } = default!;
        [JsonPropertyName("registry_name")]
        public string RegistryName { get; set; } = default!;
        [JsonPropertyName("registry_url")]
        public string RegistryUrl { get; set; } = default!;
        [JsonPropertyName("serial")]
        public string Serial { get; set; } = default!;
        [JsonPropertyName("status")]
        public string Status { get; set; } = default!;
        [JsonPropertyName("stolen_coordinates")]
        public decimal[] StolenCoordinates { get; set; } = default!;
        [JsonPropertyName("stolen_location")]
        public string StolenLocation { get; set; } = default!;
        [JsonPropertyName("thumb")]
        public string Thumbnail { get; set; } = default!;
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;
        [JsonPropertyName("year")]
        public int? Year { get; set; }

    }
}
