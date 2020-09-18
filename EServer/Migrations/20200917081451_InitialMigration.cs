using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Serialnumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "Name", "Serialnumber" },
                values: new object[] { new Guid("dee4f94d-d127-498a-b238-7ce5d9350e0c"), "Yamaha XJ6", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorcycles");
        }
    }
}
