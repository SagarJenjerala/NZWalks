using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
