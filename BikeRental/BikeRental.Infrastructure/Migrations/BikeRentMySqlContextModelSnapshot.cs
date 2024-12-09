﻿// <auto-generated />
using System;
using BikeRental.Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeRental.Infrastructure.Migrations
{
    [DbContext(typeof(BikeRentMySqlContext))]
    partial class BikeRentMySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BikeRental.Domain.Model.Bike", b =>
                {
                    b.Property<int>("SerialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SerialNumber"));

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<decimal>("CostPerPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber");

                    b.ToTable("Bikes");

                    b.HasData(
                        new
                        {
                            SerialNumber = 1,
                            Color = "Red",
                            CostPerPrice = 1500m,
                            Model = "X-Trail 500",
                            Type = 1
                        },
                        new
                        {
                            SerialNumber = 2,
                            Color = "Blue",
                            CostPerPrice = 1000m,
                            Model = "EasyRide 200",
                            Type = 2
                        },
                        new
                        {
                            SerialNumber = 3,
                            Color = "Black",
                            CostPerPrice = 2000m,
                            Model = "Speedster 3000",
                            Type = 3
                        },
                        new
                        {
                            SerialNumber = 4,
                            Color = "Green",
                            CostPerPrice = 3000m,
                            Model = "Racer Pro 9000",
                            Type = 3
                        },
                        new
                        {
                            SerialNumber = 5,
                            Color = "Yellow",
                            CostPerPrice = 1200m,
                            Model = "RockClimber X",
                            Type = 1
                        },
                        new
                        {
                            SerialNumber = 6,
                            Color = "White",
                            CostPerPrice = 4000m,
                            Model = "City Explorer",
                            Type = 2
                        });
                });

            modelBuilder.Entity("BikeRental.Domain.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customesrs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(1990, 5, 20),
                            FullName = "Тест Тестов",
                            PhoneNumber = "88005553535"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateOnly(1985, 3, 15),
                            FullName = "Дима Нова",
                            PhoneNumber = "88005553530"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateOnly(2000, 12, 1),
                            FullName = "Иероним Карл Фридрих фон Мюнхгаузен",
                            PhoneNumber = "718005553535"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateOnly(1995, 7, 15),
                            FullName = "Alice Johnson",
                            PhoneNumber = "555-123-9876"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateOnly(1992, 11, 25),
                            FullName = "Chris Evans",
                            PhoneNumber = "444-321-8765"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateOnly(1988, 2, 5),
                            FullName = "Emma Wilson",
                            PhoneNumber = "333-987-6543"
                        });
                });

            modelBuilder.Entity("BikeRental.Domain.Model.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BikeId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BikeId = 1,
                            CustomerId = 1,
                            End = new DateTime(2024, 12, 9, 21, 20, 32, 149, DateTimeKind.Local).AddTicks(2253),
                            Start = new DateTime(2024, 12, 9, 17, 20, 32, 149, DateTimeKind.Local).AddTicks(2252)
                        },
                        new
                        {
                            Id = 2,
                            BikeId = 2,
                            CustomerId = 2,
                            End = new DateTime(2024, 12, 9, 22, 20, 32, 149, DateTimeKind.Local).AddTicks(2262),
                            Start = new DateTime(2024, 12, 9, 18, 20, 32, 149, DateTimeKind.Local).AddTicks(2261)
                        },
                        new
                        {
                            Id = 3,
                            BikeId = 3,
                            CustomerId = 3,
                            End = new DateTime(2024, 12, 9, 20, 20, 32, 149, DateTimeKind.Local).AddTicks(2265),
                            Start = new DateTime(2024, 12, 9, 16, 20, 32, 149, DateTimeKind.Local).AddTicks(2264)
                        },
                        new
                        {
                            Id = 4,
                            BikeId = 4,
                            CustomerId = 4,
                            End = new DateTime(2024, 12, 9, 23, 20, 32, 149, DateTimeKind.Local).AddTicks(2268),
                            Start = new DateTime(2024, 12, 9, 15, 20, 32, 149, DateTimeKind.Local).AddTicks(2267)
                        },
                        new
                        {
                            Id = 5,
                            BikeId = 5,
                            CustomerId = 5,
                            End = new DateTime(2024, 12, 10, 1, 20, 32, 149, DateTimeKind.Local).AddTicks(2271),
                            Start = new DateTime(2024, 12, 9, 17, 20, 32, 149, DateTimeKind.Local).AddTicks(2270)
                        },
                        new
                        {
                            Id = 6,
                            BikeId = 6,
                            CustomerId = 6,
                            End = new DateTime(2024, 12, 10, 0, 20, 32, 149, DateTimeKind.Local).AddTicks(2275),
                            Start = new DateTime(2024, 12, 9, 18, 20, 32, 149, DateTimeKind.Local).AddTicks(2274)
                        });
                });

            modelBuilder.Entity("BikeRental.Domain.Model.Rent", b =>
                {
                    b.HasOne("BikeRental.Domain.Model.Bike", "Bike")
                        .WithMany()
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeRental.Domain.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}