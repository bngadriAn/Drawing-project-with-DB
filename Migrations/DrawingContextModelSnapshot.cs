﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1003_órai_console_léptetés;

#nullable disable

namespace DrawingProject.Migrations
{
    [DbContext(typeof(DrawingContext))]
    partial class DrawingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_1003_órai_console_léptetés.Drawing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharPosX")
                        .HasColumnType("int");

                    b.Property<int>("CharPosY")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GetCharNum")
                        .HasColumnType("int");

                    b.Property<int>("GetColorNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drawings");
                });
#pragma warning restore 612, 618
        }
    }
}
