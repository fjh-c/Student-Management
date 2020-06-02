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

            modelBuilder.Entity("Student.Model.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"),
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 719, DateTimeKind.Local).AddTicks(286),
                            Name = "管理员",
                            PassWord = "c30807e6587ade285ba7ade9f881b3d7",
                            Status = 1,
                            Type = 0,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Student.Model.Depart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DeptType")
                        .HasColumnType("int");

                    b.Property<int?>("GradeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OperatorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Depart");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2020, 6, 2, 13, 44, 31, 722, DateTimeKind.Local).AddTicks(3194),
                            DepartName = "2020级",
                            DeptType = 0,
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 722, DateTimeKind.Local).AddTicks(3202)
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(6131),
                            DepartName = ".net core 基础班",
                            DeptType = 1,
                            GradeId = 1,
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(6137)
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(9580),
                            DepartName = ".net core 精英班",
                            DeptType = 1,
                            GradeId = 1,
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(9586)
                        },
                        new
                        {
                            Id = 4,
                            CreatedTime = new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(2080),
                            DepartName = "java EE 基础班",
                            DeptType = 1,
                            GradeId = 1,
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(2084)
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

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<int>("DepartId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("EnrollmentDT")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Nation")
                        .HasColumnType("int");

                    b.Property<string>("OperatorName")
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
                            Id = 10001L,
                            Address = "朝阳区朝阳公园西路9号院九号",
                            CreatedTime = new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(9625),
                            Deleted = 0,
                            DepartId = 4,
                            Email = "xiaoan@stu.com",
                            EnrollmentDT = new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 1,
                            IdentityCard = "230210199708162251",
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(9630),
                            Name = "小安",
                            Nation = 1,
                            Phone = "13902451188",
                            Photos = "stu_1.jpg",
                            Status = 0
                        },
                        new
                        {
                            Id = 10002L,
                            Address = "北京市朝阳区东三环中路甲10号",
                            CreatedTime = new DateTime(2020, 6, 2, 13, 44, 31, 727, DateTimeKind.Local).AddTicks(7724),
                            Deleted = 0,
                            DepartId = 3,
                            Email = "laoli@stu.com",
                            EnrollmentDT = new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 0,
                            IdentityCard = "230210199802127323",
                            ModifiedTime = new DateTime(2020, 6, 2, 13, 44, 31, 727, DateTimeKind.Local).AddTicks(7730),
                            Name = "老李",
                            Nation = 0,
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
