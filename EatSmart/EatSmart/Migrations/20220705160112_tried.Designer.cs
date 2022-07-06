﻿// <auto-generated />
using System;
using EatSmart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EatSmart.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220705160112_tried")]
    partial class tried
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EatSmart.Models.Intolerance", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("varchar(255)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("name");

                    b.HasIndex("UserId");

                    b.ToTable("Intolerance");
                });

            modelBuilder.Entity("EatSmart.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaxDailyCalories")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EatSmart.Models.Intolerance", b =>
                {
                    b.HasOne("EatSmart.Models.User", null)
                        .WithMany("Intolerances")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EatSmart.Models.User", b =>
                {
                    b.Navigation("Intolerances");
                });
#pragma warning restore 612, 618
        }
    }
}