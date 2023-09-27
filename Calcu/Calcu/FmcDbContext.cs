using Calcu.Models;
using Microsoft.EntityFrameworkCore;

namespace Calcu
{
    public class FmcDbContext : DbContext
    {
        public FmcDbContext(DbContextOptions options) : base(options) { }
        public DbSet<IntentosCalculo> IntentosCalculo { get; set; }
    }
}
