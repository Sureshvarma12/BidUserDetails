using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BidUser.Models
{
    public class BidUserContext:IdentityDbContext<ApplicationUser>
    {

        public BidUserContext(DbContextOptions<BidUserContext> options) : base(options)
        {
            
        }
    }
}
