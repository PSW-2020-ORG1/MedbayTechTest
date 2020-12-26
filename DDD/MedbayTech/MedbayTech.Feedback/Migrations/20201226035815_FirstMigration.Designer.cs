﻿// <auto-generated />
using System;
using MedbayTech.Feedback.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedbayTech.Feedback.Migrations
{
    [DbContext(typeof(FeedbackDbContext))]
    [Migration("20201226035815_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MedbayTech.Feedback.Domain.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int");

                    b.Property<string>("AdditionalNotes")
                        .HasColumnName("AdditionalNotes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("AllowedForPublishing")
                        .HasColumnName("AllowedForPublishing")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Anonymous")
                        .HasColumnName("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Approved")
                        .HasColumnName("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnName("RegisteredUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
