using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CarService;

namespace CarService.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    partial class CarsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarService.Model.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarService.Model.CarCreatedEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CarId");

                    b.Property<Guid>("EntityId");

                    b.Property<DateTime>("EventTime");

                    b.Property<string>("SerializedPayload");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarCreatedEvent");
                });

            modelBuilder.Entity("CarService.Model.CarCreatedEvent", b =>
                {
                    b.HasOne("CarService.Model.Car")
                        .WithMany("Events")
                        .HasForeignKey("CarId");
                });
        }
    }
}
