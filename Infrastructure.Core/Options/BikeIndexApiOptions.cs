namespace Infrastructure.Core.Options
{
    public class BikeIndexApiOptions
    {
        public const string Key = nameof(BikeIndexApiOptions);
        public string BaseAddress { get; set; } = null!;
    }
}
