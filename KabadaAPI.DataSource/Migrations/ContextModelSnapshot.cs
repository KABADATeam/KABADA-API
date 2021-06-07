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
                            Id = new Guid("c096f401-de5e-4e9c-8a8d-8deac0e147ea"),
                            ShortCode = "AT",
                            Title = "Austria"
                        },
                        new
                        {
                            Id = new Guid("7498d010-db21-4762-9283-facdadac74f8"),
                            ShortCode = "BA",
                            Title = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            Id = new Guid("dd740d99-f863-4014-8b4d-232473ce56d4"),
                            ShortCode = "BE",
                            Title = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("8e0c8d9e-1ced-4e58-95a4-c64c86c6267a"),
                            ShortCode = "BG",
                            Title = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("944fd834-b723-4dec-9fe6-9394d54da53c"),
                            ShortCode = "HR",
                            Title = "Croatia"
                        },
                        new
                        {
                            Id = new Guid("ed1d2957-e95a-4c57-a2c3-8f9ca771bb7c"),
                            ShortCode = "CY",
                            Title = "Cyprus"
                        },
                        new
                        {
                            Id = new Guid("befc51b7-2c89-4db4-a80c-c60113df6ad4"),
                            ShortCode = "CZ",
                            Title = "Czechia"
                        },
                        new
                        {
                            Id = new Guid("14e981be-bac8-46bc-82e5-32ead6cb58f1"),
                            ShortCode = "DK",
                            Title = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("23fd694c-8c5d-49ac-a32c-1cf1946661fb"),
                            ShortCode = "EE",
                            Title = "Estonia"
                        },
                        new
                        {
                            Id = new Guid("791fd1be-fc27-44e1-9c56-b2fba273d86c"),
                            ShortCode = "FI",
                            Title = "Finland"
                        },
                        new
                        {
                            Id = new Guid("13e2582d-5095-426d-91ba-b01fefb82d9b"),
                            ShortCode = "FR",
                            Title = "France"
                        },
                        new
                        {
                            Id = new Guid("6780de5e-48e5-412f-92c1-9ee5ffc2179f"),
                            ShortCode = "DE",
                            Title = "Germany"
                        },
                        new
                        {
                            Id = new Guid("51a92ecc-c481-407b-81e6-feb7067cdf96"),
                            ShortCode = "EL",
                            Title = "Greece"
                        },
                        new
                        {
                            Id = new Guid("da2485b5-5201-49a1-9e2e-20f6a8f67771"),
                            ShortCode = "HU",
                            Title = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("82d56c8a-8169-4bcf-b0ae-6e678bfd54fe"),
                            ShortCode = "IS",
                            Title = "Iceland"
                        },
                        new
                        {
                            Id = new Guid("892a8ad4-1a91-4f38-908c-a182ecba5722"),
                            ShortCode = "IE",
                            Title = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("1f70afd3-bff3-4066-b4cb-3ca9bb750f58"),
                            ShortCode = "IT",
                            Title = "Italy"
                        },
                        new
                        {
                            Id = new Guid("6281bf95-7315-41f5-ac4e-fb1537963668"),
                            ShortCode = "LV",
                            Title = "Latvia"
                        },
                        new
                        {
                            Id = new Guid("385d9a3b-a5b6-4c24-aeaf-f5fd30dba44d"),
                            ShortCode = "LI",
                            Title = "Liechtenstein"
                        },
                        new
                        {
                            Id = new Guid("5c3340c2-7a58-4c1d-855b-9f87649626e6"),
                            ShortCode = "LT",
                            Title = "Lithuania"
                        },
                        new
                        {
                            Id = new Guid("1e5902d8-e310-4e90-8b9b-03c561db0124"),
                            ShortCode = "LU",
                            Title = "Luxembourg"
                        },
                        new
                        {
                            Id = new Guid("05bba7c6-742d-4f1d-8ed4-c2cc2c156eaf"),
                            ShortCode = "MT",
                            Title = "Malta"
                        },
                        new
                        {
                            Id = new Guid("dd99a756-0632-480d-937e-eb5d39e16423"),
                            ShortCode = "NL",
                            Title = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("f17a8b5e-3063-4070-a12c-b929c79cd721"),
                            ShortCode = "MK",
                            Title = "North Macedonia"
                        },
                        new
                        {
                            Id = new Guid("62524e7f-12fc-409b-ac26-c3c4fd887177"),
                            ShortCode = "NO",
                            Title = "Norway"
                        },
                        new
                        {
                            Id = new Guid("a305e39f-5a3a-4fda-81cb-82a4ac48aca8"),
                            ShortCode = "PL",
                            Title = "Poland"
                        },
                        new
                        {
                            Id = new Guid("b9bb510a-c96f-40d4-8f14-d6c3bcfac947"),
                            ShortCode = "PT",
                            Title = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("a7af6f04-5f33-42e6-940f-dab8d5a87d8a"),
                            ShortCode = "RO",
                            Title = "Romania"
                        },
                        new
                        {
                            Id = new Guid("8356c33c-8904-4991-bf74-5e7c6128946c"),
                            ShortCode = "RS",
                            Title = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("14d87cb9-01e8-412e-8ebb-283d956633ce"),
                            ShortCode = "SK",
                            Title = "Slovakia"
                        },
                        new
                        {
                            Id = new Guid("37ac6e38-8c8e-46ee-b018-c7d442afb451"),
                            ShortCode = "SI",
                            Title = "Slovenia"
                        },
                        new
                        {
                            Id = new Guid("e469fc99-01cb-417e-b2c2-ed62ab880263"),
                            ShortCode = "ES",
                            Title = "Spain"
                        },
                        new
                        {
                            Id = new Guid("b7a2a4bf-b038-42ad-9ab9-28360701a471"),
                            ShortCode = "SE",
                            Title = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("1260aa58-e2f7-456d-b101-07f13363bf77"),
                            ShortCode = "CH",
                            Title = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("1fd6107c-0861-4da6-b532-84af2ab6b461"),
                            ShortCode = "TR",
                            Title = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("51bacae2-3bac-4771-a9c2-d552668fb2df"),
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.SharedPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusinessPlanId");

                    b.ToTable("SharedPlans");
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.SharedPlan", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.BusinessPlan", null)
                        .WithMany("SharedPlans")
                        .HasForeignKey("BusinessPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.User", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.BusinessPlan", b =>
                {
                    b.Navigation("SharedPlans");
                });

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Industry", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
