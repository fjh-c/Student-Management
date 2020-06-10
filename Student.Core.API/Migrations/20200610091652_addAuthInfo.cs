using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Core.API.Migrations
{
    public partial class addAuthInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Depart_GradeId",
                table: "Depart",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depart_Depart_GradeId",
                table: "Depart",
                column: "GradeId",
                principalTable: "Depart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depart_Depart_GradeId",
                table: "Depart");

            migrationBuilder.DropTable(
                name: "AuthInfo");

            migrationBuilder.DropIndex(
                name: "IX_Depart_GradeId",
                table: "Depart");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("39f08cfd-8e0d-771b-a2f3-2639a62ca2fa"),
                column: "ModifiedTime",
                value: new DateTime(2020, 6, 2, 13, 44, 31, 719, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 2, 13, 44, 31, 722, DateTimeKind.Local).AddTicks(3194), new DateTime(2020, 6, 2, 13, 44, 31, 722, DateTimeKind.Local).AddTicks(3202) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(6131), new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(9580), new DateTime(2020, 6, 2, 13, 44, 31, 723, DateTimeKind.Local).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "Depart",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(2080), new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(2084) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10001L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(9625), new DateTime(2020, 6, 2, 13, 44, 31, 724, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "StudentInfo",
                keyColumn: "Id",
                keyValue: 10002L,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2020, 6, 2, 13, 44, 31, 727, DateTimeKind.Local).AddTicks(7724), new DateTime(2020, 6, 2, 13, 44, 31, 727, DateTimeKind.Local).AddTicks(7730) });
        }
    }
}
