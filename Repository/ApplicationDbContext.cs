using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
         : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Appointments>()
        //        .HasOne<User>(s => s.User)
        //        .WithMany(g => g.Appointments)
        //        .HasForeignKey(s => s.userID)
        //        .OnDelete(DeleteBehavior.ClientCascade);

        //    modelBuilder.Entity<Appointments>()
        //        .HasOne<Doctor>(s => s.Doctor)
        //        .WithMany(g => g.Appointments)
        //        .HasForeignKey(s => s.doctorID)
        //        .OnDelete(DeleteBehavior.ClientCascade);

        //    modelBuilder.Entity<Review>()
        //        .HasOne<User>(s => s.User)
        //        .WithMany(g => g.Reviews)
        //        .HasForeignKey(s => s.userID)
        //        .OnDelete(DeleteBehavior.ClientCascade);

        //    modelBuilder.Entity<Review>()
        //        .HasOne<Doctor>(s => s.Doctor)
        //        .WithMany(g => g.Reviews)
        //        .HasForeignKey(s => s.doctorID)
        //        .OnDelete(DeleteBehavior.ClientCascade);

        //}

        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ClinicPhotos> ClinicPhotos { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<DoctorAppointments> DoctorAppointments { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<OfferPhotos> OfferPhotos { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }

}
