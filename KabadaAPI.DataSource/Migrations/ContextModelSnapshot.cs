﻿// <auto-generated />
using System;
using KabadaAPI.DataSource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KabadaAPI.DataSource.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
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

                    b.Property<Guid>("ActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("19c9a496-113e-432f-818b-0cac6826c1bd"),
                            ShortCode = "AT",
                            Title = "Austria"
                        },
                        new
                        {
                            Id = new Guid("9c050dff-56c1-4498-a0cd-d8ae6d9a6852"),
                            ShortCode = "BA",
                            Title = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            Id = new Guid("7e8b8007-19fe-4540-abbd-d4f25d139cf0"),
                            ShortCode = "BE",
                            Title = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("ed572569-ddea-4c67-8802-cc3292e538ed"),
                            ShortCode = "BG",
                            Title = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("04156915-3b6a-426c-afa3-c919be1dde80"),
                            ShortCode = "HR",
                            Title = "Croatia"
                        },
                        new
                        {
                            Id = new Guid("a96eacf7-1b7a-4ae6-9330-abad1e4d6b35"),
                            ShortCode = "CY",
                            Title = "Cyprus"
                        },
                        new
                        {
                            Id = new Guid("e4d2bfc0-afba-42ae-b679-0a6ea9117d96"),
                            ShortCode = "CZ",
                            Title = "Czechia"
                        },
                        new
                        {
                            Id = new Guid("9566004f-1bf0-4d79-a9cc-758e596bf253"),
                            ShortCode = "DK",
                            Title = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("86b69af7-7092-4d3e-b0d2-d061e9f4faa2"),
                            ShortCode = "EE",
                            Title = "Estonia"
                        },
                        new
                        {
                            Id = new Guid("99e6e658-76f7-4cdd-af7c-007df834df9d"),
                            ShortCode = "FI",
                            Title = "Finland"
                        },
                        new
                        {
                            Id = new Guid("9aa4620d-cac4-4866-81d4-ccac9ceec330"),
                            ShortCode = "FR",
                            Title = "France"
                        },
                        new
                        {
                            Id = new Guid("51ec6742-3f0a-4194-8c34-d1a602af273b"),
                            ShortCode = "DE",
                            Title = "Germany"
                        },
                        new
                        {
                            Id = new Guid("19938bf5-d608-4479-9d33-0263152aae04"),
                            ShortCode = "EL",
                            Title = "Greece"
                        },
                        new
                        {
                            Id = new Guid("48d107ee-ee37-4d16-bb55-022e5c7d79cb"),
                            ShortCode = "HU",
                            Title = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("5fc9ac01-cf9b-4cbe-bfec-1ce3c3c878db"),
                            ShortCode = "IS",
                            Title = "Iceland"
                        },
                        new
                        {
                            Id = new Guid("e9df115d-7475-47ce-8a4f-e12c07cd248f"),
                            ShortCode = "IE",
                            Title = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("e8fd9ca2-465d-4e20-8422-8324706ba33f"),
                            ShortCode = "IT",
                            Title = "Italy"
                        },
                        new
                        {
                            Id = new Guid("5543dca5-56d2-4d20-805e-a85d363e3bef"),
                            ShortCode = "LV",
                            Title = "Latvia"
                        },
                        new
                        {
                            Id = new Guid("8897a384-f454-451c-afb9-4b4704cc65e2"),
                            ShortCode = "LI",
                            Title = "Liechtenstein"
                        },
                        new
                        {
                            Id = new Guid("6869a7ca-514a-4305-9694-25a5ecaacd3c"),
                            ShortCode = "LT",
                            Title = "Lithuania"
                        },
                        new
                        {
                            Id = new Guid("80e01a3d-aef4-4686-9f39-a0bd5cd53ae5"),
                            ShortCode = "LU",
                            Title = "Luxembourg"
                        },
                        new
                        {
                            Id = new Guid("1c0cf7ba-e377-4579-b827-331ce81f6396"),
                            ShortCode = "MT",
                            Title = "Malta"
                        },
                        new
                        {
                            Id = new Guid("c33f3bef-ca43-4faa-8b7f-3fd843b5011a"),
                            ShortCode = "NL",
                            Title = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("82a03045-edbe-4689-9e8c-4a0357539ce8"),
                            ShortCode = "MK",
                            Title = "North Macedonia"
                        },
                        new
                        {
                            Id = new Guid("d5b7b411-79ec-47a0-a35b-2d8eed5000b4"),
                            ShortCode = "NO",
                            Title = "Norway"
                        },
                        new
                        {
                            Id = new Guid("5b3dfc90-8a00-4a39-a028-9ef977f5230e"),
                            ShortCode = "PL",
                            Title = "Poland"
                        },
                        new
                        {
                            Id = new Guid("42c96344-1a64-4d51-9bef-fea0eb399df2"),
                            ShortCode = "PT",
                            Title = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("01c11456-a25d-464c-82f7-affdbf8b61aa"),
                            ShortCode = "RO",
                            Title = "Romania"
                        },
                        new
                        {
                            Id = new Guid("1deb28f9-ce83-401e-a44f-5fbc621227a8"),
                            ShortCode = "RS",
                            Title = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("2404514c-e872-43ca-a3a1-34f5c2d44877"),
                            ShortCode = "SK",
                            Title = "Slovakia"
                        },
                        new
                        {
                            Id = new Guid("a2581b15-5bfd-42fe-92b8-88122a74eecb"),
                            ShortCode = "SI",
                            Title = "Slovenia"
                        },
                        new
                        {
                            Id = new Guid("0b085bc4-87ba-4b4d-9712-94fdc5c5e249"),
                            ShortCode = "ES",
                            Title = "Spain"
                        },
                        new
                        {
                            Id = new Guid("14c7449d-1d4e-44be-a121-39d2fbbcb927"),
                            ShortCode = "SE",
                            Title = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("837632d0-aeb2-4383-8eed-4883327e672c"),
                            ShortCode = "CH",
                            Title = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("03e387ca-6901-44f9-b668-8947179339db"),
                            ShortCode = "TR",
                            Title = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("e7a381cc-9597-4d92-83c0-08d82ea0cc03"),
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

                    b.Property<Guid>("UserId")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetString")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");
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
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.BusinessPlan", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KabadaAPI.DataSource.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KabadaAPI.DataSource.Models.User", null)
                        .WithMany("BusinessPlans")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.RefreshToken", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.User", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
