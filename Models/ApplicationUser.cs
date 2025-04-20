using Microsoft.AspNetCore.Identity;

namespace BidUser.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string? UserID { get; set; }

        public string? BidderNumber { get; set; }
        public Boolean? IsActive { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        //public string? Email { get; set; }
        //public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
