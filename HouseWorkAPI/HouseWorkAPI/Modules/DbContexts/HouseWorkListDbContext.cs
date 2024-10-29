using HouseWorkAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseWorkAPI.Modules.DbContexts
{
    public class HouseWorkListDbContext(DbContextOptions<HouseWorkListDbContext> options) : DbContext(options)
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<HouseWork> HouseWorks { get; set; }
    }
}
