﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using iTechArt.Database.DbContexts;

#nullable disable

namespace iTechArt.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("iTechArt.Database.Entities.Airports.AirportDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("AirportName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<int>("AverageTicketPrice")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BuiltDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("EmpoyeesCount")
                        .HasColumnType("integer");

                    b.Property<long>("FlightsPerYear")
                        .HasColumnType("bigint");

                    b.Property<long>("PassengersPerYear")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("iTechArt.Database.Entities.Groceries.GroceryDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthday");

                    b.Property<string>("Departmentretail")
                        .HasColumnType("text")
                        .HasColumnName("department_retail");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("first_Name");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint")
                        .HasColumnName("gender");

                    b.Property<string>("Jobtitle")
                        .HasColumnType("text")
                        .HasColumnName("job_title");

                    b.Property<string>("LastName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("last_Name");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision")
                        .HasColumnName("salary");

                    b.HasKey("Id");

                    b.ToTable("Groceries");
                });

            modelBuilder.Entity("iTechArt.Database.Entities.MedicalStaff.MedStaffDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("HospitalName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("LastName")
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<byte>("Shift")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("iTechArt.Database.Entities.Police.PoliceDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Police");
                });

            modelBuilder.Entity("iTechArt.Database.Entities.Pupils.PupilDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("City")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<byte>("CourseLanguage")
                        .HasColumnType("smallint");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint");

                    b.Property<byte>("Grade")
                        .HasColumnType("smallint");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("SchoolName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<byte>("Shift")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("iTechArt.Database.Entities.Students.StudentDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Majority")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("University")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
