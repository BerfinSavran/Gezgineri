﻿// <auto-generated />
using System;
using Gezgineri.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gezgineri.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241212105602_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gezgineri.Entity.Models.Agency", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicenseNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("TaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("WebSiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MemberId");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Member", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.MyTravel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TravelerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TravelerId");

                    b.ToTable("MyTravels");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Owner", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicenseNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemberId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Place", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApprovedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("EntryPrice")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("VisitDuration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Tour", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApprovedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AgencyId");

                    b.HasIndex("ApprovedById");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.TourRoute", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TourId");

                    b.ToTable("TourRoutes");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.TravelPlan", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MyTravelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("MyTravelId");

                    b.ToTable("TravelPlans");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.TravelPlanPlace", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TravelPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TravelPlanId");

                    b.ToTable("TravelPlanPlaces");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Traveler", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemberId");

                    b.ToTable("Travelers");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Agency", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.MyTravel", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Traveler", "Traveler")
                        .WithMany()
                        .HasForeignKey("TravelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Traveler");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Owner", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Place", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Member", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById");

                    b.HasOne("Gezgineri.Entity.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gezgineri.Entity.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovedBy");

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Tour", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gezgineri.Entity.Models.Member", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById");

                    b.Navigation("Agency");

                    b.Navigation("ApprovedBy");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.TourRoute", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.TravelPlan", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.MyTravel", "MyTravel")
                        .WithMany()
                        .HasForeignKey("MyTravelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MyTravel");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.TravelPlanPlace", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Gezgineri.Entity.Models.TravelPlan", "TravelPlan")
                        .WithMany()
                        .HasForeignKey("TravelPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("TravelPlan");
                });

            modelBuilder.Entity("Gezgineri.Entity.Models.Traveler", b =>
                {
                    b.HasOne("Gezgineri.Entity.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });
#pragma warning restore 612, 618
        }
    }
}
