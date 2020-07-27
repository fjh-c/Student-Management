using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Core.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Platform = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenExpiredTime = table.Column<DateTime>(nullable: false),
                    LoginTime = table.Column<long>(nullable: false),
                    LoginIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    OperatorName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Value = table.Column<string>(type: "varchar(1024)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    OperatorName = table.Column<string>(nullable: true),
                    DepartName = table.Column<string>(type: "varchar(50)", nullable: false),
                    DeptType = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depart_Depart_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    OperatorName = table.Column<string>(nullable: true),
                    Deleted = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Nation = table.Column<int>(nullable: false),
                    EnrollmentDT = table.Column<DateTime>(nullable: false),
                    DepartId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdentityCard = table.Column<string>(nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true),
                    Photos = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
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
                table: "Account",
                columns: new[] { "Id", "ModifiedTime", "Name", "PassWord", "Status", "Type", "UserName" },
                values: new object[] { new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"), new DateTime(2020, 7, 27, 10, 27, 18, 584, DateTimeKind.Local).AddTicks(6455), "管理员", "c30807e6587ade285ba7ade9f881b3d7", 1, 0, "admin" });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "Code", "CreatedTime", "ModifiedTime", "OperatorName", "Value" },
                values: new object[] { 1, "Auth", new DateTime(2020, 7, 27, 10, 27, 18, 577, DateTimeKind.Local).AddTicks(9147), new DateTime(2020, 7, 27, 10, 27, 18, 579, DateTimeKind.Local).AddTicks(4201), null, "{\"verifyCode\": false,\"validate\": true,\"button\": true,\"singleAccount\": false,\"jwt\": {\"key\": \"hG#yJ$j3#vPc9*u&\",\"issuer\": \"http://127.0.0.1:5000\",\"audience\": \"http://127.0.0.1:5000\",\"expires\": 120,\"refreshTokenExpires\": 7}}" });

            migrationBuilder.InsertData(
                table: "Depart",
                columns: new[] { "Id", "CreatedTime", "DepartName", "DeptType", "GradeId", "ModifiedTime", "OperatorName" },
                values: new object[] { 1, new DateTime(2020, 7, 27, 10, 27, 18, 593, DateTimeKind.Local).AddTicks(1336), "2020级", 0, null, new DateTime(2020, 7, 27, 10, 27, 18, 593, DateTimeKind.Local).AddTicks(1361), null });

            migrationBuilder.InsertData(
                table: "Depart",
                columns: new[] { "Id", "CreatedTime", "DepartName", "DeptType", "GradeId", "ModifiedTime", "OperatorName" },
                values: new object[] { 2, new DateTime(2020, 7, 27, 10, 27, 18, 596, DateTimeKind.Local).AddTicks(718), ".net core 基础班", 1, 1, new DateTime(2020, 7, 27, 10, 27, 18, 596, DateTimeKind.Local).AddTicks(736), null });

            migrationBuilder.InsertData(
                table: "Depart",
                columns: new[] { "Id", "CreatedTime", "DepartName", "DeptType", "GradeId", "ModifiedTime", "OperatorName" },
                values: new object[] { 3, new DateTime(2020, 7, 27, 10, 27, 18, 597, DateTimeKind.Local).AddTicks(9352), ".net core 精英班", 1, 1, new DateTime(2020, 7, 27, 10, 27, 18, 597, DateTimeKind.Local).AddTicks(9376), null });

            migrationBuilder.InsertData(
                table: "Depart",
                columns: new[] { "Id", "CreatedTime", "DepartName", "DeptType", "GradeId", "ModifiedTime", "OperatorName" },
                values: new object[] { 4, new DateTime(2020, 7, 27, 10, 27, 18, 599, DateTimeKind.Local).AddTicks(1054), "java EE 基础班", 1, 1, new DateTime(2020, 7, 27, 10, 27, 18, 599, DateTimeKind.Local).AddTicks(1074), null });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Address", "CreatedTime", "Deleted", "DepartId", "Email", "EnrollmentDT", "Gender", "IdentityCard", "ModifiedTime", "Name", "Nation", "OperatorName", "Phone", "Photos", "Status" },
                values: new object[] { 10002L, "北京市朝阳区东三环中路甲10号", new DateTime(2020, 7, 27, 10, 27, 18, 611, DateTimeKind.Local).AddTicks(7115), 0, 3, "laoli@stu.com", new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "230210199802127323", new DateTime(2020, 7, 27, 10, 27, 18, 611, DateTimeKind.Local).AddTicks(7141), "老李", 0, null, "13902451189", "stu_2.jpg", 0 });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Address", "CreatedTime", "Deleted", "DepartId", "Email", "EnrollmentDT", "Gender", "IdentityCard", "ModifiedTime", "Name", "Nation", "OperatorName", "Phone", "Photos", "Status" },
                values: new object[] { 10001L, "朝阳区朝阳公园西路9号院九号", new DateTime(2020, 7, 27, 10, 27, 18, 600, DateTimeKind.Local).AddTicks(8973), 0, 4, "xiaoan@stu.com", new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "230210199708162251", new DateTime(2020, 7, 27, 10, 27, 18, 600, DateTimeKind.Local).AddTicks(8998), "小安", 1, null, "13902451188", "stu_1.jpg", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Depart_GradeId",
                table: "Depart",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_DepartId",
                table: "StudentInfo",
                column: "DepartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AuthInfo");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "Depart");
        }
    }
}
