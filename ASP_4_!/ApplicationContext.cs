using ASP_4__.Objects;
using Microsoft.EntityFrameworkCore;

namespace ASP_4__
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Zoo> Zoo { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;

        public DbSet<Ticket> Ticket { get; set; } = null!;

        public DbSet<Type_Animal> Type_Animal { get; set; } = null!;

        public DbSet<Worker> Worker { get; set; } = null!;

        public DbSet<Aviary> Aviary { get; set; } = null!;

        public DbSet<Animal> Animal { get; set; } = null!;



        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zoo>().HasData(
                    new Zoo { Id = 1, Name = "12 month", Workers_Ammount = 2, Aviary_Ammount = 2 },
                    new Zoo { Id = 2, Name = "Kyiv", Workers_Ammount = 4,  Aviary_Ammount = 2 },
                    new Zoo { Id = 3, Name = "International", Workers_Ammount = 8,  Aviary_Ammount = 2 }
            );
        }

    }
}
