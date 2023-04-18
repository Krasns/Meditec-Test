using Meditec.Models;
using Microsoft.EntityFrameworkCore;

namespace Meditec.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<PublicHolidayDbModel> PublicHoliday { get; set; }
    }
}
