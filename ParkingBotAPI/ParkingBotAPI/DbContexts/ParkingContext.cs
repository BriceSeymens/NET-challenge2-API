using Microsoft.EntityFrameworkCore;
using ParkingBotAPI.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ParkingBotAPI.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) { }

        public DbSet<ParkingGarage> ParkingGarages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Garage)
                .WithMany(g => g.Reservations)
                .HasForeignKey(r => r.ParkingId);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.ReservationId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.StartDate)
                .HasColumnType("date");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.EndDate)
                .HasColumnType("date");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.StartTime)
                .HasColumnType("time");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.EndTime)
                .HasColumnType("time");

            // Seed data
            modelBuilder.Entity<ParkingGarage>().HasData(
                new ParkingGarage { ParkingId = 1, City = "New York", Address = "123 Main St", MaxPlaces = 100 },
                new ParkingGarage { ParkingId = 2, City = "Los Angeles", Address = "456 Sunset Blvd", MaxPlaces = 150 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                new Customer { CustomerId = 2, Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210" }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = Guid.NewGuid(),
                    CustomerId = 1,
                    ParkingId = 1,
                    LicensePlate = "ABC123",
                    StartDate = new DateTime(2024, 12, 15),
                    EndDate = new DateTime(2024, 12, 15),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0)
                },
                new Reservation
                {
                    ReservationId = Guid.NewGuid(),
                    CustomerId = 2,
                    ParkingId = 2,
                    LicensePlate = "XYZ789",
                    StartDate = new DateTime(2024, 12, 16),
                    EndDate = new DateTime(2024, 12, 16),
                    StartTime = new TimeSpan(8, 30, 0),
                    EndTime = new TimeSpan(12, 30, 0)
                }
            );
        }
    }
}
