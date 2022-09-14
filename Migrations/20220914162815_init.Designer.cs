﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaProjectFinalProject.Data;

namespace SpaProjectFinalProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220914162815_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.AdoptionCenter", b =>
                {
                    b.Property<int>("AdoptionCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("AdoptionCenterId");

                    b.ToTable("AdoptionCenter");

                    b.HasData(
                        new
                        {
                            AdoptionCenterId = 1,
                            Name = "Moeskroen DierenAsiel",
                            PhoneNumber = "05645555",
                            Place = "Moeskroen",
                            PostCode = "8000",
                            Rate = 3
                        },
                        new
                        {
                            AdoptionCenterId = 2,
                            Name = "Brussel DierenAsiel",
                            PhoneNumber = "056789345",
                            Place = "Brussel",
                            PostCode = "8000",
                            Rate = 3
                        },
                        new
                        {
                            AdoptionCenterId = 3,
                            Name = "Antwerpen DierenAsiel",
                            PhoneNumber = "04262722",
                            Place = "Antwerpen",
                            PostCode = "8000",
                            Rate = 3
                        },
                        new
                        {
                            AdoptionCenterId = 4,
                            Name = "Luik DierenAsiel",
                            PhoneNumber = "0468787976",
                            Place = "Luik",
                            PostCode = "8000",
                            Rate = 3
                        });
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdoptionCenterId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLost")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Terms")
                        .HasColumnType("bit");

                    b.HasKey("AnimalId");

                    b.HasIndex("AdoptionCenterId");

                    b.ToTable("Animal");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            AdoptionCenterId = 1,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(925),
                            Description = "Beautiful Dog",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Iris",
                            NamePath = "Iris.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Iris.jpg",
                            Race = "Shepherd",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 2,
                            AdoptionCenterId = 2,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2679),
                            Description = "Beautiful Dog",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Ultia",
                            NamePath = "Dog2.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Dog2.jpg",
                            Race = "Bulldog",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 3,
                            AdoptionCenterId = 3,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2726),
                            Description = "Beautiful Dog",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Gon",
                            NamePath = "Dog3.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Dog3.jpg",
                            Race = "Golden retriever",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 4,
                            AdoptionCenterId = 4,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2728),
                            Description = "Beautiful Rabbit",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Lea",
                            NamePath = "Rabbit1.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Rabbit1.jpg",
                            Race = "Rabbit",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 5,
                            AdoptionCenterId = 2,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2731),
                            Description = "Beautiful Rabbit",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Sasuke",
                            NamePath = "Rabbit2.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Rabbit2.jpg",
                            Race = "Rabbit",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 6,
                            AdoptionCenterId = 1,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2732),
                            Description = "Beautiful Rabbit",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Walter",
                            NamePath = "Rabbit3.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Rabbit3.jpg",
                            Race = "Rabbit",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 7,
                            AdoptionCenterId = 4,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2734),
                            Description = "Beautiful Cat",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Snowball",
                            NamePath = "Zaho.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Zaho.jpg",
                            Race = "Cat",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 8,
                            AdoptionCenterId = 3,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2736),
                            Description = "Beautiful Cat",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Ibrahim",
                            NamePath = "Cat2.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Cat2.jpg",
                            Race = "Cat",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 9,
                            AdoptionCenterId = 2,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2738),
                            Description = "Beautiful Cat",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Ibrahim",
                            NamePath = "Cat3.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Cat3.jpg",
                            Race = "Cat",
                            Terms = false
                        },
                        new
                        {
                            AnimalId = 10,
                            AdoptionCenterId = 1,
                            BirthDate = new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2740),
                            Description = "Beautiful Cat",
                            IsLost = false,
                            IsVaccinated = true,
                            Name = "Ibrahim",
                            NamePath = "Cat4.jpg",
                            Path = "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Cat4.jpg",
                            Race = "Cat",
                            Terms = false
                        });
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.AnimalLost", b =>
                {
                    b.Property<int>("AnimalLostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimalLostDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimalLostName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateLost")
                        .HasColumnType("datetime2");

                    b.Property<string>("NamePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("AnimalLostId");

                    b.HasIndex("PersonId");

                    b.ToTable("AnimalsLost");

                    b.HasData(
                        new
                        {
                            AnimalLostId = 1,
                            AnimalLostDescription = "IsLost",
                            AnimalLostName = "iris",
                            DateLost = new DateTime(2022, 9, 14, 18, 28, 15, 472, DateTimeKind.Local).AddTicks(6238),
                            NamePath = "LostDog.jpg",
                            Path = "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostDog.jpg",
                            PersonId = 1
                        },
                        new
                        {
                            AnimalLostId = 2,
                            AnimalLostDescription = "IsLost",
                            AnimalLostName = "iris",
                            DateLost = new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4687),
                            NamePath = "LostRabbit.jpg",
                            Path = "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostRabbit.jpg",
                            PersonId = 1
                        },
                        new
                        {
                            AnimalLostId = 3,
                            AnimalLostDescription = "IsLost",
                            AnimalLostName = "iris",
                            DateLost = new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4748),
                            NamePath = "Lostrabbit2.jpg",
                            Path = "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostRabbit2.jpg",
                            PersonId = 1
                        },
                        new
                        {
                            AnimalLostId = 4,
                            AnimalLostDescription = "IsLost",
                            AnimalLostName = "iris",
                            DateLost = new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4754),
                            NamePath = "LostRabbit3.jpg",
                            Path = "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostRabbit3.jpg",
                            PersonId = 1
                        },
                        new
                        {
                            AnimalLostId = 5,
                            AnimalLostDescription = "IsLost",
                            AnimalLostName = "iris",
                            DateLost = new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4757),
                            NamePath = "LostDog.jpg",
                            Path = "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostDog.jpg",
                            PersonId = 1
                        });
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("HaveAnimal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Address = "Kortrijk",
                            Age = 22,
                            Email = "Florian@",
                            Gender = false,
                            HaveAnimal = false,
                            Name = "Florian",
                            Number = "0492535211",
                            PostCode = "8587"
                        },
                        new
                        {
                            PersonId = 2,
                            Address = "Moeskroen",
                            Age = 20,
                            Email = "celia@",
                            Gender = true,
                            HaveAnimal = false,
                            Name = "Celia",
                            Number = "056457176",
                            PostCode = "7700"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaProjectFinalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.Animal", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.AdoptionCenter", "AdoptionCenter")
                        .WithMany("Animals")
                        .HasForeignKey("AdoptionCenterId");
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.AnimalLost", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.Person", "Person")
                        .WithMany("AnimalLost")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.Event", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.Animal", "Animal")
                        .WithMany("Event")
                        .HasForeignKey("AnimalId");

                    b.HasOne("SpaProjectFinalProject.Models.ApplicationUser", "User")
                        .WithMany("Event")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SpaProjectFinalProject.Models.Person", b =>
                {
                    b.HasOne("SpaProjectFinalProject.Models.Animal", null)
                        .WithMany("Persons")
                        .HasForeignKey("AnimalId");
                });
#pragma warning restore 612, 618
        }
    }
}
