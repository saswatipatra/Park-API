﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parks.Models;

namespace Parks.Solution.Migrations
{
    [DbContext(typeof(ParksContext))]
    partial class ParksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Parks.Models.NationalPark", b =>
                {
                    b.Property<int>("NationalParkId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AvgRating");

                    b.Property<string>("ParkName");

                    b.Property<int>("StateId");

                    b.HasKey("NationalParkId");

                    b.HasIndex("StateId");

                    b.ToTable("nationalPark");
                });

            modelBuilder.Entity("Parks.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NationalParkId");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewText");

                    b.Property<int>("StateId");

                    b.Property<string>("UserName");

                    b.HasKey("ReviewId");

                    b.HasIndex("NationalParkId");

                    b.HasIndex("StateId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Parks.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("StateName");

                    b.HasKey("StateId");

                    b.ToTable("states");
                });

            modelBuilder.Entity("Parks.Models.NationalPark", b =>
                {
                    b.HasOne("Parks.Models.State")
                        .WithMany("NationalParks")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Parks.Models.Review", b =>
                {
                    b.HasOne("Parks.Models.NationalPark")
                        .WithMany("Reviews")
                        .HasForeignKey("NationalParkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Parks.Models.State")
                        .WithMany("Reviews")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
