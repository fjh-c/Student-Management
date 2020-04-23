﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student.Model.Code;

namespace Student.Core.API.Migrations
{
    [DbContext(typeof(myDbContext))]
    partial class myDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Student.Model.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PassWord = "admin",
                            Status = 0,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Student.Model.Depart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DeptType")
                        .HasColumnType("int");

                    b.Property<int?>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Depart");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartName = "2020级",
                            DeptType = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            DepartName = ".net core 基础班",
                            DeptType = 1,
                            GradeId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            DepartName = ".net core 精英班",
                            DeptType = 1,
                            GradeId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            DepartName = "java EE 基础班",
                            DeptType = 1,
                            GradeId = 1,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Student.Model.StudentInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("DepartId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("EnrollmentDT")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Nation")
                        .HasColumnType("int");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartId");

                    b.ToTable("StudentInfo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "朝阳区朝阳公园西路9号院九号",
                            DepartId = 4,
                            Email = "xiaoan@stu.com",
                            EnrollmentDT = new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 1,
                            Name = "小安",
                            Nation = 1,
                            PersonId = "230210199708162251",
                            Phone = "13902451188",
                            Photos = "stu_1.jpg",
                            Status = 0
                        },
                        new
                        {
                            Id = 2L,
                            Address = "北京市朝阳区东三环中路甲10号",
                            DepartId = 3,
                            Email = "laoli@stu.com",
                            EnrollmentDT = new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 0,
                            Name = "老李",
                            Nation = 0,
                            PersonId = "230210199802127323",
                            Phone = "13902451189",
                            Photos = "stu_2.jpg",
                            Status = 0
                        });
                });

            modelBuilder.Entity("Student.Model.StudentInfo", b =>
                {
                    b.HasOne("Student.Model.Depart", "Depart")
                        .WithMany()
                        .HasForeignKey("DepartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
