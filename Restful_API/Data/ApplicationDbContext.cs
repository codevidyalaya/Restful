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

        public DbSet<Category> Category { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<StudyStatus> StudyStatus { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Gender> Gender { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "India" }
            );
            modelBuilder.Entity<State>().HasData(
                new State() { Id = 1, Name = "Karnataka" }
            );
            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Bangalore" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "General" },
                new Category() { Id = 2, Name = "SC" },
                new Category() { Id = 3, Name = "ST" },
                new Category() { Id = 4, Name = "OBC" },
                new Category() { Id = 5, Name = "Others" }
            );
            modelBuilder.Entity<Religion>().HasData(
                new Religion() { Id = 1, Name = "Hindu" },
                new Religion() { Id = 2, Name = "Muslim" },
                new Religion() { Id = 3, Name = "Sikh" },
                new Religion() { Id = 4, Name = "Christian" },
                new Religion() { Id = 5, Name = "Others" }
            );
            modelBuilder.Entity<StudyStatus>().HasData(
                new StudyStatus() { Id = 1, Name = "Study" }
            );
            modelBuilder.Entity<Gender>().HasData(
               new Gender() { Id = 1, Name = "Male" },
               new Gender() { Id = 2, Name = "Female" }
            );

            modelBuilder.Entity<Class>().HasData(
              new Class() { Id = 1, Name = "Daycare" },
              new Class() { Id = 2, Name = "Playgroup" },
              new Class() { Id = 3, Name = "Nursery" },
              new Class() { Id = 4, Name = "LKG" },
              new Class() { Id = 5, Name = "UKG" }
            );

            modelBuilder.Entity<Section>().HasData(
             new Class() { Id = 1, Name = "A" }
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
