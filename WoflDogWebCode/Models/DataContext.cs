using Microsoft.EntityFrameworkCore;

namespace WoflDogWebCode.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    }
}
