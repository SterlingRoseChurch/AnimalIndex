using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheAnimalIndex.Models
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        { }

        public DbSet<Animals> Animalss { get; set; }
        public DbSet<Type> Types { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Type>().HasData(
                 new Type { TypeId = "M", Name = "Mammal" },
                 new Type { TypeId = "B", Name = "Bird"},
                 new Type { TypeId = "R", Name = "Reptile"},
                 new Type { TypeId = "A", Name = "Amphimbian"},
                 new Type { TypeId = "I", Name = "Invertebrate"},
                 new Type { TypeId = "F", Name = "Fish"}
             );

            modelBuilder.Entity<Animals>().HasData(
                new Animals
                {
                    AnimalId = 1,
                    Species = "Tiger",
                    TypeId = "M"

                },
                new Animals
                {
                    AnimalId = 2,
                    Species = "Tuna",
                    TypeId = "F"
                },
                new Animals
                {
                    AnimalId = 3,
                    Species = "Frog",
                    TypeId = "A"
                }
            );
        }
    
    }
}
