using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User> {
        new User
        {
            Firstname ="Read Only", Lastname = "User", EmailAddress = "readonly@user.com",
            Id = Guid.NewGuid(),Username="readonly@user.com", Password = "Readyonly@user",
            Roles = new List<string> { "reader"}
        },
        new User
        {
            Firstname ="Read Write", Lastname = "User", EmailAddress = "readwrite@user.com",
            Id = Guid.NewGuid(),Username="readwrite@user.com", Password = "Readywrite@user",
            Roles = new List<string> { "reader", "writer"}
        }
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);

            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
