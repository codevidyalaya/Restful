using Microsoft.EntityFrameworkCore;
using Restful_API.Models.Entities;
using Restful_API.Models.Entities.Master;

namespace Restful_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<School> School { get; set; }
        public DbSet<Student> Student { get; set; }

        #region master
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country() {  Id = 1, Name = "India" }
            );
            modelBuilder.Entity<State>().HasData(
                new State() { Id = 1, Name = "Karnataka" }
            );
            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Bangalore" }
            );

            modelBuilder.Entity<School>().HasData(
                new School()
                {
                    Id = 1,
                    ContactPersonName = "Satya Prakash Tripathi",
                    ContactPersonNumber = "8951021503",
                    ContactPersonEmail = "codevidyalaya@gmail.com",
                    Name = "School",
                    PhoneNumber = "8951021503",
                    ContactNumber = "8951021503",
                    Address = "Address",
                    State = 1,
                    City = 1,
                    PinCode = "563014",
                    CreatedDate = new DateTime()
                }
            );
        }
    }
}
