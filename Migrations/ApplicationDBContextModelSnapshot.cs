﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using project.utils;

#nullable disable

namespace Nuevo.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("project.modules.foods.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("cookTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("favorite")
                        .HasColumnType("boolean");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("origins")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<float>("stars")
                        .HasColumnType("real");

                    b.Property<List<string>>("tags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<DateTime?>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userUpdateId")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_primary_foods");

                    b.HasIndex("userUpdateId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("project.modules.orders.LatLng", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lng")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userUpdateId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("userUpdateId");

                    b.ToTable("LatLng");
                });

            modelBuilder.Entity("project.modules.orders.models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AddressLatLngId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userUpdateId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressLatLngId");

                    b.HasIndex("userUpdateId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("project.modules.orders.models.orderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FoodId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userUpdateId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.HasIndex("userUpdateId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("project.roles.rolEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userUpdateId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.HasIndex("userUpdateId");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("project.users.userEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("updateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("userUpdateId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("userUpdateId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("project.roles.rolEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("project.users.userEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("project.users.userEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("project.roles.rolEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.users.userEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("project.users.userEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project.modules.foods.Food", b =>
                {
                    b.HasOne("project.users.userEntity", "userUpdate")
                        .WithMany()
                        .HasForeignKey("userUpdateId");

                    b.Navigation("userUpdate");
                });

            modelBuilder.Entity("project.modules.orders.LatLng", b =>
                {
                    b.HasOne("project.users.userEntity", "userUpdate")
                        .WithMany()
                        .HasForeignKey("userUpdateId");

                    b.Navigation("userUpdate");
                });

            modelBuilder.Entity("project.modules.orders.models.Order", b =>
                {
                    b.HasOne("project.modules.orders.LatLng", "AddressLatLng")
                        .WithMany()
                        .HasForeignKey("AddressLatLngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.users.userEntity", "userUpdate")
                        .WithMany()
                        .HasForeignKey("userUpdateId");

                    b.Navigation("AddressLatLng");

                    b.Navigation("userUpdate");
                });

            modelBuilder.Entity("project.modules.orders.models.orderItem", b =>
                {
                    b.HasOne("project.modules.foods.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.modules.orders.models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.users.userEntity", "userUpdate")
                        .WithMany()
                        .HasForeignKey("userUpdateId");

                    b.Navigation("Food");

                    b.Navigation("Order");

                    b.Navigation("userUpdate");
                });

            modelBuilder.Entity("project.roles.rolEntity", b =>
                {
                    b.HasOne("project.users.userEntity", "userUpdate")
                        .WithMany()
                        .HasForeignKey("userUpdateId");

                    b.Navigation("userUpdate");
                });

            modelBuilder.Entity("project.users.userEntity", b =>
                {
                    b.HasOne("project.users.userEntity", "userUpdate")
                        .WithMany()
                        .HasForeignKey("userUpdateId");

                    b.Navigation("userUpdate");
                });

            modelBuilder.Entity("project.modules.foods.Food", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("project.modules.orders.models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
