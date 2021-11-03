using System.Collections.Generic;

namespace TheBookShop.Models
{
    public class RegistrationResponseDto
    {
        public bool IsRegistrationSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
