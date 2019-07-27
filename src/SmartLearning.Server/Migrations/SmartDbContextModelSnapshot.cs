﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartLearning.Server.Db;

namespace SmartLearning.Server.Migrations
{
    [DbContext(typeof(SmartDbContext))]
    partial class SmartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartLearning.Shared.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("StateOrProvince")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("IsVarified");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Enrollment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Examination", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("End");

                    b.Property<DateTime?>("ResultDeclaration");

                    b.Property<DateTime?>("Start");

                    b.Property<string>("Term");

                    b.HasKey("Id");

                    b.ToTable("Examination");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("End");

                    b.Property<string>("Note");

                    b.Property<DateTime?>("Start");

                    b.HasKey("Id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.TimeTable", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<DateTime?>("DateAndTime");

                    b.Property<string>("ExaminationId");

                    b.Property<int>("PracticalAllowedMarks");

                    b.Property<int>("PracticalPassingMarks");

                    b.Property<int>("SubjectId");

                    b.Property<int>("TheoryAllowedMarks");

                    b.Property<int>("TheoryPassingMarks");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("ExaminationId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TimeTable");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.Enrollment", b =>
                {
                    b.HasOne("SmartLearning.Shared.Models.Class", "Class")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartLearning.Shared.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("SmartLearning.Shared.Models.TimeTable", b =>
                {
                    b.HasOne("SmartLearning.Shared.Models.Class", "Class")
                        .WithMany("DateSheet")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartLearning.Shared.Models.Examination", "Examination")
                        .WithMany("DateSheet")
                        .HasForeignKey("ExaminationId");

                    b.HasOne("SmartLearning.Shared.Models.Subject", "Subject")
                        .WithMany("DateSheet")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
