using Core.Entities;

namespace Entities.DTOs
{
    public class UserToRegisterDto : IDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
