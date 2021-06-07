﻿// <auto-generated />
using System;
using KabadaAPI.DataSource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KabadaAPI.DataSource.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210604122958_AddedSharedPlan")]
    partial class AddedSharedPlan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.BusinessPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Completed")
                        .HasColumnType("int");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("Img")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Public")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("UserId");

                    b.ToTable("BusinessPlans");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7947eb99-e61a-431c-9b66-cc1e0e5b4e6e"),
                            ShortCode = "AT",
                            Title = "Austria"
                        },
                        new
                        {
                            Id = new Guid("71b7f9ec-9df4-4fd6-91a8-4d6e999f1479"),
                            ShortCode = "BA",
                            Title = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            Id = new Guid("35f40fa3-0222-4275-a640-ff135a3d5e7b"),
                            ShortCode = "BE",
                            Title = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("10947744-1d19-4ac7-9c41-02de4c745eba"),
                            ShortCode = "BG",
                            Title = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("eb9c6bf4-7dc6-4b38-a039-0e0ef1f01372"),
                            ShortCode = "HR",
                            Title = "Croatia"
                        },
                        new
                        {
                            Id = new Guid("8437eaaf-804a-4e40-8c49-f6b1a2937df5"),
                            ShortCode = "CY",
                            Title = "Cyprus"
                        },
                        new
                        {
                            Id = new Guid("872af87c-eea1-4d30-baa1-0721bbb16bfe"),
                            ShortCode = "CZ",
                            Title = "Czechia"
                        },
                        new
                        {
                            Id = new Guid("27823f9e-a42e-4289-ae57-b79e5a521096"),
                            ShortCode = "DK",
                            Title = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("9835ca9c-2ebe-410b-8cf5-4652d9237730"),
                            ShortCode = "EE",
                            Title = "Estonia"
                        },
                        new
                        {
                            Id = new Guid("0824ab4c-5bd7-4044-833e-c9e790ee67b3"),
                            ShortCode = "FI",
                            Title = "Finland"
                        },
                        new
                        {
                            Id = new Guid("658d3ad0-ef1d-4bea-9597-f1b1f44f6946"),
                            ShortCode = "FR",
                            Title = "France"
                        },
                        new
                        {
                            Id = new Guid("48ced809-5294-4bed-a90a-3f2afd7b7228"),
                            ShortCode = "DE",
                            Title = "Germany"
                        },
                        new
                        {
                            Id = new Guid("5c17fe1c-296c-4f8e-9888-789f3559534f"),
                            ShortCode = "EL",
                            Title = "Greece"
                        },
                        new
                        {
                            Id = new Guid("cbf9f1b2-a7be-4b2d-81f2-e59c086441b2"),
                            ShortCode = "HU",
                            Title = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("d3078b28-eb08-4d5a-a1f4-1c843da82059"),
                            ShortCode = "IS",
                            Title = "Iceland"
                        },
                        new
                        {
                            Id = new Guid("5f14cbe1-bf8b-4046-baaf-743fa1802023"),
                            ShortCode = "IE",
                            Title = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("51798121-a63e-45ea-ab14-5956eb606be5"),
                            ShortCode = "IT",
                            Title = "Italy"
                        },
                        new
                        {
                            Id = new Guid("59c1db11-f27a-4c66-9bce-2e7329585cc3"),
                            ShortCode = "LV",
                            Title = "Latvia"
                        },
                        new
                        {
                            Id = new Guid("711d2ab0-5f07-49ea-8c15-e4446dfde001"),
                            ShortCode = "LI",
                            Title = "Liechtenstein"
                        },
                        new
                        {
                            Id = new Guid("7a993fa7-5fd0-4f8f-83a0-53d3c1191dca"),
                            ShortCode = "LT",
                            Title = "Lithuania"
                        },
                        new
                        {
                            Id = new Guid("14f8ece7-d2ae-4178-a156-066a1821d5ef"),
                            ShortCode = "LU",
                            Title = "Luxembourg"
                        },
                        new
                        {
                            Id = new Guid("ce05ca02-cebb-4a06-841c-adfa28de9f04"),
                            ShortCode = "MT",
                            Title = "Malta"
                        },
                        new
                        {
                            Id = new Guid("a0f7e2cf-a87d-4dc4-b0df-460070088730"),
                            ShortCode = "NL",
                            Title = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("f7cd6b83-af2a-4218-bda1-81978aad3431"),
                            ShortCode = "MK",
                            Title = "North Macedonia"
                        },
                        new
                        {
                            Id = new Guid("43288f2c-bf73-4f91-aa5b-9dab264ccb24"),
                            ShortCode = "NO",
                            Title = "Norway"
                        },
                        new
                        {
                            Id = new Guid("1b21573b-c588-4bf8-8be9-cac65f8a57bc"),
                            ShortCode = "PL",
                            Title = "Poland"
                        },
                        new
                        {
                            Id = new Guid("9159a305-a9ee-48cf-b5b8-ad003326afb6"),
                            ShortCode = "PT",
                            Title = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("734272a8-72ef-4951-b8a9-7ace3abe0bcc"),
                            ShortCode = "RO",
                            Title = "Romania"
                        },
                        new
                        {
                            Id = new Guid("6485f7f2-b8a1-40d2-9004-9f5e76333673"),
                            ShortCode = "RS",
                            Title = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("72f5e3d9-4ca3-47da-8def-70e54350249c"),
                            ShortCode = "SK",
                            Title = "Slovakia"
                        },
                        new
                        {
                            Id = new Guid("34d29e86-9d37-425a-b4f8-5622858b23bd"),
                            ShortCode = "SI",
                            Title = "Slovenia"
                        },
                        new
                        {
                            Id = new Guid("013f8b33-8db7-45b7-b1df-845d0782b522"),
                            ShortCode = "ES",
                            Title = "Spain"
                        },
                        new
                        {
                            Id = new Guid("7b141cc4-1295-4df2-8a0a-868f81fa6dc9"),
                            ShortCode = "SE",
                            Title = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("68ae076a-b2fe-4489-9919-6fbfddfe658f"),
                            ShortCode = "CH",
                            Title = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("cf62d0bf-7180-477f-af88-970ffa144382"),
                            ShortCode = "TR",
                            Title = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("86a2292c-8d46-4223-843b-5ed7930621cc"),
                            ShortCode = "UK",
                            Title = "United Kingdom"
                        });
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailConfirmationString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Facebook")
                        .HasColumnType("bit");

                    b.Property<bool>("Google")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ReceiveEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("ReceiveNotification")
                        .HasColumnType("bit");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorAuthEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("TwoFactorString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TwoFactorStringExpiration")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("UserPhoto")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.UserFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserFiles");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Administrator"
                        },
                        new
                        {
                            Id = 100,
                            Title = "Simple"
                        });
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Activity", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.Industry", "Industry")
                        .WithMany("Activities")
                        .HasForeignKey("IndustryId");

                    b.Navigation("Industry");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.BusinessPlan", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("KabadaAPI.DataSource.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("KabadaAPI.DataSource.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Activity");

                    b.Navigation("Country");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.RefreshToken", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.User", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Industry", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
