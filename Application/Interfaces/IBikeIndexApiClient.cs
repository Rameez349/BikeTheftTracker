namespace Application.Interfaces
{
    public interface IBikeIndexApiClient
    {
        Task<string> SearchBikes(string requestPath, string queryParams);
    }
}
