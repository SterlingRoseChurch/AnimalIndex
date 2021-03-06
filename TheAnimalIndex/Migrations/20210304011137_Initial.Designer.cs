// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheAnimalIndex.Models;

namespace TheAnimalIndex.Migrations
{
    [DbContext(typeof(AnimalContext))]
    [Migration("20210304011137_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheAnimalIndex.Models.Animals", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AnimalId");

                    b.HasIndex("TypeId");

                    b.ToTable("Animalss");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Species = "Tiger",
                            TypeId = "M"
                        },
                        new
                        {
                            AnimalId = 2,
                            Species = "Tuna",
                            TypeId = "F"
                        },
                        new
                        {
                            AnimalId = 3,
                            Species = "Frog",
                            TypeId = "A"
                        });
                });

            modelBuilder.Entity("TheAnimalIndex.Models.Type", b =>
                {
                    b.Property<string>("TypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            TypeId = "M",
                            Name = "Mammal"
                        },
                        new
                        {
                            TypeId = "B",
                            Name = "Bird"
                        },
                        new
                        {
                            TypeId = "R",
                            Name = "Reptile"
                        },
                        new
                        {
                            TypeId = "A",
                            Name = "Amphimbian"
                        },
                        new
                        {
                            TypeId = "I",
                            Name = "Invertebrate"
                        },
                        new
                        {
                            TypeId = "F",
                            Name = "Fish"
                        });
                });

            modelBuilder.Entity("TheAnimalIndex.Models.Animals", b =>
                {
                    b.HasOne("TheAnimalIndex.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
