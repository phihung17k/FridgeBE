﻿// <auto-generated />
using System;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FridgeBE.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("FridgeBE.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateBy = "admin",
                            CreateTime = new DateTimeOffset(new DateTime(2024, 9, 15, 18, 26, 52, 918, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)),
                            Name = "Fruit"
                        },
                        new
                        {
                            Id = 2,
                            CreateBy = "admin",
                            CreateTime = new DateTimeOffset(new DateTime(2024, 9, 15, 18, 26, 52, 918, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)),
                            Name = "Vegetable"
                        },
                        new
                        {
                            Id = 3,
                            CreateBy = "admin",
                            CreateTime = new DateTimeOffset(new DateTime(2024, 9, 15, 18, 26, 52, 918, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)),
                            Name = "Meat"
                        },
                        new
                        {
                            Id = 4,
                            CreateBy = "admin",
                            CreateTime = new DateTimeOffset(new DateTime(2024, 9, 15, 18, 26, 52, 918, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)),
                            Name = "Nut"
                        },
                        new
                        {
                            Id = 5,
                            CreateBy = "admin",
                            CreateTime = new DateTimeOffset(new DateTime(2024, 9, 15, 18, 26, 52, 918, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)),
                            Name = "Milk"
                        },
                        new
                        {
                            Id = 6,
                            CreateBy = "admin",
                            CreateTime = new DateTimeOffset(new DateTime(2024, 9, 15, 18, 26, 52, 918, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 7, 0, 0, 0)),
                            Name = "Rice"
                        });
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ingredient", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.IngredientRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("IngredientQuantity")
                        .HasColumnType("int");

                    b.Property<string>("IngredientQuantityUnit")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("ingredientrecipe", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("permission", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset?>("CookingTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ServingSize")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserAccountId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId");

                    b.ToTable("recipe", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Step", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("StepOrder")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("step", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("useraccount", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.UserAccountPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserAccountId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("useraccountpermission", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("RefreshTokenExpireTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserAccountId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("userlogin", (string)null);
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Ingredient", b =>
                {
                    b.HasOne("FridgeBE.Core.Entities.Category", "Category")
                        .WithMany("Ingredients")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.IngredientRecipe", b =>
                {
                    b.HasOne("FridgeBE.Core.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeBE.Core.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Recipe", b =>
                {
                    b.HasOne("FridgeBE.Core.Entities.UserAccount", "UserAccount")
                        .WithMany("Recipes")
                        .HasForeignKey("UserAccountId");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Step", b =>
                {
                    b.HasOne("FridgeBE.Core.Entities.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.UserAccountPermission", b =>
                {
                    b.HasOne("FridgeBE.Core.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeBE.Core.Entities.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.UserLogin", b =>
                {
                    b.HasOne("FridgeBE.Core.Entities.UserAccount", "UserAccount")
                        .WithOne("UserLogin")
                        .HasForeignKey("FridgeBE.Core.Entities.UserLogin", "UserAccountId");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Category", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.Recipe", b =>
                {
                    b.Navigation("Steps");
                });

            modelBuilder.Entity("FridgeBE.Core.Entities.UserAccount", b =>
                {
                    b.Navigation("Recipes");

                    b.Navigation("UserLogin")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
