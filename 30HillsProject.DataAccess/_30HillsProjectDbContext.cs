using _30HillsProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace _30HillsProject.DataAccess
{
    public class _30HillsProjectDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BOHUG24;Initial Catalog=HillsProject;Integrated Security=True;TrustServerCertificate=True");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<User> Users { get; set; }
    }
}