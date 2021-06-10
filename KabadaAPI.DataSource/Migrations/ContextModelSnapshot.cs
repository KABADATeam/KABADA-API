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
                            Id = new Guid("5aae7627-d896-49eb-89bf-e95b0933c36f"),
                            ShortCode = "AT",
                            Title = "Austria"
                        },
                        new
                        {
                            Id = new Guid("dcfd24b9-c310-43c5-830f-18e9d25244bc"),
                            ShortCode = "BA",
                            Title = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            Id = new Guid("dc1021b6-ea89-40c3-a6b5-de136b172841"),
                            ShortCode = "BE",
                            Title = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("c7e7a23c-1282-44b5-9a13-d6da96983082"),
                            ShortCode = "BG",
                            Title = "Bulgaria"
                        },
                        new
                        {
                            Id = new Guid("29ef8234-0454-425f-a10b-69ae6ea42431"),
                            ShortCode = "HR",
                            Title = "Croatia"
                        },
                        new
                        {
                            Id = new Guid("1adcb212-2f41-4e5b-9795-4ac40d8cdd68"),
                            ShortCode = "CY",
                            Title = "Cyprus"
                        },
                        new
                        {
                            Id = new Guid("132eba36-686f-4b0c-a574-4050cfc3789b"),
                            ShortCode = "CZ",
                            Title = "Czechia"
                        },
                        new
                        {
                            Id = new Guid("33090f4c-805d-44c8-9ea2-7b1917bd9dc0"),
                            ShortCode = "DK",
                            Title = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("24324abf-b9ca-48ca-97cb-f22e4a6111ee"),
                            ShortCode = "EE",
                            Title = "Estonia"
                        },
                        new
                        {
                            Id = new Guid("6a731f4b-8a59-4187-bd16-d0554aa98223"),
                            ShortCode = "FI",
                            Title = "Finland"
                        },
                        new
                        {
                            Id = new Guid("0fe2dee3-3569-402b-a41f-414771ca6726"),
                            ShortCode = "FR",
                            Title = "France"
                        },
                        new
                        {
                            Id = new Guid("20800704-48b7-4a11-bd9c-970c19752b06"),
                            ShortCode = "DE",
                            Title = "Germany"
                        },
                        new
                        {
                            Id = new Guid("3b42dacb-c38d-4825-8d14-88525d5fa492"),
                            ShortCode = "EL",
                            Title = "Greece"
                        },
                        new
                        {
                            Id = new Guid("3c552a5c-81c3-41a1-9d43-52821c2cd823"),
                            ShortCode = "HU",
                            Title = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("34a7d9a5-37d8-4556-bebc-eb0a9671b827"),
                            ShortCode = "IS",
                            Title = "Iceland"
                        },
                        new
                        {
                            Id = new Guid("d483df4a-c6e2-4be8-979f-ff64ae1d6427"),
                            ShortCode = "IE",
                            Title = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("3472306e-da2d-484f-a78a-336e4303e726"),
                            ShortCode = "IT",
                            Title = "Italy"
                        },
                        new
                        {
                            Id = new Guid("502e82f9-bb69-4ef7-a1fd-6b2ac2b48d7e"),
                            ShortCode = "LV",
                            Title = "Latvia"
                        },
                        new
                        {
                            Id = new Guid("d4b42fae-8f13-4475-81a0-045aa2181323"),
                            ShortCode = "LI",
                            Title = "Liechtenstein"
                        },
                        new
                        {
                            Id = new Guid("273f7fd3-e942-4ae9-b861-9452d6e90384"),
                            ShortCode = "LT",
                            Title = "Lithuania"
                        },
                        new
                        {
                            Id = new Guid("dbd5d44c-5954-4ea8-8233-3e0185350db9"),
                            ShortCode = "LU",
                            Title = "Luxembourg"
                        },
                        new
                        {
                            Id = new Guid("75593c0f-f80e-405e-80a1-934873ede7e2"),
                            ShortCode = "MT",
                            Title = "Malta"
                        },
                        new
                        {
                            Id = new Guid("857df42f-85b9-408d-8e58-f4bb58d7f962"),
                            ShortCode = "NL",
                            Title = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("b2a6707a-3340-4496-8fdf-9577681d9bf8"),
                            ShortCode = "MK",
                            Title = "North Macedonia"
                        },
                        new
                        {
                            Id = new Guid("e4539bfb-af64-4210-9ef4-6099a2f925bf"),
                            ShortCode = "NO",
                            Title = "Norway"
                        },
                        new
                        {
                            Id = new Guid("b2a9f77b-cdfe-4e5f-8144-e568e69259ae"),
                            ShortCode = "PL",
                            Title = "Poland"
                        },
                        new
                        {
                            Id = new Guid("2e4b5819-dd96-42a1-873d-86b51672a04f"),
                            ShortCode = "PT",
                            Title = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("8a018e58-6e26-46c2-bdf6-89021a5d76f0"),
                            ShortCode = "RO",
                            Title = "Romania"
                        },
                        new
                        {
                            Id = new Guid("8c4d3052-67a1-44dc-872b-bb92f423f448"),
                            ShortCode = "RS",
                            Title = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("82b12c06-6b5a-4bfc-b94b-d1e308e40936"),
                            ShortCode = "SK",
                            Title = "Slovakia"
                        },
                        new
                        {
                            Id = new Guid("3a78b5d6-db36-4f3f-97c3-5f3820f8b55e"),
                            ShortCode = "SI",
                            Title = "Slovenia"
                        },
                        new
                        {
                            Id = new Guid("3c9f2fc9-5403-4d29-b8f0-87ce746e74ca"),
                            ShortCode = "ES",
                            Title = "Spain"
                        },
                        new
                        {
                            Id = new Guid("6095f6fe-7e30-4d68-980e-73c0bb3ca532"),
                            ShortCode = "SE",
                            Title = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("ffd45adc-36bf-4d0d-958b-f204440ef7d2"),
                            ShortCode = "CH",
                            Title = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("fc1c7a7e-487c-40db-b83c-85828fa9daa1"),
                            ShortCode = "TR",
                            Title = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("16970235-03fb-4775-969c-9f0984f182de"),
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Plan_SWOT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Kind")
                        .HasColumnType("smallint");

                    b.Property<Guid>("TexterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusinessPlanId");

                    b.HasIndex("TexterId");

                    b.ToTable("Plan_SWOTs");
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
                            Id = new Guid("a9069b1b-48ec-4ed2-9d27-1f41f80b521b"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Land"
                        },
                        new
                        {
                            Id = new Guid("df114ebd-3db3-4130-a5d6-874d9fe967d4"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Facilities and equipment"
                        },
                        new
                        {
                            Id = new Guid("cac72224-0ff7-49a0-a789-7006d7acd112"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Vehicles"
                        },
                        new
                        {
                            Id = new Guid("c0cc8cc0-6f99-41bf-bee4-32f273f9bcc8"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Inventory"
                        },
                        new
                        {
                            Id = new Guid("226ed896-5bd5-44a0-b5b7-5d8fdf70930a"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Skills and experience of employees"
                        },
                        new
                        {
                            Id = new Guid("863f0412-e80c-44d0-89f3-254868809299"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Corporate image"
                        },
                        new
                        {
                            Id = new Guid("ca399b8f-7e1c-48ec-911a-262fea1fa252"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Patents"
                        },
                        new
                        {
                            Id = new Guid("c94e21dd-bb4d-4edf-b559-051ff29249ae"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Trademarks"
                        },
                        new
                        {
                            Id = new Guid("10138686-b68f-468a-b7c1-76bad0c29f51"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Copyrights"
                        },
                        new
                        {
                            Id = new Guid("ca66f6fb-8341-4af2-b5e9-5f5a93eb7885"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Operational processes"
                        },
                        new
                        {
                            Id = new Guid("43cb0e9c-7d74-4592-8bc2-e64be826cdad"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Management processes"
                        },
                        new
                        {
                            Id = new Guid("debc3ad2-d7b9-4457-a77e-db2290dce06c"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Supporting processes"
                        },
                        new
                        {
                            Id = new Guid("eea7bc7e-aec6-4e1e-9978-3fd4b16bd246"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Product design"
                        },
                        new
                        {
                            Id = new Guid("b8811bd4-2f18-4b5d-bd0d-c231b4fa0f8b"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Product assortment"
                        },
                        new
                        {
                            Id = new Guid("19921043-b705-4364-9fba-6b853371c8ac"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Packaging and labeling"
                        },
                        new
                        {
                            Id = new Guid("c01b76e6-eac7-4444-aaa4-97c3635e69a1"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Complementary and after-sales service"
                        },
                        new
                        {
                            Id = new Guid("a7beec15-83b7-45fc-9d2c-2e6eedea63e5"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Guarantees and warranties"
                        },
                        new
                        {
                            Id = new Guid("60ac60dd-7754-4862-b631-ffa10affbc9c"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Return of goods"
                        },
                        new
                        {
                            Id = new Guid("2b9ea8ea-81b2-442c-87b7-b8457dbeea30"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Price"
                        },
                        new
                        {
                            Id = new Guid("c38e784e-85fe-4f39-b6c0-f7658706e728"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Discounts"
                        },
                        new
                        {
                            Id = new Guid("a86fc000-7153-4dfe-a2f3-4eab793e8ecb"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Payment terms"
                        },
                        new
                        {
                            Id = new Guid("f4c890bb-c670-4735-8fb6-9507e913f1c5"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Customer convenient access to products"
                        },
                        new
                        {
                            Id = new Guid("90878977-918c-4a8e-afe6-85b1de925bad"),
                            Kind = (short)1,
                            LongValue = "a",
                            Value = "Advertising, PR and sales promotion"
                        },
                        new
                        {
                            Id = new Guid("78888ace-1512-40be-a7d2-1c1850b11cbe"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Arrival of new technology"
                        },
                        new
                        {
                            Id = new Guid("e17596d3-3375-4cfe-8c6e-e986b01d0079"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "New regulations"
                        },
                        new
                        {
                            Id = new Guid("4a4329fb-76c9-409f-b098-7fecfaf609e2"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Unfulfilled customer need"
                        },
                        new
                        {
                            Id = new Guid("7c751b12-1bea-4437-99b0-009162dae5c2"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Taking business courses (training)"
                        },
                        new
                        {
                            Id = new Guid("2cf3f47c-a785-43e1-b0dc-b079e436ee4f"),
                            Kind = (short)3,
                            LongValue = "a",
                            Value = "Trend changes"
                        },
                        new
                        {
                            Id = new Guid("88746366-ace9-4073-b07b-2601d2b4e565"),
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

            modelBuilder.Entity("KabadaAPI.DataSource.Models.Plan_SWOT", b =>
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
