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
                .HasAnnotation("ProductVersion", "5.0.6")
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

                    b.Property<bool>("IsSwotCompleted")
                        .HasColumnType("bit");

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
                            Id = new Guid("7132a836-82da-41cf-83d5-55786ec40bcf"),
                            ShortCode = "AT",
                            Title = "Austria"
                        },
                        new
                        {
                            Id = new Guid("85126313-305e-44f1-9ec9-d713742f857c"),
                            ShortCode = "BA",
                            Title = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            Id = new Guid("ac23b20d-6e1e-49a1-b2d6-5c8a5a663ea3"),
                            ShortCode = "BE",
                            Title = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("8fb768c3-c511-44af-8dee-c93d14237516"),
                            ShortCode = "BG",
                            Title = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("5228e6dd-2761-429f-9c10-929d940c0880"),
                            ShortCode = "HR",
                            Title = "Croatia"
                        },
                        new
                        {
                            Id = new Guid("8be2e91d-bf6a-42e3-868c-58f8ea9164a5"),
                            ShortCode = "CY",
                            Title = "Cyprus"
                        },
                        new
                        {
                            Id = new Guid("89630086-c599-42cf-9ef4-ac1aeae1a480"),
                            ShortCode = "CZ",
                            Title = "Czechia"
                        },
                        new
                        {
                            Id = new Guid("78214696-3927-4597-9f39-2cb9ddbf5758"),
                            ShortCode = "DK",
                            Title = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("63b1e8fc-d1ab-4e1f-8ad4-36e0662dc683"),
                            ShortCode = "EE",
                            Title = "Estonia"
                        },
                        new
                        {
                            Id = new Guid("4d976243-bdd7-4bda-b537-85335c970ab0"),
                            ShortCode = "FI",
                            Title = "Finland"
                        },
                        new
                        {
                            Id = new Guid("61f16112-1ae1-47ea-aa45-93414d9f73f3"),
                            ShortCode = "FR",
                            Title = "France"
                        },
                        new
                        {
                            Id = new Guid("1edc7ea3-1b77-43de-85f2-d96c63658145"),
                            ShortCode = "DE",
                            Title = "Germany"
                        },
                        new
                        {
                            Id = new Guid("08454657-8bc3-49cf-8465-7f1e53df8f96"),
                            ShortCode = "EL",
                            Title = "Greece"
                        },
                        new
                        {
                            Id = new Guid("60396446-3a8f-4b64-9fbf-24fbfd92a19f"),
                            ShortCode = "HU",
                            Title = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("69cd61cb-4073-4892-a810-f072d330b778"),
                            ShortCode = "IS",
                            Title = "Iceland"
                        },
                        new
                        {
                            Id = new Guid("0fbee029-d1df-4b26-aa21-c104aea9b426"),
                            ShortCode = "IE",
                            Title = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("0e73b881-ab36-4520-ae27-a904656b8420"),
                            ShortCode = "IT",
                            Title = "Italy"
                        },
                        new
                        {
                            Id = new Guid("ab9a6fd7-4b7a-44c6-a972-29fe1f298eaf"),
                            ShortCode = "LV",
                            Title = "Latvia"
                        },
                        new
                        {
                            Id = new Guid("8f9c0610-1dfd-4fab-a660-b1b60081659a"),
                            ShortCode = "LI",
                            Title = "Liechtenstein"
                        },
                        new
                        {
                            Id = new Guid("202ec202-c4ff-4bc7-b3b2-0ca85d2bbb2b"),
                            ShortCode = "LT",
                            Title = "Lithuania"
                        },
                        new
                        {
                            Id = new Guid("16f71a14-2504-48f0-b61b-92f67bbbf824"),
                            ShortCode = "LU",
                            Title = "Luxembourg"
                        },
                        new
                        {
                            Id = new Guid("ec253754-d5e6-454e-a62c-d5a072e5ed3b"),
                            ShortCode = "MT",
                            Title = "Malta"
                        },
                        new
                        {
                            Id = new Guid("6af8f9cf-cef9-4879-a9e7-f8feac0a3e2b"),
                            ShortCode = "NL",
                            Title = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("ddb9e2fb-2ddb-4746-92ba-9435c4165786"),
                            ShortCode = "MK",
                            Title = "North Macedonia"
                        },
                        new
                        {
                            Id = new Guid("b9447354-7c08-4372-afd6-baec707b372d"),
                            ShortCode = "NO",
                            Title = "Norway"
                        },
                        new
                        {
                            Id = new Guid("0c0cbed6-32a4-4f67-b28e-23784a0f8c22"),
                            ShortCode = "PL",
                            Title = "Poland"
                        },
                        new
                        {
                            Id = new Guid("59a4c0bc-091b-4986-afff-048aa0fbaeec"),
                            ShortCode = "PT",
                            Title = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("e893d866-998f-4bcd-8301-d3862bc6098f"),
                            ShortCode = "RO",
                            Title = "Romania"
                        },
                        new
                        {
                            Id = new Guid("663675ba-53c6-4f62-9e17-d54cd7fcfade"),
                            ShortCode = "RS",
                            Title = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("3518711a-8787-4e47-9e17-7d10277af68f"),
                            ShortCode = "SK",
                            Title = "Slovakia"
                        },
                        new
                        {
                            Id = new Guid("aa5ea2c4-8852-48c8-972b-3834bc7f16ce"),
                            ShortCode = "SI",
                            Title = "Slovenia"
                        },
                        new
                        {
                            Id = new Guid("22e99421-3223-4442-a73d-fe8cbd7ae977"),
                            ShortCode = "ES",
                            Title = "Spain"
                        },
                        new
                        {
                            Id = new Guid("fece1725-f0b8-4973-92cf-a006d753aae3"),
                            ShortCode = "SE",
                            Title = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("223a9acc-3101-4c47-ab0e-77a94d98b85f"),
                            ShortCode = "CH",
                            Title = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("45058a36-d5e9-4777-81b8-f5ced1ddfa87"),
                            ShortCode = "TR",
                            Title = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("170f503e-ee1b-412a-8900-20d2ab2af3ac"),
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Plan_Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttrVal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BusinessPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Kind")
                        .HasColumnType("smallint");

                    b.Property<Guid>("TexterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusinessPlanId");

                    b.HasIndex("TexterId");

                    b.ToTable("Plan_Attributes");
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Texter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Kind")
                        .HasColumnType("smallint");

                    b.Property<string>("LongValue")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("MasterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Texters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c123ae32-8e22-429b-9518-91d74c522b74"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Land"
                        },
                        new
                        {
                            Id = new Guid("b8d1b11c-369c-41de-9152-21487f1e7885"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Facilities and equipment"
                        },
                        new
                        {
                            Id = new Guid("b9ed86a8-116c-470d-87ef-4779d21e27f1"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Vehicles"
                        },
                        new
                        {
                            Id = new Guid("415e5989-8913-44b2-8926-2b8caae034e2"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Inventory"
                        },
                        new
                        {
                            Id = new Guid("f7eddaa6-d248-470f-9214-a0290ce0ed21"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Skills and experience of employees"
                        },
                        new
                        {
                            Id = new Guid("2bac2601-4e37-4206-a404-2e32ca08ba0a"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Corporate image"
                        },
                        new
                        {
                            Id = new Guid("3de70d58-429d-48aa-8a0e-2a969fa12073"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Patents"
                        },
                        new
                        {
                            Id = new Guid("5eab0230-d4f1-449a-9e62-17e4255b29fe"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Trademarks"
                        },
                        new
                        {
                            Id = new Guid("fc1dc8e1-66c8-48e3-a756-6c9da8a7e899"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Copyrights"
                        },
                        new
                        {
                            Id = new Guid("b602b90a-6f04-4691-89f1-531ab2ecc273"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Operational processes"
                        },
                        new
                        {
                            Id = new Guid("436d5d5b-de7d-4194-92c2-cfaa1eff06d4"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Management processes"
                        },
                        new
                        {
                            Id = new Guid("cccb90b3-8812-4198-9b56-fe7e0b9eb981"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Supporting processes"
                        },
                        new
                        {
                            Id = new Guid("54b6e699-af73-44d6-ae43-0859c2ed9206"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Product design"
                        },
                        new
                        {
                            Id = new Guid("a2ef4f58-8d87-4ddf-9a30-cebe6337349c"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Product assortment"
                        },
                        new
                        {
                            Id = new Guid("f294bc47-4bf2-417b-81aa-3dc6ab29fb14"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Packaging and labeling"
                        },
                        new
                        {
                            Id = new Guid("45296413-b1e6-47a2-a2bb-8b1271b41a1c"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Complementary and after-sales service"
                        },
                        new
                        {
                            Id = new Guid("641df355-53d0-4e89-baa9-1c82c84ee1aa"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Guarantees and warranties"
                        },
                        new
                        {
                            Id = new Guid("cc2ecbc2-99d7-415a-b2be-011e46636144"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Return of goods"
                        },
                        new
                        {
                            Id = new Guid("1205d8ae-14d5-4d70-806d-13c85632f6bb"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Price"
                        },
                        new
                        {
                            Id = new Guid("873fd20e-9a9f-4a16-a130-2c83de5bd256"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Discounts"
                        },
                        new
                        {
                            Id = new Guid("d027391d-4d5c-41e7-9edd-eed6e136910d"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Payment terms"
                        },
                        new
                        {
                            Id = new Guid("4a1710e9-2d54-4c94-aea6-61039ca8ad45"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Customer convenient access to products"
                        },
                        new
                        {
                            Id = new Guid("24e85fad-562d-4e50-bc06-7fae24f1d977"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Advertising, PR and sales promotion"
                        },
                        new
                        {
                            Id = new Guid("a4f78afd-5116-48d4-a202-7e7f5d2114e9"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Arrival of new technology"
                        },
                        new
                        {
                            Id = new Guid("bccc433f-e3bb-4c2e-963e-e6a5982b1554"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "New regulations"
                        },
                        new
                        {
                            Id = new Guid("42c0fa95-677b-4526-98de-94dca1a6504f"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Unfulfilled customer need"
                        },
                        new
                        {
                            Id = new Guid("3d9d33fe-2c10-4bc5-8dc5-dcae99e3979f"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Taking business courses (training)"
                        },
                        new
                        {
                            Id = new Guid("64938d2e-1e76-4f1d-84da-705288a2da14"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Trend changes"
                        },
                        new
                        {
                            Id = new Guid("d0910018-dd99-43aa-9e30-be9eb5386533"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "New substitute products"
                        });
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Plan_Attribute", b =>
                {
                    b.HasOne("KabadaAPI.DataSource.Models.BusinessPlan", "BusinessPlan")
                        .WithMany()
                        .HasForeignKey("BusinessPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KabadaAPI.DataSource.Models.Texter", "Texter")
                        .WithMany()
                        .HasForeignKey("TexterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessPlan");

                    b.Navigation("Texter");
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
                    b.HasOne("KabadaAPI.DataSource.Models.BusinessPlan", "BusinessPlan")
                        .WithMany()
                        .HasForeignKey("BusinessPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessPlan");
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
