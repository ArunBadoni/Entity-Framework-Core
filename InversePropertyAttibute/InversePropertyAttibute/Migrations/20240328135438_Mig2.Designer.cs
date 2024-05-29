﻿// <auto-generated />
using System;
using InversePropertyAttibute.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InversePropertyAttibute.Migrations
{
    [DbContext(typeof(EFCoreDbContext))]
    [Migration("20240328135438_Mig2")]
    partial class Mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InversePropertyAttibute.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OnlineTeacherTeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("OnlineTeacherTeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("InversePropertyAttibute.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("InversePropertyAttibute.Entities.Course", b =>
                {
                    b.HasOne("InversePropertyAttibute.Entities.Teacher", "OnlineTeacher")
                        .WithMany("OnlineCourses")
                        .HasForeignKey("OnlineTeacherTeacherId");

                    b.Navigation("OnlineTeacher");
                });

            modelBuilder.Entity("InversePropertyAttibute.Entities.Teacher", b =>
                {
                    b.Navigation("OnlineCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
