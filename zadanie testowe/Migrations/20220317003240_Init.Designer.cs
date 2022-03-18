﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zadanie_testowe.Controllers;

namespace zadanie_testowe.Migrations
{
    [DbContext(typeof(ToDoTaskDbContext))]
    [Migration("20220317003240_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("zadanie_testowe.Controllers.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfExpiry")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeToExpiry")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}
