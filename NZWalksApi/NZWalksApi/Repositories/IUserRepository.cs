using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
