using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BidUser.Models
{
    public class BidUserContext:IdentityDbContext<ApplicationUser>
    {

        public BidUserContext()
        {
            
        }
    }
}
