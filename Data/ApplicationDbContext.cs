using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaProjectFinalProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpaProjectFinalProject.Data
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AdoptionCenter>().HasData(
                new AdoptionCenter { AdoptionCenterId = 1, Name = "Moeskroen DierenAsiel", PhoneNumber = "05645555", Place = "Moeskroen", PostCode = "8000", Rate = 3 },
                new AdoptionCenter { AdoptionCenterId = 2, Name = "Brussel DierenAsiel", PhoneNumber = "056789345", Place = "Brussel", PostCode = "8000", Rate = 3 },
                new AdoptionCenter { AdoptionCenterId = 3, Name = "Antwerpen DierenAsiel", PhoneNumber = "04262722", Place = "Antwerpen", PostCode = "8000", Rate = 3 },
                new AdoptionCenter { AdoptionCenterId = 4, Name = "Luik DierenAsiel", PhoneNumber = "0468787976", Place = "Luik", PostCode = "8000", Rate = 3 }
            );
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, Name = "Iris", Race = "Shepherd", Description = "Beautiful Dog", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Iris.jpg", NamePath = "Iris.jpg", IsLost = false, AdoptionCenterId = 1 },
                new Animal { AnimalId = 2, Name = "Ultia", Race = "Bulldog", Description = "Beautiful Dog", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Dog2.jpg", NamePath = "Dog2.jpg", AdoptionCenterId = 2 },
                new Animal { AnimalId = 3, Name = "Gon", Race = "Golden retriever", Description = "Beautiful Dog", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Dog3.jpg", NamePath = "Dog3.jpg", AdoptionCenterId = 3 },
                new Animal { AnimalId = 4, Name = "Lea", Race = "Rabbit", Description = "Beautiful Rabbit", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Rabbit1.jpg", NamePath = "Rabbit1.jpg", AdoptionCenterId = 4 },
                new Animal { AnimalId = 5, Name = "Sasuke", Race = "Rabbit", Description = "Beautiful Rabbit", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Rabbit2.jpg", NamePath = "Rabbit2.jpg", AdoptionCenterId = 2 },
                new Animal { AnimalId = 6, Name = "Walter", Race = "Rabbit", Description = "Beautiful Rabbit", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Rabbit3.jpg", NamePath = "Rabbit3.jpg", AdoptionCenterId = 1 },
                new Animal { AnimalId = 7, Name = "Snowball", Race = "Cat", Description = "Beautiful Cat", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Zaho.jpg", NamePath = "Zaho.jpg", AdoptionCenterId = 4 },
                new Animal { AnimalId = 8, Name = "Ibrahim", Race = "Cat", Description = "Beautiful Cat", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Cat2.jpg", NamePath = "Cat2.jpg", AdoptionCenterId = 3 },
                new Animal { AnimalId = 9, Name = "Ibrahim", Race = "Cat", Description = "Beautiful Cat", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Cat3.jpg", NamePath = "Cat3.jpg", AdoptionCenterId = 2 },
                new Animal { AnimalId = 10, Name = "Ibrahim", Race = "Cat", Description = "Beautiful Cat", BirthDate = DateTime.UtcNow, IsVaccinated = true, Path = @"C:\Users\florian\source\repos\SpaProject\SpaProject\wwwroot\images\Cat4.jpg", NamePath = "Cat4.jpg", AdoptionCenterId = 1 }
                );
            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, Age = 22, Email = "Florian@", Gender = false, PostCode = "8587", Name = "Florian", Address = "Kortrijk", HaveAnimal = false,Number="0492535211"},
                new Person { PersonId = 2, Age = 20, Email = "celia@", Gender = true, PostCode = "7700", Name = "Celia", Address = "Moeskroen", HaveAnimal = false,Number="056457176" }
            );
            modelBuilder.Entity<AnimalLost>().HasData(
                new AnimalLost {AnimalLostId =1,AnimalLostName ="iris",DateLost = DateTime.Now,Path = @"C:\Intec\Data\SpaProjectFinalProjectcsss-master\wwwroot\images\LostDog.jpg", NamePath="LostDog.jpg",AnimalLostDescription="IsLost",PersonId=1 },
                new AnimalLost {AnimalLostId =2,AnimalLostName ="iris",DateLost = DateTime.Now,NamePath ="LostRabbit.jpg",Path=@"C:\Intec\Data\SpaProjectFinalProjectcsss-master\wwwroot\images\LostRabbit.jpg",AnimalLostDescription="IsLost",PersonId=1 },
                new AnimalLost {AnimalLostId =3,AnimalLostName ="iris",DateLost = DateTime.Now,NamePath ="Lostrabbit2.jpg",Path=@"C:\Intec\Data\SpaProjectFinalProjectcsss-master\wwwroot\images\LostRabbit2.jpg",AnimalLostDescription="IsLost",PersonId=1 },
                new AnimalLost {AnimalLostId =4,AnimalLostName ="iris",DateLost = DateTime.Now,NamePath ="LostRabbit3.jpg",Path=@"C:\Intec\Data\SpaProjectFinalProjectcsss-master\wwwroot\images\LostRabbit3.jpg",AnimalLostDescription="IsLost",PersonId=1 },
                new AnimalLost {AnimalLostId =5,AnimalLostName ="iris",DateLost = DateTime.Now,NamePath ="LostDog.jpg",Path= @"C:\Intec\Data\SpaProjectFinalProjectcsss-master\wwwroot\images\LostDog.jpg", AnimalLostDescription="IsLost",PersonId=1 }
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString)
                              .UseLazyLoadingProxies();
            }
        }
        public DbSet<Animal> AdoptionCenters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<AnimalLost> AnimalsLost { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Event> Event { get; set; }


    }
}
