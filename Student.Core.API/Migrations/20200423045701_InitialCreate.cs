using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Core.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    DepartName = table.Column<string>(type: "varchar(50)", nullable: false),
                    DeptType = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Nation = table.Column<int>(nullable: false),
                    EnrollmentDT = table.Column<DateTime>(nullable: false),
                    DepartId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    PersonId = table.Column<string>(nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true),
                    Photos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInfo_Depart_DepartId",
                        column: x => x.DepartId,
                        principalTable: "Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "PassWord", "Status", "UserName" },
                values: new object[] { 1, "admin", 0, "admin" });

            migrationBuilder.InsertData(
                table: "Depart",
                columns: new[] { "Id", "DepartName", "DeptType", "GradeId", "Status" },
                values: new object[,]
                {
                    { 1, "2020级", 0, null, 0 },
                    { 2, ".net core 基础班", 1, 1, 0 },
                    { 3, ".net core 精英班", 1, 1, 0 },
                    { 4, "java EE 基础班", 1, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Address", "DepartId", "Email", "EnrollmentDT", "Gender", "Name", "Nation", "PersonId", "Phone", "Photos", "Status" },
                values: new object[] { 2, "北京市朝阳区东三环中路甲10号", 3, "laoli@stu.com", new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "老李", 0, "230210199802127323", "13902451189", "stu_2.jpg", 0 });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Address", "DepartId", "Email", "EnrollmentDT", "Gender", "Name", "Nation", "PersonId", "Phone", "Photos", "Status" },
                values: new object[] { 1, "朝阳区朝阳公园西路9号院九号", 4, "xiaoan@stu.com", new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "小安", 1, "230210199708162251", "13902451188", "stu_1.jpg", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_DepartId",
                table: "StudentInfo",
                column: "DepartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "Depart");
        }
    }
}
