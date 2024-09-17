﻿// <auto-generated />
using System;
using API.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("RegistrationNumber");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasPrecision(100)
                        .HasColumnType("text");

                    b.Property<int>("Office")
                        .HasColumnType("integer");

                    b.Property<decimal>("Remuneration")
                        .HasPrecision(7, 2)
                        .HasColumnType("numeric(7,2)");

                    b.HasKey("Id");

                    b.ToTable("TB_EMPLOYEES", (string)null);
                });

            modelBuilder.Entity("API.Models.Entities.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("MovimentNumber");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("integer")
                        .HasColumnName("Id_Responsible");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.ToTable("TB_MOVIMENTS", (string)null);
                });

            modelBuilder.Entity("API.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<string>("Descrition")
                        .IsRequired()
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasColumnType("varchar(13)");

                    b.Property<decimal>("MediumPrice")
                        .HasPrecision(7, 2)
                        .HasColumnType("numeric(7,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TB_PRODUCTS", (string)null);
                });

            modelBuilder.Entity("API.Models.Entities.ProductMoviment", b =>
                {
                    b.Property<int>("MovementID")
                        .HasColumnType("integer")
                        .HasColumnName("ID_MOVEMENT");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer")
                        .HasColumnName("ID_PRODUCT");

                    b.HasKey("MovementID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("TB_PRODUCT_MOVEMENT", (string)null);
                });

            modelBuilder.Entity("API.Models.Entities.Vacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("end")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("numberOfdays")
                        .HasColumnType("integer");

                    b.Property<DateTime>("start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TB_VACATIONS", (string)null);
                });

            modelBuilder.Entity("API.Models.Entities.Movement", b =>
                {
                    b.HasOne("API.Models.Entities.Employee", "Employee")
                        .WithMany("Movements")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Entities.ProductMoviment", b =>
                {
                    b.HasOne("API.Models.Entities.Movement", "Movement")
                        .WithMany()
                        .HasForeignKey("MovementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movement");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Models.Entities.Vacation", b =>
                {
                    b.HasOne("API.Models.Entities.Employee", null)
                        .WithMany("Vacation")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("API.Models.Entities.Employee", b =>
                {
                    b.Navigation("Movements");

                    b.Navigation("Vacation");
                });
#pragma warning restore 612, 618
        }
    }
}
