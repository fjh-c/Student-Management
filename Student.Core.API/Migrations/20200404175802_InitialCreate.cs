using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Core.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    NationId = table.Column<int>(nullable: false),
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
                        name: "FK_StudentInfo_Nation_NationId",
                        column: x => x.NationId,
                        principalTable: "Nation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "汉族" },
                    { 2, "蒙古族" },
                    { 3, "回族" },
                    { 4, "藏族" },
                    { 5, "维吾尔族" },
                    { 6, "苗族" }
                });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "Id", "Address", "Email", "Name", "NationId", "PersonId", "Phone", "Photos", "Sex", "Status" },
                values: new object[] { 1, "安三区和道街102号", "zhangsan@stu.com", "张三", 1, "230210199802127323", "13902451189", "stu_1.jpg", 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_NationId",
                table: "StudentInfo",
                column: "NationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "Nation");
        }
    }
}
