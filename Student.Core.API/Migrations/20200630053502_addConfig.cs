using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Core.API.Migrations
{
    public partial class addConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"),
                column: "ModifiedTime",
                value: new DateTime(2020, 6, 30, 13, 35, 1, 168, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime", "Value" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 166, DateTimeKind.Local).AddTicks(3628), new DateTime(2020, 6, 30, 13, 35, 1, 167, DateTimeKind.Local).AddTicks(85), "{\"verifyCode\": false,\"validate\": true,\"button\": true,\"singleAccount\": false,\"jwt\": {\"key\": \"hG#yJ$j3#vPc9*u&\",\"issuer\": \"http://127.0.0.1:5000\",\"audience\": \"http://127.0.0.1:5000\",\"expires\": 120,\"refreshTokenExpires\": 7}}" });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 172, DateTimeKind.Local).AddTicks(1685), new DateTime(2020, 6, 30, 13, 35, 1, 172, DateTimeKind.Local).AddTicks(1696) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 172, DateTimeKind.Local).AddTicks(9004), new DateTime(2020, 6, 30, 13, 35, 1, 172, DateTimeKind.Local).AddTicks(9009) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 173, DateTimeKind.Local).AddTicks(3016), new DateTime(2020, 6, 30, 13, 35, 1, 173, DateTimeKind.Local).AddTicks(3022) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 173, DateTimeKind.Local).AddTicks(5960), new DateTime(2020, 6, 30, 13, 35, 1, 173, DateTimeKind.Local).AddTicks(5964) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10001L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 174, DateTimeKind.Local).AddTicks(3803), new DateTime(2020, 6, 30, 13, 35, 1, 174, DateTimeKind.Local).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10002L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 30, 13, 35, 1, 177, DateTimeKind.Local).AddTicks(2292), new DateTime(2020, 6, 30, 13, 35, 1, 177, DateTimeKind.Local).AddTicks(2298) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"),
                column: "ModifiedTime",
                value: new DateTime(2020, 6, 28, 10, 37, 53, 208, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime", "Value" },
                values: new object[] { new DateTime(2020, 6, 28, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(1768), new DateTime(2020, 6, 28, 10, 37, 53, 206, DateTimeKind.Local).AddTicks(7915), "{\"AuthConfig\": {\"verifyCode\": false,\"validate\": true,\"button\": true,\"singleAccount\": false,\"jwt\": {\"key\": \"hG#yJ$j3#vPc9*u&\",\"issuer\": \"http://127.0.0.1:5000\",\"audience\": \"http://127.0.0.1:5000\",\"expires\": 120,\"refreshTokenExpires\": 7}}}" });

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
    }
}
