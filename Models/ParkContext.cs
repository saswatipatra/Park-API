using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class ParksContext : DbContext
    {
        public DbSet<State> States { get; set; }
        public DbSet<NationalPark> NationalParks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMysql(@"server=localhost;user id=root;password=epicodus;port=3306;database=parks;");

        public ParksContext(DbContextOptions options) : base(options)
        {

        }
        public ParksContext()
        {

        }
    }
}
