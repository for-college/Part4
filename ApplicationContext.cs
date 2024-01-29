using Microsoft.EntityFrameworkCore;

namespace Part4
{
    public class ApplicationContext : DbContext
    {
        public string connectionString = "Data Source=part4.db";

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        // 4 пункт в главе
        /** 
         *  public DbSet<User> Users { get; set; } = null!;
            public DbSet<Company> Companies { get; set; } = null!;
            public DbSet<City> Cities { get; set; } = null!;
            public DbSet<Country> Countries { get; set; } = null!;
            public DbSet<Position> Positions { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=helloapp.db");
            }
        **/
    }
}