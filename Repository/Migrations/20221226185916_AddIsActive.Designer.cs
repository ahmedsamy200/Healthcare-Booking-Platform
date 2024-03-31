﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221226185916_AddIsActive")]
    partial class AddIsActive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Appointments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("dayAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("doctorID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("from")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("doctorID");

                    b.HasIndex("userID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Domain.ClinicPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("doctorID")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("doctorID");

                    b.ToTable("ClinicPhotos");
                });

            modelBuilder.Entity("Domain.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("massage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("Domain.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("cityID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("services")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("specializationID")
                        .HasColumnType("int");

                    b.Property<string>("subDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("views")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("cityID");

                    b.HasIndex("specializationID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Domain.DoctorAppointments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("dayAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dayEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("doctorID")
                        .HasColumnType("int");

                    b.Property<int?>("duration")
                        .HasColumnType("int");

                    b.Property<DateTime?>("from")
                        .HasColumnType("datetime2");

                    b.Property<int?>("order")
                        .HasColumnType("int");

                    b.Property<DateTime?>("to")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("doctorID");

                    b.ToTable("DoctorAppointments");
                });

            modelBuilder.Entity("Domain.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("doctorID")
                        .HasColumnType("int");

                    b.Property<string>("mainPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("subTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("doctorID");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("Domain.OfferPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("offerID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("offerID");

                    b.ToTable("OfferPhotos");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("doctorID")
                        .HasColumnType("int");

                    b.Property<float?>("rate")
                        .HasColumnType("real");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("doctorID");

                    b.HasIndex("userID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Domain.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Appointments", b =>
                {
                    b.HasOne("Domain.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("doctorID");

                    b.HasOne("Domain.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("userID");

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.ClinicPhotos", b =>
                {
                    b.HasOne("Domain.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("doctorID");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Domain.Doctor", b =>
                {
                    b.HasOne("Domain.City", "City")
                        .WithMany("Doctors")
                        .HasForeignKey("cityID");

                    b.HasOne("Domain.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("specializationID");

                    b.Navigation("City");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Domain.DoctorAppointments", b =>
                {
                    b.HasOne("Domain.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("doctorID");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Domain.Offer", b =>
                {
                    b.HasOne("Domain.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("doctorID");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Domain.OfferPhotos", b =>
                {
                    b.HasOne("Domain.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("offerID");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.HasOne("Domain.Doctor", "Doctor")
                        .WithMany("Reviews")
                        .HasForeignKey("doctorID");

                    b.HasOne("Domain.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("userID");

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Domain.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
