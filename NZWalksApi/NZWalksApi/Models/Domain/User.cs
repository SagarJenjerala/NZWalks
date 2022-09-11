using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace NZWalksApi.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }

        public List<User_Role> UserRoles { get; set; }

    }
}
