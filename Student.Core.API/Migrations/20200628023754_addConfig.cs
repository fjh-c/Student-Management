using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Core.API.Migrations
{
    public partial class addConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"),
                column: "ModifiedTime",
                value: new DateTime(2020, 6, 28, 10, 37, 53, 208, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "Code", "CreatedTime", "ModifiedTime", "OperatorName", "Value" },
                values: new object[] { 1, "Auth", new DateTime(2020, 6, 28, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(1768), new DateTime(2020, 6, 28, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(7915), null, "{\"AuthConfig\": {\"verifyCode\": false,\"validate\": true,\"button\": true,\"singleAccount\": false,\"jwt\": {\"key\": \"hG#yJ$j3#vPc9*u&\",\"issuer\": \"http://127.0.0.1:5000\",\"audience\": \"http://127.0.0.1:5000\",\"expires\": 120,\"refreshTokenExpires\": 7}}}" });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 211, DateTimeKind.Local).AddTicks(5651), new DateTime(2020, 6, 28, 10, 37, 53, 211, DateTimeKind.Local).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 212, DateTimeKind.Local).AddTicks(2866), new DateTime(2020, 6, 28, 10, 37, 53, 212, DateTimeKind.Local).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 212, DateTimeKind.Local).AddTicks(6777), new DateTime(2020, 6, 28, 10, 37, 53, 212, DateTimeKind.Local).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 212, DateTimeKind.Local).AddTicks(9666), new DateTime(2020, 6, 28, 10, 37, 53, 212, DateTimeKind.Local).AddTicks(9671) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10001L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 213, DateTimeKind.Local).AddTicks(7463), new DateTime(2020, 6, 28, 10, 37, 53, 213, DateTimeKind.Local).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10002L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 216, DateTimeKind.Local).AddTicks(5939), new DateTime(2020, 6, 28, 10, 37, 53, 216, DateTimeKind.Local).AddTicks(5945) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"),
                column: "ModifiedTime",
                value: new DateTime(2020, 6, 10, 17, 16, 51, 2, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 10, 17, 16, 51, 6, DateTimeKind.Local).AddTicks(2957), new DateTime(2020, 6, 10, 17, 16, 51, 6, DateTimeKind.Local).AddTicks(2964) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 10, 17, 16, 51, 7, DateTimeKind.Local).AddTicks(7373), new DateTime(2020, 6, 10, 17, 16, 51, 7, DateTimeKind.Local).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 10, 17, 16, 51, 8, DateTimeKind.Local).AddTicks(1402), new DateTime(2020, 6, 10, 17, 16, 51, 8, DateTimeKind.Local).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 10, 17, 16, 51, 8, DateTimeKind.Local).AddTicks(4145), new DateTime(2020, 6, 10, 17, 16, 51, 8, DateTimeKind.Local).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10001L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 10, 17, 16, 51, 9, DateTimeKind.Local).AddTicks(2089), new DateTime(2020, 6, 10, 17, 16, 51, 9, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10002L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 10, 17, 16, 51, 12, DateTimeKind.Local).AddTicks(1244), new DateTime(2020, 6, 10, 17, 16, 51, 12, DateTimeKind.Local).AddTicks(1250) });
        }
    }
}
