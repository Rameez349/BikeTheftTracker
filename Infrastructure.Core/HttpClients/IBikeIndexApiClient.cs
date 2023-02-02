namespace Infrastructure.Core.HttpClients
{
    public interface IBikeIndexApiClient
    {
        Task<string> SearchBikes(string requestPath, string queryParams);
    }
}
