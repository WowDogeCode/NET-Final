using Core.Entities;

namespace Entities.DTOs
{
    public class UserToLoginDto : IDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
